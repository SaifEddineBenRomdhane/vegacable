using GestionDuProduction.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDuProduction.BL.Domain;

namespace GestionDuProduction.Migrations
{
    public partial class AddSequence : Form
    {
        private static bool exist;
        public VegaContext _context = new VegaContext();

        public AddSequence()
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

        private void btnajt_Click(object sender, EventArgs e)
        {
            //verify the user Group
            foreach (DataGridViewRow r in dgvSeq.Rows)
            {
                if (r.Cells[1].Value.ToString().ToLower() != txtSeq.Text.ToLower())
                {
                        exist = false;
                }
                else
                {
                    exist = true;
                    MessageBox.Show("Nom de Sequence daja existant ", "Atenttion", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Clear Text In txtUName textbox
                    txtSeq.Text = "";
                }
            }
            if (exist == false)
            {
                _context.Sequences.Add(new Sequence
                {
                    Designation = txtSeq.Text
                });

                _context.SaveChanges();

            }
                var Usergroup = (from t in _context.Sequences
                                 select new
                                 {
                                     t.ID,
                                     Sequences = t.Designation
                                 }).ToList();
                dgvSeq.DataSource = Usergroup;
                dgvSeq.Columns[0].Width = 45; 
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            //verify the user Group
            foreach (DataGridViewRow r in dgvSeq.Rows)
            {
                if (r.Cells[1].Value.ToString().ToLower() != txtSeq.Text.ToLower())
                {
                    exist = false;
                }
                else
                {
                    exist = true;
                    MessageBox.Show("Nom de Sequence daja existant ", "Atenttion", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Clear Text In txtUName textbox
                    txtSeq.Text = "";
                }
            }
            if (exist == false)
            {
                var Seq = _context.Sequences.Find(Convert.ToInt16(dgvSeq.CurrentRow.Cells[0].Value.ToString()));
                Seq.Designation = txtSeq.Text;

                _context.SaveChanges(); 
            }

            var Usergroup = (from t in _context.Sequences
                select new
                {
                    t.ID,
                    Sequences = t.Designation
                }).ToList();
            dgvSeq.DataSource = Usergroup;
            dgvSeq.Columns[0].Width = 45;
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            if (dgvSeq.Rows.Count > 0) 
            {

                DialogResult result = MessageBox.Show("voulez vous vraiment supprimez le sequence"
                                                      + dgvSeq.CurrentRow.Cells[1].Value.ToString(),
                    "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var sep = _context.Sequences.Find(Convert.ToInt16(dgvSeq.CurrentRow.Cells[0].Value.ToString()));
                    _context.Sequences.Remove(sep);

                    _context.SaveChanges();

                    var Usergroup = (from t in _context.Sequences
                                     select new
                                     {
                                         t.ID,
                                         Sequences = t.Designation
                                     }).ToList();
                    dgvSeq.DataSource = Usergroup;
                    dgvSeq.Columns[0].Width = 45;
                } 
            }
            else
            {
                MessageBox.Show("Il Exist aucun sequence a supprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dgvSeq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var Seq = _context.Sequences.Find(Convert.ToInt16(dgvSeq.CurrentRow.Cells[0].Value.ToString()));
            txtSeq.Text = Seq.Designation;
        }

        private void AddSequence_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);
            this.TopMost = true;

            var Usergroup = (from t in _context.Sequences
                select new
                {
                    t.ID,
                    Sequences = t.Designation
                }).ToList();
            dgvSeq.DataSource = Usergroup;
            dgvSeq.Columns[0].Width = 45;
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            var search = (from c in _context.Sequences
                where c.Designation.Contains(txtSearch.Text) || c.ID.ToString().Contains(txtSearch.Text)
                select new { c.ID, c.Designation }).ToList();
            dgvSeq.DataSource = search;
            dgvSeq.Columns[0].Width = 45;
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
