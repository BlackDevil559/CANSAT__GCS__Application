using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Speech.Synthesis;

namespace CanSat_CDR_Development
{


    public partial class UserControl4 : UserControl
    {
        public List<string> dataRows = new List<string>();
        public int simulationmode = 0;
        public string selectedFilePath;
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public UserControl4()
        {
            InitializeComponent();
            
            

        }

        private void button6_Click(object sender, EventArgs e) { 
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Set the initial directory (optional)
                openFileDialog.InitialDirectory = "C:\\";

                // Set the filter for the types of files to display
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                // Set the title of the dialog box
                openFileDialog.Title = "Select a file";

                // Show the dialog box and check if the user clicked the OK button
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;

                // Display the selected file path in a text box or label
                /*string textToSpeak = "Simulation File Selected";
                synthesizer.Speak(textToSpeak);*/
                richTextBox1.Text = "Status: Simulation File Selected: " + selectedFilePath;
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            simulationmode = 1;
            
            richTextBox1.Text = "Status: Simulation Mode Started";
          /*  string textToSpeak = "Simulation Mode Started";
            synthesizer.Speak(textToSpeak);*/
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(selectedFilePath))
            {
                string line1;
                while ((line1 = reader.ReadLine()) != null)
                {
                    dataRows.Add(line1);
                }
               
            }
            /*string textToSpeak = "Simulation Data Loaded";
            synthesizer.Speak(textToSpeak);*/
            richTextBox1.Text = "Status: Simulation Data Loaded";
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            simulationmode = 0;
           /* string textToSpeak = "Simulation Mode Stopped";
            synthesizer.Speak(textToSpeak);*/
            richTextBox1.Text = "Status: Simulation Mode Stopped";
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}
