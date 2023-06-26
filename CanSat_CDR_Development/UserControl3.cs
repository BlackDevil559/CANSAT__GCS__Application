using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace CanSat_CDR_Development
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {


            string[] columnNames = new string[] { "TeamID", "Qime", "PacketCount", "Mode", "State", "Altitude", "P", "C", "M", "Temperature" };

            for (int i = 0; i < columnNames.Length; i++)
            {
                dataGridView2.Columns.Add(columnNames[i], columnNames[i]);
            }
            
            string[] d = new string[] { "Voltage", "Pressure", "GPS_TIME", "GPS_Altitude", "GPS_Latitude", "GPS_Longitude", "GPS_SATs", "TILT_X", "TILT_Y","PC_Deployed" };

            for (int i = 0; i<d.Length; i++)
            {
                dataGridView1.Columns.Add(d[i], d[i]);
            }

}

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        public void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
