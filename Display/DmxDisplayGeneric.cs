using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SniperUsbDmx.Display
{
    public partial class DmxDisplayGeneric : UserControl,IDisplayDmx
    {
        private DataTable dt;
        public DmxDisplayGeneric()
        {
            InitializeComponent();

        }
     
        public void SendDMX(byte[] dmx)
        {
            dt = new DataTable();
            dt.Columns.Add("Channel");
            dt.Columns.Add("Value");
            for(int i = 0; i < dmx.Length; i++)
            {
                if (dmx[i] > 0 || this.checkBox1.Checked)
                {
                    string[] row = new string[2];
                    row[0] = i.ToString();
                    row[1] = dmx[i].ToString();
                    dt.LoadDataRow(row, true);
                }
            }
            dataGridView1.DataSource = dt;
        }

     
    }
}
