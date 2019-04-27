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

namespace GestionDuProduction.PL
{
    public partial class AddNomenclature : Form
    {
        public VegaContext _context = new VegaContext();

        public AddNomenclature()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Nomenclature c = new Nomenclature();
            this.Close();
            c.ShowDialog();
        }

        private void AddNomenclature_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            //populate colors list
            var listCol = (from c in _context.Couleurs
                           select c.Name).ToList();
            foreach (var c in listCol)
            {
                cmbColr.Items.Add(c);
            }

            //populate sequence list
            var listseq = (from q in _context.Sequences
                           select q.Designation).ToList();
            foreach (var q in listseq)
            {
                cmbSeq.Items.Add(q);
            }

            //populate Composant list
            var listComp = (from t in _context.Composants
                            where t.ID !=1
                            select t.Designation).ToList();
            foreach (var t in listComp)
            {
                cmbComp.Items.Add(t);
            }

            //populate nemenclature list datagridview
            var n = (from t in _context.Nomenclatures
                     join c in _context.Couleurs on t.ColorId equals c.ID
                     select new
                     {
                         t.ID,
                         t.Designation,
                         Couleur = c.Name,
                         Cond = t.Conditionnement,
                         t.NormeRef
                     }).ToList();

            dgvNemc.DataSource = n;
            dgvNemc.Columns[3].Width = 65;
            dgvNemc.Columns[2].Width = 65;
            dgvNemc.Columns[1].Width = 100;
            dgvNemc.Columns[0].Width = 30;

