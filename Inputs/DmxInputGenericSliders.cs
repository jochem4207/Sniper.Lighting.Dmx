using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SniperUsbDmx.Inputs
{
    public partial class DmxInputGenericSliders : UserControl,IQueueBuffer
    {
        public DmxInputGenericSliders()
        {
            InitializeComponent();
        }

        private int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }

            set
            {
                _priority = value;
            }
        }

        public byte?[] Buffer()
        {
            byte?[] toReturn=new byte?[512];
            toReturn.SetNull();
            int x = (int)this.numericUpDown1.Value;
            x = (x > 509) ? 509 : x;

            int a = (int)this.trackBar1.Value;
            int b = (int)this.trackBar1.Value;
            int c = (int)this.trackBar1.Value;
            toReturn[x] = (byte)a;
            toReturn[x + 1] = (byte)b;
            toReturn[x + 2] = (byte)c;
            return toReturn;
        }

 
    }
}
