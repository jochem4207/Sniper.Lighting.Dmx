using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public interface IQueueBuffer
    {
        int Priority
        {
            get; set;
        }

        byte?[] Buffer();
    }
}
