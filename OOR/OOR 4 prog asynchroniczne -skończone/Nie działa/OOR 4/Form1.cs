using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace OOR_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Task.Factory.StartNew(() => BigLong("Fredi")).ContinueWith(t => label1.Text = 
            //    t.Result, TaskScheduler.FromCurrentSynchronizationContext());
            //label1.Text = BigLong("Dżony");
            CallBigLong();
            label1.Text = "Czekaj...";
        }
        private async void CallBigLong()
        {
            var resoult = BigLongAsync("Andrej");
            label1.Text = resoult;
        }

        private Task<string> BigLongAsync(string name)
        {
            return Task.Factory.StartNew(() => BigLong(name));
        }

        private string BigLong(string name) 
        {
            Thread.Sleep(2000);
            return "Hello, " + name;
        }
    }
}
