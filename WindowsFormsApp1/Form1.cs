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
        private int mls;
        private int sec;
        private int min;
        private int hour;


        private void timer1_Tick(object sender, EventArgs e)
        {
            mls++;
            if (mls >= 10)
            {
                sec++;
                mls = 0;
                if (sec >= 60)
                {
                    sec = 0;
                    min++;
                    if (min >= 60)
                    {
                        hour++;
                        min = 0;
                        sec = 0;
                    }
                }
            }
            RepaintRequired();
        }
        private void RepaintRequired()
        {
            Invalidate();
        }

        private void Painter(Graphics g)
        {
            string mlsS = mls.ToString().PadLeft(2, '0');
            string hourS = hour.ToString().PadLeft(2, '0');
            string secS = sec.ToString().PadLeft(2, '0');
            string minS = min.ToString().PadLeft(2, '0');
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (var f = new Font("Segoe UI", 75))
            {
                g.DrawString($"{hourS}:{minS}:{secS}", f, Brushes.Black, new PointF(30, 30));
            }
            using (var f = new Font("Segoe UI", 15))
            {
                g.DrawString($"{mlsS}", f, Brushes.Black, new PointF(380, 140));
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            Painter(g);
        }

        bool timer = false;
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
            }
            RepaintRequired();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mls = 0;
            sec = 0;
            min = 0;
            hour = 0;
            timer1.Stop();
            timer = false;
            RepaintRequired();
        }
    }
}
