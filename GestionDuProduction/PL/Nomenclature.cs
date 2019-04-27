using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDuProduction.Migrations;
using GestionDuProduction.PL;

namespace GestionDuProduction
{
    public partial class Nomenclature : Form
    {
        public Nomenclature()
        {
            InitializeComponent();
        }

        private void Nomenclature_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //Main m = new Main();
            //m.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Main m = new Main();
            //m.Show();
            this.Close();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Form m = new AddNomenclature();
            m.Show();
            this.Close();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            AddComposant c = new AddComposant();
            c.Show();
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            AddSequence c = new AddSequence();
            c.Show();
            this.Close();
        }
    }
}
