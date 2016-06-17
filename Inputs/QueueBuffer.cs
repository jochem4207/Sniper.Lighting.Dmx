using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{

    public class QueueBuffer:IQueueBuffer
    {
        public QueueBuffer(int BusLength=512)
        {
            CurrentPriority = 1;
            HardBuffer = new byte?[BusLength];
        }

      

        public byte?[] HardBuffer
        {
            get;
            set;
        }

        int IQueueBuffer.Priority
        {
            get
            {
                return CurrentPriority;
            }

            set
            {
                CurrentPriority = value;
            }
        }

        public int CurrentPriority;

      public  int Priority()
        {
            return this.CurrentPriority;
        }
       public byte?[] Buffer()
        {
            return this.HardBuffer;
        }
    }
}
