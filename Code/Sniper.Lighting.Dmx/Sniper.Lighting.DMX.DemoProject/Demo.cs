using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sniper.Lighting.DMX.DemoProject
{
    class Demo
    {
        //shared boolean to track if you're connected
        public bool IsConnected { get { return DmxController<DMXProUSB>.Connected; } }

        void DMXProUSB_StateChangedHandler(object sender, StateChangedEventArgs e)
        {
            //this handler is called by a different (non UI) thread so if you want to update
            //ui controls you'll need to BeginInvoke
            //get the current DMX values
            var values = DmxController<DMXProUSB>.GetCurrentValues();
        }
        public void TurnLightsOn()
        {
            //connect to controller if not connected
            ConnectToController();
            Guid queueId = Guid.Empty;
            //queues allow you to segregate events that run in parallel; use Guid.Empty for the shared queue
            //when all effects on a given queue ID (other than Empty) are complete, the queue is deleted 
            //and those channels return to off.


            //the Guid.Empty queue is never deleted so allows you set permanent state
            int priority = 1;
            //priority allows you to control the order in which parallel queues are stacked

            // Channel 11 is brightness for par 1
            int channel = 11;
            // Max value
            byte channelValue = 255;
            //call the controller to set the value on the queue; this is a permanent set (will stay until you change it)
            DmxController<DMXProUSB>.SetDmxValue(queue: queueId, channel: channel, priority: priority, value: channelValue, when: DateTime.Now);
            GetDMXControllerValues(11);

            // Channel 12 is red for par 1
            channel = 12;
            channelValue = 255;
            DmxController<DMXProUSB>.SetDmxValue(queue: queueId, channel: channel, priority: priority, value: channelValue, when: DateTime.Now);
            GetDMXControllerValues(12);
        }

        private void GetDMXControllerValues(int channel)
        {
            Console.WriteLine(DmxController<DMXProUSB>.GetCurrentValues());
            Console.WriteLine(DmxController<DMXProUSB>.GetDmxValue(channel));
        }

        public void ConnectToController()
        {
            if (!IsConnected)
            {
                //you only need to set up limits once; this allows you to lock specific channels to max values, e.g. if they are behind a wall or under the floor and you don't want them heating up and burning

                DmxController<DMXProUSB>.SetLimits(new DmxLimits
                {
                    Min = Enumerable.Range(0, 512).Select(c => (byte)0).ToArray(),
                    Max = Enumerable.Range(0, 512).Select(c => (byte)255).ToArray(),
                });

                //in a try/catch (can throw)
                try
                {
                    //attempt a start
                    if (DmxController<DMXProUSB>.Start())
                    {
                        //if now connected
                        if (DmxController<DMXProUSB>.Connected)
                        {
                            //attach to handler
                            //note: don't forget to detach this later if you lose connection
                            DmxController<DMXProUSB>.StateChanged += DMXProUSB_StateChangedHandler;
                        }
                        else
                        {
                            Console.WriteLine("DmxController.Start returned [true] but not connected");
                        }
                    }
                    else
                    {
                        Console.WriteLine("DmxController.Start returned [false]");
                    }
                }
                catch (Exception ex)
                {
                    //exception occurred, failed to connect
                    Console.WriteLine("DmxController.Start threw {0}", ex);
                }
            }
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                //shut down DMX controller
                DmxController<DMXProUSB>.StateChanged -= DMXProUSB_StateChangedHandler;
                DmxController<DMXProUSB>.Dispose();
            }
        }

    }
}
