using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace OWR_1
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string sourceCode = WorkerClass.getSourceCode(url);
            StreamWriter sw = new StreamWriter("stronka.txt");
            sw.Write(sourceCode);
            sw.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imageurl=new Uri(textBox1.Text);
            wc.DownloadFileAsync(imageurl, "Pobrany_Obrazek.jpg");
        }

        private void FileDownloadComplete(object sneder, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Pobeiranie skończone");
        }
    }
}
