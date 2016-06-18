using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using SniperUsbDmx.Properties;
using FT_HANDLE = System.UInt32;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using SniperUsbDmx.Display;
using System.Windows.Forms;

namespace SniperUsbDmx
{
    public class DmxIoManager
    {
        protected List<IDisplayDmx> DisplayControls;
        protected List<IQueueBuffer> InputBuffers;
        protected byte[] buffer;
        protected int busLength;
        
        protected uint handle;
        protected bool done = false;
      
 
        public bool Connected = false;
        public int StartCounter = 0;

        protected Thread writeDMXBUfferThread;
        public event StateChangedEventHandler StateChanged;

        public DmxIoManager(List<IQueueBuffer> InputList, List<IDisplayDmx> OutputList)
        {
            busLength = Settings.Default.DMXChannelCount;
            if (buffer == null)
            {
                buffer = new byte[busLength]; // can be any length up to 512. The shorter the faster.
            }
            InputBuffers = InputList;
            DisplayControls = OutputList;
        }

        protected DmxLimits limits;
        public void setLimits(DmxLimits newLimits)
        {
            limits = newLimits;
        }
        protected object startLock = null;

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        public virtual void start()
        {
            if (startLock == null)
            {
                startLock = new object();
            }
            try
            {
                lock (startLock)
                {
                 
                    writeDMXBUfferThread = new Thread(new ThreadStart(writeDMXBuffer));
                    writeDMXBUfferThread.IsBackground = true;
                    done = false;
                    writeDMXBUfferThread.Start();

       
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
       
        }




      

        public byte[] GetLiveBuffer()
        {
            return (byte[])buffer.Clone();
        }
        protected bool BuildBufferFromQueues()
        {
            byte[] oldBuffer = GetLiveBuffer();

            //copy the buffers to an array (fixed length) for sorting & merge - so we can unlock the dictionary sooner
            QueueBuffer[] arrayBuffers = this.InputBuffers.CopyQueueBuffersToArray();
            byte[] newBuffer = arrayBuffers.MergeQueueBuffers(busLength);
            this.newData= oldBuffer.CompareBuffers(newBuffer);
           
            if (newData)
            {
                newBuffer.CopyTo(buffer, 0);

                if (StateChanged != null)
                {
                    StateChanged(null, new StateChangedEventArgs()
                    {
                        CurrentState = buffer
                    });
                }
            }
            return this.newData;
        }

    
        public byte?[] GetCurrentBuffer()
        {
            return (byte?[])buffer.Clone();
        }

        protected bool newData = false;
        protected virtual void writeDMXBuffer()
        {
            while (!done)
            {
                try
                {
                    newData = BuildBufferFromQueues();
               
                    if (newData)
                    {
                        foreach (IDisplayDmx var in DisplayControls)
                        {
                            SafeSendDMX(var, buffer);// var.SendDMX(buffer);
                        }

                          
                        newData = false;
                    }

                    System.Threading.Thread.Sleep(25);
                    
                    if (this.DisplayControls.Count == 0)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    break;
                }
            }
            Connected = false;
            done = false;
        }

        delegate void SetTextCallback(IDisplayDmx target, byte[] dmxValues);
        private void SafeSendDMX(IDisplayDmx target, byte[] dmxValues)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            Control controlRef = target as Control;
            if (controlRef != null)
            {
                if (controlRef.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SafeSendDMX);
                    controlRef.Invoke(d, new object[] { target, dmxValues });
                    return;
                }
   
            }
            target.SendDMX(dmxValues);

        }

        public void Dispose()
        {
            //if (Connected)
            //{
            done = true;

            //}
            Thread.Sleep(400);
            if (writeDMXBUfferThread != null)
            {
                writeDMXBUfferThread.Abort();
                Thread.Sleep(400);
            }
           
        }
     

    }






}
