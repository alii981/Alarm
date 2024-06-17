using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarm
{
    public partial class Form1 : Form
    {
        private DateTime alarmTime;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Waiting for alarm to start";
            label1.Visible = false;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (alarmTime > DateTime.Now)
            {
                TimeSpan timeRemaining = alarmTime - DateTime.Now;
                label2.Text = timeRemaining.ToString(@"hh\:mm\:ss");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            alarmTime = dateTimePicker1.Value;
            if (alarmTime > DateTime.Now)
            {
                label1.Text = "Alarm set for " + alarmTime;
                timer1.Start();
            }
            else
            {
                label1.Text = "Alarm can t be set for an older time";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Alarm stopped";
            label2.Text = "Waiting for alarm to start";
            timer1.Stop();
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
