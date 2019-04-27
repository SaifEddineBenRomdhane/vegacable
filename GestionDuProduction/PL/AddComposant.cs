using GestionDuProduction.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.PL
{
    public partial class AddComposant : Form
    {
        private static int exist;
        public VegaContext _context = new VegaContext();

        public AddComposant()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Nomenclature c = new Nomenclature();
            this.Close();
            c.ShowDialog();
            
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Nomenclature c = new Nomenclature();
            this.Close();
            c.ShowDialog();
        }

        private void dgvComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Comp = _context.Composants.Find(Convert.ToInt16(dgvComp.CurrentRow.Cells[0].Value.ToString()));
            lblComp.Text = Comp.Designation;
        }

        private void AddComposant_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);
            this.TopMost = true;

            var Usergroup = (from t in _context.Composants
                where t.ID != 1
                select new
                {
                    t.ID,
                    Composant = t.Designation
                }).ToList();
            dgvComp.DataSource = Usergroup;
            dgvComp.Columns[0].Width = 45;
        }

        private void btnajt_Click(object sender, EventArgs e)
        {
            if (lblComp.Text != "")
            {
                //verify the user Group
                foreach (DataGridViewRow r in dgvComp.Rows)
                {
                    if (r.Cells[1].Value.ToString().ToLower() != dgvComp.Text.ToLower())
                    {
                        exist = 0;
                    }
                    else
                    {
                        exist ++;
                        MessageBox.Show("Nom de Composant Deja Utiliser ", "Atenttion", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //Clear Text In txtUName textbox
                        dgvComp.Text = "";
                    }
                }
                if (exist == 0)
                {
                    _context.Composants.Add(new Composant
                    {
                        Designation = lblComp.Text
                    });

                    _context.SaveChanges();
                } 
            }
            else
            {
                MessageBox.Show("Veillez entre un nom", "Attenttion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var Usergroup = (from t in _context.Composants
                where t.ID != 1
                select new
                {
                    t.ID,
                    Composant = t.Designation
                }).ToList();
            dgvComp.DataSource = Usergroup;
            dgvComp.Columns[0].Width = 45;
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvComp.Rows)
            {
                if (r.Cells[1].Value.ToString().ToLower() != dgvComp.Text.ToLower())
                {
                    exist = 0;
                }
                else
                {
                    exist ++;
                    MessageBox.Show("Nom de Composant Deja Utiliser ", "Atenttion", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Clear Text In txtUName textbox
                    dgvComp.Text = "";
                }
            }
            if (exist == 0)
            {
                var Comp = _context.Composants.Find(Convert.ToInt16(dgvComp.CurrentRow.Cells[0].Value.ToString()));
                Comp.Designation = lblComp.Text;

                _context.SaveChanges(); 
            }

            var Usergroup = (from t in _context.Composants
                where t.ID != 1
                select new
                {
                    t.ID,
                    Composant = t.Designation
                }).ToList();
            dgvComp.DataSource = Usergroup;
            dgvComp.Columns[0].Width = 45;
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            if (dgvComp.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("voulez vous vraiment supprimez le composant"
                                                      + dgvComp.CurrentRow.Cells[1].Value.ToString(),
                    "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var Comp = _context.Composants.Find(Convert.ToInt16(dgvComp.CurrentRow.Cells[0].Value.ToString()));
                    _context.Composants.Remove(Comp);

                    _context.SaveChanges();

                    var Usergroup = (from t in _context.Composants
                        where t.ID != 1
                        select new
                        {
                            t.ID,
                            Composant = t.Designation
                        }).ToList();
                    dgvComp.DataSource = Usergroup;
                    dgvComp.Columns[0].Width = 45;
                }
            }
            else
            {
                MessageBox.Show("Il Exist aucun composant a supprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            var search = (from c in _context.Composants
                where c.Designation.Contains(txtSearch.Text) || c.ID.ToString().Contains(txtSearch.Text) && c.ID !=1
                          select new {c.ID ,c.Designation}).ToList();
            dgvComp.DataSource = search;
            dgvComp.Columns[0].Width = 45;
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
