using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDuProduction.PL
{
    public partial class SuiviOF : Form
    {
        public SuiviOF()
        {
            InitializeComponent();
        }


        private void SuiviOF_Shown(object sender, EventArgs e)
        {
            // Enable the default scrollbars first
            // then get the value(s) required.
            flowLayoutPanel1.AutoScroll = true;

            // Set the vertical scroll maximum value to be at-par with the flowlayout.
            bunifuVScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
            bunifuVScrollBar1.ThumbLength = 100;
            // Now disable the default scrollbars.
            //You can even change the thumb length.
            flowLayoutPanel1.AutoScroll = false;
            
        }

        private void bunifuVScrollBar1_Scroll(object sender, Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs e)
        {
            // This automatically scrolls the flow-layout position based on the scroll value.
            flowLayoutPanel1.AutoScrollPosition = new Point(flowLayoutPanel1.AutoScrollPosition.X, e.Value);

        }

        private void SuiviOF_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            for (int i = 0; i < 10; i++)
            {
                suiviseq myobject = new suiviseq();
                flowLayoutPanel1.Controls.Add(myobject);
                myobject.bunifuCustomLabel1.Text = "d";
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }
    }
}
