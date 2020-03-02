using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{

    public class QueueBuffer:IQueueBuffer
    {
        public QueueBuffer(int size=512):this(1,new byte?[size])
        {
            
        }
        public QueueBuffer(int priority, byte?[] buffer)
        {
            Priority = priority;
            HardBuffer = buffer;
        }

      
         public byte?[] Buffer()
        {
            return this.HardBuffer;
        }
        public byte?[] HardBuffer
        {
            get;
            set;
        }

        public int Priority { get; set; }
      

    

      
    }
}
