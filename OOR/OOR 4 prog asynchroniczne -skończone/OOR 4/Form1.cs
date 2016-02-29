using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

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
          //Task.Factory.StartNew(() => Big("Elmo")).ContinueWith(t => label1.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());      
          // label1.Text=Big ("Jonny");
            CallBig();
            label1.Text = "Czekaj...";

        }

        private async void CallBig()
        {
            var resoult = await BigAsync("Andrej");
            label1.Text = resoult;
        }

        private Task<string> BigAsync(string name)
        {
            return Task.Factory.StartNew(() => Big(name));
        }

        private string Big(string name)
        {
            Thread.Sleep(2000);
            return "Siema " + name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => Big("Jonny")).ContinueWith(t => label2.Text = t.Result, TaskScheduler.FromCurrentSynchronizationContext());
            label2.Text = "Czekaj...";
        }
    }
}
