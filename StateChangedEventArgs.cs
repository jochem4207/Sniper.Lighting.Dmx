using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SniperUsbDmx
{
    public class StateChangedEventArgs : EventArgs
    {
        public byte[] CurrentState;
    }
}
