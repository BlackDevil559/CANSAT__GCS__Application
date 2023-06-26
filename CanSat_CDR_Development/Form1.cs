using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace CanSat_CDR_Development
{
    public partial class Form1 : Form
    {
        Timer myTimer = new Timer();
        Random random = new Random();
        Stopwatch stopWatch = new Stopwatch();
        SerialPort serialPort = new SerialPort("COM9", 9600);
        int currentRow = 0;
        int pressure = 0;
        Bitmap step0 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step0.png");
        Bitmap step1 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step1.png");
        Bitmap step2 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step2.png");
        Bitmap step3 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step3.png");
        Bitmap step4 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step4.png");
        Bitmap step5 = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\step5.png");
        Bitmap final = new Bitmap("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\Images\\final.png");
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        StreamWriter sw = new StreamWriter("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\cansat.csv");
        private object textBox11;

        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

       
        private void Form1_Load(object sender, EventArgs e)
        {
            UserControl4 userControl4 = new UserControl4();
            this.Controls.Add(userControl11);
            this.Controls.Add(userControl31);
            this.Controls.Add(userControl41);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            userControl11.Hide();
            userControl31.Hide();
            userControl41.Hide();

            richTextBox1.Text = DateTime.Now.ToString("hh:mm:ss");
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size + 40, richTextBox1.Font.Style);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.SelectionBackColor = Color.Transparent;

            richTextBox2.Text = "00:00:00";
            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, richTextBox2.Font.Size + 40, richTextBox2.Font.Style);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.SelectionBackColor = Color.Transparent;

            richTextBox3.Font = new Font(richTextBox3.Font.FontFamily, richTextBox3.Font.Size + 16, richTextBox3.Font.Style);
            richTextBox3.SelectionBackColor = Color.Transparent;

            richTextBox4.Font = new Font(richTextBox4.Font.FontFamily, richTextBox4.Font.Size + 10, richTextBox4.Font.Style);
            richTextBox4.Text = "Status: Connection Pending";
            richTextBox1.SelectionColor = Color.FromArgb(212, 225, 255);
            richTextBox4.BorderStyle = BorderStyle.None;
            richTextBox4.SelectionBackColor = Color.Transparent;

            //for changing the color
            button1.BackColor = Color.FromArgb(212, 225, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);

            //for removing border
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;

            //for removing the effect of hovering on button
            button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button3.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button4.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button5.FlatAppearance.MouseOverBackColor = button1.BackColor;

            //for making the button curved
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();
            int radius = 30;
            Rectangle rect1= button1.ClientRectangle;

            path1.AddArc(rect1.Right - radius, rect1.Top, radius, radius, -90, 90);
            path1.AddLine(rect1.Right, rect1.Bottom, rect1.Left, rect1.Bottom);
            path1.AddLine(rect1.Left, rect1.Top, rect1.Right - radius, rect1.Top);
            button1.Region = new Region(path1);



            button13.BackColor = Color.FromArgb(128, 165, 255);
            button13.FlatAppearance.BorderSize = 0;

            button14.BackColor = Color.FromArgb(128, 165, 255);
            button14.FlatAppearance.BorderSize = 0;


        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            userControl31.Hide();
            userControl11.Hide();
            userControl41.Hide();
            //for changing color
            button1.BackColor = Color.FromArgb(212, 225, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl41.Show();
            userControl41.BringToFront();
            userControl31.Hide();
            userControl11.Hide();
            //for changing color
            button1.BackColor = Color.FromArgb(128, 165, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(212, 225, 255);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl41.Hide();
            userControl31.Hide();
            userControl11.Show();
            userControl11.BringToFront();
            //for changing the color
            button1.BackColor = Color.FromArgb(128, 165, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(212, 225, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl41.Hide();
            userControl11.Hide();
            userControl31.Show();
            userControl31.BringToFront();
            //for changing the color
            button1.BackColor = Color.FromArgb(128, 165, 255);
            button3.BackColor = Color.FromArgb(212, 225, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for changing the color
            button1.BackColor = Color.FromArgb(128, 165, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl31.Hide();
            userControl11.Hide();
            userControl41.Hide();
            userControl31.BringToFront();
            //for changing the color
            button1.BackColor = Color.FromArgb(128, 165, 255);
            button3.BackColor = Color.FromArgb(128, 165, 255);
            button4.BackColor = Color.FromArgb(128, 165, 255);
            button5.BackColor = Color.FromArgb(128, 165, 255);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string buffer = "";
            while (true && serialPort.IsOpen)
            {
                string data = serialPort.ReadExisting();
                buffer += data;
                int index = buffer.IndexOf('\n');
                if (index >= 0)
                {
                    String line = buffer.Substring(0, index).Trim();
                    string k = line;
                    
                    buffer = buffer.Substring(index + 1);
                    this.Invoke(new Action(() =>
                    {
                        sw.WriteLine(line);
                        string[] s = line.Split(',');

                        if (s.Length == 20)
                        {

                            userControl11.chart1.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[5]);
                            userControl11.chart2.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[9]);
                            userControl11.chart3.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[14]);
                            userControl11.chart4.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[17]);
                            userControl11.chart5.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[15]);
                            userControl11.chart6.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[18]);
                            userControl11.chart7.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[10]);
                            userControl11.chart8.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[2]);
                            userControl11.chart9.Series["Series1"].Points.AddXY(DateTime.Now.ToString("h:mm"), s[11]);

                        }
                        if (s.Length == 20)
                        {
                            if (userControl31.dataGridView1.Rows.Count >= 12)
                            {
                                userControl31.dataGridView1.Rows.RemoveAt(0);
                            }
                            if (userControl31.dataGridView2.Rows.Count >= 12)
                            {
                                userControl31.dataGridView2.Rows.RemoveAt(0);
                            }
                            string[] firstArray = new string[10];
                            string[] secondArray = new string[10];

                            Array.Copy(s, 0, firstArray, 0, 10);
                            Array.Copy(s, 10, secondArray, 0, 10);
                            userControl31.dataGridView2.Rows.Add(firstArray);
                            userControl31.dataGridView1.Rows.Add(secondArray);

                            pressure = int.Parse(s[11]);
                            if (pressure == 20)
                            {
                                pictureBox2.Image = step1;
                                /*string textToSpeak = "Step1 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                            if (pressure == 30)
                            {
                                pictureBox2.Image = step2;
                                /*string textToSpeak = "Step2 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                            if(pressure == 40)
                            {
                                pictureBox2.Image = step3;
                                /*string textToSpeak = "Step3 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                            if( pressure == 50)
                            {
                                pictureBox2.Image = step4;
                               /* string textToSpeak = "Step4 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                            if(pressure == 60)
                            {
                                pictureBox2.Image = step5;
                                /*string textToSpeak = "Step5 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                            if (pressure == 70)
                            {
                                pictureBox2.Image = final;
                             /*   string textToSpeak = "Step6 completed Sucessfully";
                                synthesizer.Speak(textToSpeak);*/
                            }
                        }
                    }));
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "COM9")
            {
                richTextBox4.Text="Status: Connection Established";
               /* string textToSpeak = "Connection Established Sucessfully";
                synthesizer.Speak(textToSpeak);*/
                serialPort.DtrEnable = true;
                serialPort.Open();
                myTimer.Tick += new EventHandler(TimerEventProcessor);
                myTimer.Interval = 1000;
                myTimer.Start();
                if (sw.BaseStream == null)
                {
                    sw = new StreamWriter("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\cansat.csv", true);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            richTextBox3.Text = "";
          /*  string textToSpeak = "Connection Disconnected Sucessfully";
            synthesizer.Speak(textToSpeak);*/
            richTextBox4.Text = "Staus: Disconnected";
            stopWatch.Reset();
            stopWatch.Stop();
            sw.Dispose();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "COM9")
            {
                richTextBox4.Text = "Status: Refreshed and Connected";
              /*  string textToSpeak = "Connection Refreshed and Connected Sucessfully";
                synthesizer.Speak(textToSpeak);*/
                stopWatch.Reset();
                stopWatch.Start();
                sw = new StreamWriter("C:\\Users\\Bhume\\OneDrive\\Documents\\CanSat\\cansat.csv", true);
            }
            else
            {
                richTextBox4.Text = "Status: Refreshed and Disconnected";
               /* string textToSpeak = "Connection Refreshed and Disconnected Sucessfully";
                synthesizer.Speak(textToSpeak);*/
                serialPort.Close();
                stopWatch.Reset();
                stopWatch.Stop();
                sw.Dispose();
            }
        }
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {

            richTextBox1.Text = DateTime.Now.ToString("hh:mm:ss");
            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, 46, richTextBox1.Font.Style);
            richTextBox1.BorderStyle = BorderStyle.None;

            richTextBox2.Text = stopWatch.Elapsed.ToString("hh\\:mm\\:ss");
            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, 46, richTextBox2.Font.Style);
            richTextBox2.BorderStyle = BorderStyle.None;

            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.BaudRate = 9600;
            serialPort.ReadTimeout = 1000;
            serialPort.Encoding = Encoding.ASCII;

            serialPort.DataReceived += serialPort_DataReceived;
           
            if (serialPort.IsOpen)
            {
                stopWatch.Start();
            }
            if (userControl41.simulationmode == 1)
            {
                if (currentRow < userControl41.dataRows.Count)
                {
                    serialPort.Write(userControl41.dataRows[currentRow]+"\n");
                    currentRow++;
                }
            }
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void userControl41_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

    }
}
