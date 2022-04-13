using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Glinatimer : Form
    {
        public Glinatimer()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan timer = DateTime.Now - StartDate;
            label1.Text = timer.ToString();
        }
        private void RepaintRequired()
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        bool timer = false;
        bool timerReset = false;
        private DateTime StartDate;
        private TimeSpan TimeRealTime;

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer)
            {
                timer1.Stop();
                timer = false;
            }
            else 
            {
                timer1.Start();
                timer = true;
                TimeRealTime = DateTime.Now - StartDate;
                StartDate.Add(TimeRealTime);
            }
            if (timerReset == false)
            {
                StartDate = DateTime.Now;
                timerReset = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer = false;
            StartDate = new DateTime(default);
            RepaintRequired();
        }
    }
}
