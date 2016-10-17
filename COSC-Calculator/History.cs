using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC_Calculator
{
    public partial class History : Form
    {
        List<string> HistList = new List<string>();
        public History(List<string> HistoryList)
        {
            //Makes it so you can edit the information in the TB
            InitializeComponent();

            textBox1.Enabled = false;
            HistList = HistoryList;
            for(int i = 0; i < HistoryList.Count; i++)
            {
                textBox1.Text += HistList[i] + Environment.NewLine + Environment.NewLine;
            }
        }


        /// <summary>
        /// Used to export the calculators history to a text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            System.DateTime time = DateTime.Now;
            int day = time.Day;
            int month = time.Month;
            int year = time.Year;
            string fileName = month + "-" + day + "-" + year + "-Equations.txt";
            string path = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);

            string pathString = System.IO.Path.Combine(path, fileName);
            //if (!File.Exists(path + fileName))
            //{
            // Create a file to write to.
            using (StreamWriter streamWriter = File.CreateText(pathString))
                {

                streamWriter.WriteLine("************************************************************");
                streamWriter.WriteLine("************************************************************");
                streamWriter.WriteLine("Created on " + time.ToString());
                streamWriter.WriteLine(Environment.NewLine);

                for (int i = 0; i < HistList.Count; i++)
                    {
                        streamWriter.WriteLine(HistList[i]);
                        streamWriter.WriteLine(Environment.NewLine);
                    
                    }
                streamWriter.WriteLine(Environment.NewLine);
                streamWriter.WriteLine("************************************************************");
                streamWriter.WriteLine("************************************************************");


                streamWriter.Close();
            }
            
            //}

        }
    }
}