            //Initialize Sec Comp datagridview
            var d = Convert.ToInt32(dgvNemc.CurrentRow.Cells[0].Value.ToString());
            var cs = (from ns in _context.NomenclatureSequenceses
                      join c in _context.Composants on ns.ComposantId equals c.ID
                      join s in _context.Sequences on ns.SequenceId equals s.ID
                      where ns.NomenclatureID == d
                      select new
                      {
                          Sequence = s.Designation,
                          Composant = c.Designation,
                      }).ToList();
            dgvSeCo.DataSource = cs;
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

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Nomenclature c = new Nomenclature();
            this.Close();
            c.ShowDialog();
        }

        private void btnAtMat_Click(object sender, EventArgs e)
        {
            //verify and add rows to dgvMaterial
            if (cmbComp.Items.Count == 0
                || cmbSeq.Items.Count == 0)
            {
                MessageBox.Show("Hint : Vous devez Ajouter des Composants et Sequences ",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbSeq.selectedIndex == -1 || cmbComp.selectedIndex == -1 /* || txtConsoKm.Text == ""*/)
            {
                MessageBox.Show("Hint : Verifier que vous avez selectionez les materiels a" +
                                " partir de deux liste et le consomation pour chaque matier",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    int m = 0;
                    foreach (DataGridViewRow i in dgvMateriel.Rows)
                    {

                        if (i.Cells[1].Value.ToString() == cmbSeq.selectedValue && i.Cells[3].Value.ToString() == cmbComp.selectedValue)
                        {
                            m++;
                        }
                    }
                    if (m == 0)
                    {
                        if (cmbComp.selectedIndex != 0)
                        {
                            //Add row in dgvMaterial
                            var s = _context.Sequences.Single(q => q.Designation == cmbSeq.selectedValue).ID;
                            var c = _context.Composants.Single(q => q.Designation == cmbComp.selectedValue).ID;
                            dgvMateriel.Rows.Add(s, cmbSeq.selectedValue, c
                                , cmbComp.selectedValue
                                , txtConsoKm.Text);
                            //clear textbox text
                            txtConsoKm.Text = "";
                        }
                        else
                        {
                            var s = _context.Sequences.Single(q => q.Designation == cmbSeq.selectedValue).ID;
                            var c = _context.Composants.Single(q => q.Designation == cmbComp.selectedValue).ID;
                            dgvMateriel.Rows.Add(s, cmbSeq.selectedValue, c
                                , cmbComp.selectedValue
                                , "0");
                            //clear textbox text
                            txtConsoKm.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vous ne pouvez pas ajouter le meme composant et sequence ", "Attention",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCond.Text != null && txtDsg.Text != null && txtNrR.Text != null && cmbColr.selectedIndex != -1)
                {
                    var v = (from t in _context.Nomenclatures
                             join n in _context.Couleurs on t.ColorId equals n.ID
                             where t.Designation == txtDsg.Text
                                   && n.Name == cmbColr.selectedValue.ToString()
                                   && t.Conditionnement == txtCond.Text
                             select t).Count();
                    if (v == 0)
                    {

                        var a = _context.Couleurs.Single(c => c.Name == cmbColr.selectedValue).ID;
                        var n = _context.Nomenclatures.Add(new BL.Domain.Nomenclature
                        {
                            Designation = txtDsg.Text,
                            NormeRef = txtNrR.Text,
                            Conditionnement = txtCond.Text,
                            ColorId = a
                        });


                        //for (int i = 0; dgvMateriel.Rows.Count < i; i++)//dgvMateriel.Rows[i]
                        //{
                        foreach (DataGridViewRow i in dgvMateriel.Rows)
                        {


                            _context.NomenclatureSequenceses.Add(new NomenclatureSequences
                            {
                                Nomenclature = n,
                                SequenceId = Convert.ToInt32(i.Cells[0].Value.ToString()),
                                ComposantId = Convert.ToInt32(i.Cells[2].Value.ToString()),
                                Mass = Convert.ToSingle(i.Cells[4].Value.ToString()),
                            });
                            _context.SaveChanges();
                        }
                        MessageBox.Show("Nomenclature ajouter avec Succee", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //populate nemenclature list datagridview
                        var q = (from t in _context.Nomenclatures
                                 join c in _context.Couleurs on t.ColorId equals c.ID
                                 select new
                                 {
                                     t.ID,
                                     t.Designation,
                                     Couleur = c.Name,
                                     Cond = t.Conditionnement,
                                     t.NormeRef
                                 }).ToList();

                        dgvNemc.DataSource = q;
                        dgvNemc.Columns[3].Width = 65;
                        dgvNemc.Columns[2].Width = 65;
                        dgvNemc.Columns[1].Width = 100;
                        dgvNemc.Columns[0].Width = 30;

                        //Clear Data
                        cmbColr.selectedIndex = -1;
                        cmbColr.selectedIndex = -1;
                        cmbSeq.selectedIndex = -1;
                        dgvMateriel.Rows.Clear();
                        txtConsoKm.Text = "";
                        txtCond.Text = "";
                        txtDsg.Text = "";
                        txtNrR.Text = "";
                        //} 
                    }
                    else
                    {
                        MessageBox.Show("Element deja existant vous pouvez lancez une rechrche "
                            , "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Veillez verifier que tous les case sont rempli", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void dgvNemc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //bind data to Sequence Composant datagrid view
            var d = Convert.ToInt32(dgvNemc.CurrentRow.Cells[0].Value.ToString());
            var cs = (from ns in _context.NomenclatureSequenceses
                      join c in _context.Composants on ns.ComposantId equals c.ID
                      join s in _context.Sequences on ns.SequenceId equals s.ID
                      where ns.NomenclatureID == d
                      select new
                      {
                          Sequence = s.Designation,
                          Composant = c.Designation,
                      }).ToList();
            dgvSeCo.DataSource = cs;
        }

        private void txtSrchNom_TextChange(object sender, EventArgs e)
        {
            var q = (from t in _context.Nomenclatures
                     join c in _context.Couleurs on t.ColorId equals c.ID
                     where t.Designation.Contains(txtSrchNom.Text)
                     || t.NormeRef.Contains(txtSrchNom.Text)
                     || c.Name.Contains(txtSrchNom.Text)
                     || t.Conditionnement.Contains(txtSrchNom.Text)
                     select new
                     {
                         t.ID,
                         t.Designation,
                        Couleur = c.Name,
                         Cond = t.Conditionnement,
                         t.NormeRef
                     }).ToList();

            dgvNemc.DataSource = q;
            dgvNemc.Columns[3].Width = 65;
            dgvNemc.Columns[2].Width = 65;
            dgvNemc.Columns[1].Width = 100;
            dgvNemc.Columns[0].Width = 30;
        }

        private void txtSrchSeCo_TextChange(object sender, EventArgs e)
        {
            try
            {
                var rwcnt = dgvNemc.RowCount;
                if (rwcnt != 0)
                {
                    var d = Convert.ToInt32(dgvNemc.CurrentRow.Cells[0].Value.ToString());
                    var cs = (from ns in _context.NomenclatureSequenceses
                              join c in _context.Composants on ns.ComposantId equals c.ID
                              join s in _context.Sequences on ns.SequenceId equals s.ID
                              where ns.NomenclatureID == d
                              && c.Designation.Contains(txtSrchSeCo.Text)
                              && s.Designation.Contains(txtSrchSeCo.Text)
                              select new
                              {
                                  Composant = c.Designation,
                                  Sequence = s.Designation
                              }).ToList();
                    dgvSeCo.DataSource = cs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            if (dgvNemc.Rows.Count > 0)
            {
                try
                {
                    DialogResult result = MessageBox.Show("voulez vous vraiment supprimez le nomenclature"
                                     + dgvNemc.CurrentRow.Cells[1].Value.ToString(),
                        "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var c = Convert.ToInt32(dgvNemc.CurrentRow.Cells[0].Value.ToString());
                        var nmcl = _context.Nomenclatures.Find(c);
                        _context.Nomenclatures.Remove(nmcl);
                        _context.SaveChanges();
                    }

                    //populate nemenclature list datagridview
                    var n = (from t in _context.Nomenclatures
                             join c in _context.Couleurs on t.ColorId equals c.ID
                             select new
                             {
                                 t.ID,
                                 t.Designation,
                                 Couleur = c.Name,
                                 Cond = t.Conditionnement,
                                 t.NormeRef
                             }).ToList();

                    dgvNemc.DataSource = n;
                    dgvNemc.Columns[3].Width = 65;
                    dgvNemc.Columns[2].Width = 65;
                    dgvNemc.Columns[1].Width = 100;
                    dgvNemc.Columns[0].Width = 30;

                    //populate seq com list datagridview
                    var rwcnt = dgvNemc.RowCount;
                    if (rwcnt != 0)
                    {
                        var d = Convert.ToInt32(dgvNemc.CurrentRow.Cells[0].Value.ToString());
                        var cs = (from ns in _context.NomenclatureSequenceses
                                  join c in _context.Composants on ns.ComposantId equals c.ID
                                  join s in _context.Sequences on ns.SequenceId equals s.ID
                                  where ns.NomenclatureID == d
                                  select new
                                  {
                                      Composant = c.Designation,
                                      Sequence = s.Designation
                                  }).ToList();
                        dgvSeCo.DataSource = cs;
                    }
                    else
                    {
                        dgvSeCo.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Il Exist aucun Nomenclature a supprimer", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtConsoKm_KeyPress(object sender, KeyPressEventArgs e)
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
