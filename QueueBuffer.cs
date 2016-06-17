using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public interface IQueueBuffer
    {
        int Priority();
       
         byte?[] Buffer();
    }
    public class QueueBuffer:IQueueBuffer
    {
        public QueueBuffer(int BusLength)
        {
            CurrentPriority = 1;
            HardBuffer = new byte?[BusLength];
        }

        public int CurrentPriority { get;  set; }


        public byte?[] HardBuffer
        {
            get;
            set;
        }
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
