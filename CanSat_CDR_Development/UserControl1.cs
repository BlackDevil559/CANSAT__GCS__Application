using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace CanSat_CDR_Development
{
    public partial class UserControl1 : UserControl
    {
        Random random = new Random();
        Timer myTimer = new Timer();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }


        private void UserControl1_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("Altitude v/s Time");
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart3.Titles.Add("Lattitude v/s Time");
            chart3.Series[0].IsVisibleInLegend = false;
            chart3.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart5.Titles.Add("Longitude v/s Time");
            chart5.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart5.Series[0].IsVisibleInLegend = false;
            chart5.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart5.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart5.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart5.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart2.Titles.Add("Temperature v/s Time");
            chart2.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart2.Series[0].IsVisibleInLegend = false;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart4.Titles.Add("Tilt_X v/s Time");
            chart4.Series[0].IsVisibleInLegend = false;
            chart4.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart4.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart4.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart6.Titles.Add("Tilt_Y v/s Time");
            chart6.Series[0].IsVisibleInLegend = false;
            chart6.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart6.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart6.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart6.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart6.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart7.Titles.Add("Voltage v/s Time");
            chart7.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart7.Series[0].IsVisibleInLegend = false;
            chart7.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart7.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart7.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart7.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart8.Titles.Add("Packet Count v/s Time");
            chart8.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart8.Series[0].IsVisibleInLegend = false;
            chart8.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart8.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart8.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart8.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

            chart9.Titles.Add("Pressure v/s Time");
            chart9.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
            chart9.Series[0].IsVisibleInLegend = false;
            chart9.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart9.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart9.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart9.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
