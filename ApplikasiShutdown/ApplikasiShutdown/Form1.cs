using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplikasiShutdown
{
    public partial class Form1 : Form
    {
        int sisa;
        public Form1()
        {
            InitializeComponent();
            timerWaktu.Maximum = 10000;
            timerWaktu.Minimum = 0;
            aturBtn(true);
        }

        void aturBtn(bool st)
        {
            button1.Enabled = st;
            button2.Enabled = st;
            button3.Enabled = st;
            button4.Enabled = st;
            btnStart.Visible = st;
            btnStop.Enabled = !st;
            btnPause.Visible = !st;
            btnResume.Visible = !st;
            timerWaktu.Enabled = st;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            aturBtn(true);
            timerWaktu.Value = 0;
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerWaktu.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerWaktu.Value = 3600;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timerWaktu.Value = 5400;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timerWaktu.Value = 7200;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timerWaktu.Value == 0)
            {
                MessageBox.Show("Nilai waktu tidak boleh 0!!", "Peringatan");
            }
            else
            {
                aturBtn(false);
                btnResume.Visible = false;
                timer1.Start();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sisa = (int)timerWaktu.Value; 
            if(sisa > 0)
            {
                sisa--;
                timerWaktu.Value = sisa;
            }
            else if(sisa == 0)
            {
                System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0 -f");
                timer1.Stop();
                aturBtn(true);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            aturBtn(false);
            btnPause.Visible = false;
            btnResume.Visible = true;
            btnStop.Enabled = true;
            timerWaktu.Value = sisa;
            timer1.Stop();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            aturBtn(false);
            btnResume.Visible = false;
            btnPause.Visible = true;
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timerWaktu.Value = 1800;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.00;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 0.25;
            }
            catch
            {

            }
        }
    }
}
