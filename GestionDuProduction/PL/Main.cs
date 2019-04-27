using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDuProduction.DAL;
using GestionDuProduction.PL;

namespace GestionDuProduction
{
    public partial class Main : Form
    {
        public VegaContext _context = new VegaContext();
        public static string id = "";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);
            id = lblId.Text;
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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            User m = new User();
            m.ShowDialog();
            //this.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            AddOrdreFabrication m = new AddOrdreFabrication();
            m.ShowDialog();
            //this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Nomenclature m = new Nomenclature();
            m.ShowDialog();
            //this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            MatierPrimaire m = new MatierPrimaire();
            m.ShowDialog();
            //this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            UserGroup m = new UserGroup();
            m.ShowDialog();
            //this.Hide();
        }

        private void btnDecnx_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Voulez Vous Fermer L'application Definitivement","Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    Form m = new Login();
                    this.Close();
                    m.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
