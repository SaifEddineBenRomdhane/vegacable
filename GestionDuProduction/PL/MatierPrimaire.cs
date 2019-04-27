using GestionDuProduction.DAL;
using GestionDuProduction.DAL.Repositories;
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
using System.Data.Entity.Core.Objects;

namespace GestionDuProduction.PL
{
    public partial class MatierPrimaire : Form
    {
        public VegaContext _context = new VegaContext();

        public MatierPrimaire()
        {
            InitializeComponent();
        }

        private void MatierPrimaire_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            var Usergroup = (from m in _context.MatierePrimaires
                join k in _context.Composants on m.ComposantID equals k.ID
                join u in _context.Utilisateurs on m.useId equals u.ID
                select new
                {
                    ID = m.ID,
                    Matricule = m.Matricule,
                    Designation = k.Designation,
                    Lot = m.Lot,
                    Mass = m.Mass,
                    Status = m.Etat,
                    ImpDate = DbFunctions.TruncateTime(m.ImpDate),
                    CreatedBy = u.Nom,
                    UpDate = DbFunctions.TruncateTime(m.UpDate)
                }).ToList();
            dgvMtr.DataSource = Usergroup;
            this.dgvMtr.Columns[0].Width = 20;
            this.dgvMtr.Columns[2].Width = 100;
            this.dgvMtr.Columns[4].Width = 45;
            this.dgvMtr.Columns[5].Width = 45;


            var glist = (from t in _context.Composants
                where t.ID != 1
                select t.Designation).ToList();
            foreach (object t in glist)
            {
                cmbCmp.Items.Add(t);
            }
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
            //Form m = new Main();
            //m.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Form m = new Main();
            //m.Show();
            this.Close();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var id = Convert.ToInt32(dgvMtr.CurrentRow.Cells[0].Value.ToString());
            ////var CompIDs = (_context.Composants.Take(rank).OrderByDescending(c => c.ID)
            ////    .Select(c => c.ID)).ToList();
            var mat = _context.MatierePrimaires.Find(Convert.ToInt16(dgvMtr.CurrentRow.Cells[0].Value.ToString()));
            var Init = _context.Composants.Where(c => c.ID != 1).First().ID;
            //var com = _context.Composants.Find(mat.ID).Designation;
            txtMat.Text = dgvMtr.CurrentRow.Cells[1].Value.ToString();
            txtMass.Text = dgvMtr.CurrentRow.Cells[4].Value.ToString();
            txtLot.Text = dgvMtr.CurrentRow.Cells[3].Value.ToString();
            cmbCmp.selectedIndex = mat.ComposantID - Init;
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            if (txtMat.Text == "")
            {
                MessageBox.Show("Veuillez selectioner le matier primaire a modifier", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                var a = _context.Composants.Single(c => c.Designation == cmbCmp.selectedValue).ID;
                var mat = _context.MatierePrimaires.Find(Convert.ToInt16(dgvMtr.CurrentRow.Cells[0].Value.ToString()));

                mat.Matricule = txtMat.Text;
                mat.Mass = Convert.ToSingle(txtMass.Text);
                mat.Lot = txtLot.Text;
                mat.Etat = MatierePrimaire.status.Dispo;
                mat.ComposantID = /*cmbCmp.selectedIndex + 1*/a;
                mat.UpDate = DateTime.Today;
                mat.useId = Convert.ToInt32(Main.id);

                _context.SaveChanges();

                var Usergroup = (from m in _context.MatierePrimaires
                                 join k in _context.Composants on m.ComposantID equals k.ID
                                 join u in _context.Utilisateurs on m.useId equals u.ID
                                 select new
                                 {
                                     ID = m.ID,
                                     Matricule = m.Matricule,
                                     Designation = k.Designation,
                                     Lot = m.Lot,
                                     Mass = m.Mass,
                                     Status = m.Etat,
                                     ImpDate = DbFunctions.TruncateTime(m.ImpDate),
                                     CreatedBy = u.Nom,
                                     UpDate = DbFunctions.TruncateTime(m.UpDate)
                                 }).ToList();
                dgvMtr.DataSource = Usergroup;
                this.dgvMtr.Columns[0].Width = 20;
                this.dgvMtr.Columns[2].Width = 100;
                this.dgvMtr.Columns[4].Width = 45;
                this.dgvMtr.Columns[5].Width = 45;
            }
        }

