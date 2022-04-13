using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        private DateTime startTime;
        private DateTime pauseTime;
        private TimerState state;

        public MainForm()
        {
            InitializeComponent();
            state = TimerState.Stopped;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (state == TimerState.Stopped)
            {
                startTime = DateTime.Now;
                timer.Start();
                btnStart.Text = "Пауза";
                state = TimerState.Running;
            }
            else if (state == TimerState.Running)
            {
                timer.Stop();
                pauseTime = DateTime.Now;
                btnStart.Text = "Продолжить";
                state = TimerState.Paused;
            }
            else if (state == TimerState.Paused)
            {
                startTime = startTime.Add(DateTime.Now - pauseTime);
                timer.Start();
                btnStart.Text = "Пауза";
                state = TimerState.Running;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan duration = DateTime.Now - startTime;
            lblTime.Text = duration.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btnStart.Text = "Старт";
            state = TimerState.Stopped;
        }
    }
}