        private void btnAjt_Click(object sender, EventArgs e)
        {
            if (txtLot != null && txtMat != null && txtMass !=null && cmbCmp.selectedIndex != -1)
            {
                var v = (from t in _context.MatierePrimaires
                         join n in _context.Composants on t.ComposantID equals n.ID
                         where t.Lot == txtLot.Text
                               && n.Designation == cmbCmp.selectedValue.ToString()
                               && t.Matricule == txtMat.Text
                               && t.UpDate == DateTime.Today
                               //|| t.UpDate == DateTime.Today
                         select t).Count();
                if (v == 0)
                {
                    var a = _context.Composants.Single(c => c.Designation == cmbCmp.selectedValue).ID;
                    _context.MatierePrimaires.Add(new MatierePrimaire
                    {
                        Matricule = txtMat.Text,
                        Mass = Convert.ToSingle(txtMass.Text),
                        Lot = txtLot.Text,
                        ComposantID = a,
                        Etat = 0,
                        ImpDate = DateTime.Today,
                        useId = Convert.ToInt32(Main.id),
                        UpDate = DateTime.Today
                    });

                    _context.SaveChanges();


                    var Usergroup = (from m in _context.MatierePrimaires
                                     join k in _context.Composants on m.ComposantID equals k.ID
                                     join u in _context.Utilisateurs on m.useId equals u.ID
                                     select new
                                     {
                                         ID = m.ID,
                                         Matricule = m.Matricule,
                                         Designation = k.Designation,
                                         Lot = m.Lot,
                                         Mass = m.Mass,
                                         Status = m.Etat,
                                         ImpDate = DbFunctions.TruncateTime(m.ImpDate),
                                         CreatedBy = u.Nom,
                                         UpDate = DbFunctions.TruncateTime(m.UpDate)
                                     }).ToList();
                    dgvMtr.DataSource = Usergroup;
                    this.dgvMtr.Columns[0].Width = 20;
                    this.dgvMtr.Columns[2].Width = 100;
                    this.dgvMtr.Columns[4].Width = 45;
                    this.dgvMtr.Columns[5].Width = 45;
                }
                else
                {
                    MessageBox.Show("Un element similaire deja exist", "Attention", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                } 
            }
            else
            {
                MessageBox.Show("Veuillez premplir tous les champs", "Attention", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            var matches = (from m in _context.MatierePrimaires
                join k in _context.Composants on m.ComposantID equals k.ID
                join u in _context.Utilisateurs on m.useId equals u.ID 
                where m.Matricule.Contains(txtSearch.Text)
                      || m.Mass.ToString().Contains(txtSearch.Text)
                      || m.Lot.Contains(txtSearch.Text)
                      || m.ID.ToString().Contains(txtSearch.Text)
                      || k.Designation.Contains(txtSearch.Text)
            select new
                {
                    ID = m.ID,
                    Matricule = m.Matricule,
                    Designation = k.Designation,
                    Lot = m.Lot,
                    Mass = m.Mass,
                    Status = m.Etat,
                    ImpDate = DbFunctions.TruncateTime(m.ImpDate),
                    CreatedBy = u.Nom,
                    UpDate = DbFunctions.TruncateTime(m.UpDate)
                }).ToList();
            dgvMtr.DataSource = matches;
            this.dgvMtr.Columns[0].Width = 20;
            this.dgvMtr.Columns[2].Width = 100;
            this.dgvMtr.Columns[4].Width = 45;
            this.dgvMtr.Columns[5].Width = 45;
        }

        private void txtMass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                                           && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
