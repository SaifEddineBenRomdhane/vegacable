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
    public partial class AddOrdreFabrication : Form
    {
        private static int m = 0;
        private static string st;
        public VegaContext _context = new VegaContext();

        public AddOrdreFabrication()
        {
            InitializeComponent();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddOrdreFabrication_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            try
            {
                var of = (from t in _context.OrdreFabrications
                          join v in _context.Nomenclatures on t.NomenclatureID equals v.ID
                          select new
                          {
                              t.ID,
                              v.Designation,
                              Longueur = t.Lonngeur,
                              t.Status,
                              t.DateLancer
                          }).ToList();
                dgvOF.DataSource = of;
                dgvOF.Columns[0].Width = 30;

                //populate desig list
                var glist = (from t in _context.Nomenclatures
                             select t.Designation).ToList();
                foreach (object t in glist)
                {
                    cmbDsg.Items.Add(t);
                }
                dgvComp.Columns[0].Width = 90;
                dgvComp.Columns[1].Width = 123;
                dgvComp.Columns[2].Width = 107;

                //first get Ordre fabrication Id
                var OF = _context.OrdreFabrications.Find(Convert.ToInt32(dgvOF.CurrentRow.Cells[0].Value.ToString()));
                //Get the sequence list 

                var SeqList = (from t in _context.NomenclatureSequenceses
                    where t.NomenclatureID == OF.NomenclatureID
                    join l in _context.Sequences on t.SequenceId equals l.ID
                    group l by l.Designation into g
                        select new { Sequence = g.Key}
                        ).ToList();
                dgvSeq.DataSource = SeqList;

                //get the "Matricule utilesee" for a  certain Ordre Fabrication
                var idof = Convert.ToInt32(dgvOF.CurrentRow.Cells[0].Value.ToString());
                var n = (from t in _context.MPUtilisers
                    where t.OFID == idof
                    join k in _context.MatierePrimaires on t.MPID equals k.ID
                    group k by k.Matricule into g
                    select new { MatriculeMP = g.Key }).ToList();
                dgvMMPU.DataSource = n;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjt_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvComp.Rows)
            {
                if (Convert.ToInt32(row.Cells[2].Value.ToString()) > Convert.ToInt32(row.Cells[3].Value.ToString()))
                {
                    m++;
                    st = row.Cells[0].Value.ToString() + ", " + st;
                }
            }
            if (m == 0)
            {
                try
                {
                    //first get the nomenclature ID by adding 1 to selected index
                    //value which represent its Rank in DB then use take(Rank) method and order by decendent then take the first 1 
                    var rank = cmbDsg.selectedIndex + 1;
                    var NomclaID = _context.Nomenclatures.Take(rank).OrderByDescending(c => c.ID).First().ID;
                    var length = Convert.ToSingle(txtLength.Text);

                    //set the var that takes extension method to add OF
                    var OF = _context.OrdreFabrications.Add(new OrdreFabrication
                    {
                        NomenclatureID = NomclaID,
                        Lonngeur = length,
                        Status = OrdreFabrication.Etat.Lances,
                        DateLancer = DateTime.Today,
                        DateCloture = DateTime.Today,
                    });


                    foreach (DataGridViewRow r in dgvComp.Rows)
                    {

                        //then the needed composant mass
                        var totalMassNeeded = Convert.ToSingle(r.Cells[2].Value.ToString());
                        var composantName = r.Cells[0].Value.ToString();
                        //then get the "matier primaire" which is ordred by mass and AVAILABLE
                        var l = _context.MatierePrimaires.Where(c => c.Etat == MatierePrimaire.status.Dispo 
                                                                     ||c.Etat == MatierePrimaire.status.Resrv
                                                                     &&c.Mass > c.RestMass
                                                                     && c.Composant.Designation == composantName)
                                                                    .OrderBy(c => c.Mass).ToList();


                       
                            int i = 0;
                            if (totalMassNeeded >= l[i].Mass)
                            {
                                _context.MPUtilisers.Add(new MPUtiliser
                                {
                                    OrdreFabrication = OF,
                                    MPID = l[i].ID,
                                });

                                var c = _context.MatierePrimaires.Find(l[i].ID);
                                c.Etat = MatierePrimaire.status.Resrv;
                                c.RestMass = 0;
                                _context.SaveChanges();
                                i++;
                            }
                            else if (totalMassNeeded < l[i].Mass && totalMassNeeded > 0)
                            {
                                var rest = l[i].Mass - totalMassNeeded;
                                _context.MPUtilisers.Add(new MPUtiliser
                                {
                                    OrdreFabrication = OF,
                                    MPID = l[i].ID,
                                });

                                var c = _context.MatierePrimaires.Find(l[i].ID);
                                c.Etat = MatierePrimaire.status.Resrv;
                                c.RestMass = c.Mass - totalMassNeeded;
                                _context.SaveChanges();
                            }

                            totalMassNeeded = totalMassNeeded - l[i].Mass; 
                        }

                    


                    //refrech dgvOF
                    var of = (from t in _context.OrdreFabrications
                              join var in _context.Nomenclatures on t.NomenclatureID equals var.ID
                              select new
                              {
                                  t.ID,
                                  var.Designation,
                                  Longueur = t.Lonngeur,
                                  t.Status,
                                  t.DateLancer
                              }).ToList();
                    dgvOF.DataSource = of;
                    dgvOF.Columns[0].Width = 30;

                    MessageBox.Show("L'ajout de l'ordre de fabrication a ete effectuer avec", "Succes"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                MessageBox.Show("Les Composants " + st + " ne sont pas " +
                                "suffisant pour lancer cette OF,Veillez " +
                                "Consuter votre stock de matiere primaire", "Attention"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                st = "";
            }

        }

        private void btnCltr_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvOF.CurrentRow.Cells[0].Value.ToString());
            var c = _context.OrdreFabrications.Find(id);
            if (c.Status == OrdreFabrication.Etat.Cloture)
            {
                MessageBox.Show("l'ordre de fabrication et deja cloture", "echoue"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult v = MessageBox.Show("Voulez Vous Vraiment Cloture cette ordre de fabrication", "Attention"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (v == DialogResult.Yes)
                {
                    c.Status = OrdreFabrication.Etat.Cloture;
                    var a = _context.MPUtilisers.Where(mpu => mpu.OFID == id).ToList();
                    foreach (var j in a)
                    {
                        var k = _context.MatierePrimaires.Find(j.MPID);
                        k.Mass =  k.RestMass;
                        k.RestMass = 0;
                        k.Etat = MatierePrimaire.status.Dispo;
                    }

                    ////get the sequence list 
                    //var SeqList = (from t in _context.NomenclatureSequenceses
                    //        where t.NomenclatureID == c.NomenclatureID
                    //        join l in _context.Sequences on t.SequenceId equals l.ID
                    //        group l by l.Designation
                    //        into g
                    //        select new {Sequence = g.Key,}
                    //    ).ToList();

                    //foreach (var m in SeqList)
                    //{
                    //    _context.SuiviAvancement.Add(new SuiviAvancementOF
                    //    {
                    //        OrdreFabrication = c,
                    //        SeqID = m.Sequence,

                    //    }); 
                    //}
                    _context.SaveChanges();

                }
                //refrech dgvOF
                var of = (from t in _context.OrdreFabrications
                          join var in _context.Nomenclatures on t.NomenclatureID equals var.ID
                          select new
                          {
                              t.ID,
                              var.Designation,
                              Longueur = t.Lonngeur,
                              t.Status,
                              t.DateLancer
                          }).ToList();
                dgvOF.DataSource = of;
                dgvOF.Columns[0].Width = 30;
            }
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            if (dgvOF.Rows.Count > 0)
            {
                var id = Convert.ToInt32(dgvOF.CurrentRow.Cells[0].Value.ToString());
                var c = _context.OrdreFabrications.Find(id);
                if (c.Status != OrdreFabrication.Etat.Cloture)
                {
                    DialogResult v = MessageBox.Show("Voulez Vous Supprimer cette ordre de fabrication", "Attention"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (v == DialogResult.Yes)
                    {
                        _context.OrdreFabrications.Remove(c);
                        _context.SaveChanges();
                    }
                    var of = (from t in _context.OrdreFabrications
                              join var in _context.Nomenclatures on t.NomenclatureID equals var.ID
                              select new
                              {
                                  t.ID,
                                  var.Designation,
                                  Longueur = t.Lonngeur,
                                  t.Status,
                                  t.DateLancer
                              }).ToList();
                    dgvOF.DataSource = of;
                    dgvOF.Columns[0].Width = 30;
                }
                else
                {
                    MessageBox.Show("L'operation est echoue car cette Oredre de Fabrication Deja Cloture", "Attention"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("L'operation est echoue car il y a aucun OF a Supprimer ", "Attention"
                    , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            var of = (from t in _context.OrdreFabrications
                      join v in _context.Nomenclatures on t.NomenclatureID equals v.ID
                      where t.ID.ToString().Contains(txtSearch.Text)
                      || v.Designation.Contains(txtSearch.Text)
                      || t.Lonngeur.ToString().Contains(txtSearch.Text)
                      || t.Status.ToString().Contains(txtSearch.Text)
                      || t.DateLancer.ToString().Contains(txtSearch.Text)
                      select new
                      {
                          t.ID,
                          v.Designation,
                          Longueur = t.Lonngeur,
                          t.Status,
                          t.DateLancer
                      }).ToList();
            dgvOF.DataSource = of;
            dgvOF.Columns[0].Width = 30;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvComp.Rows.Clear();
            try
            {

                if (cmbDsg.selectedIndex == -1 || txtLength.Text == "")
                {
                    MessageBox.Show("Veuillez Ajouter une designation et la longeure", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //get nomclature ID
                    //first get its rank from combox then pass it to take() method
                    var rank = cmbDsg.selectedIndex + 1;
                    var NomenclaIDs = (_context.Nomenclatures.Take(rank).OrderByDescending(c => c.ID)
                        .Select(c => c.ID)).ToList();

                    var NomenclaID = Convert.ToInt32(NomenclaIDs[0]);
                    //then group by compposants and calculate mass
                    var listcomp = (from c in _context.NomenclatureSequenceses
                                    join n in _context.Composants on c.ComposantId equals n.ID
                                    where c.NomenclatureID == NomenclaID
                                    group c by n.Designation into g
                                    select new
                                    {
                                        Composant = g.Key,
                                        MassTotale = g.Sum(c => c.Mass),
                                    }).ToList();
                    var listMP = (from c in _context.Composants
                                  join m in _context.MatierePrimaires on c.ID equals m.ComposantID
                                  //where c.ID  ==NomenclaID
                                  group m by c.Designation into g
                                  select new
                                  {
                                      Composant = g.Key,
                                      MassTotaleDispo = g.Sum(c => c.Mass),
                                  }
                            ).ToList();

                    //popuate dgvComp with data
                    foreach (var t in listcomp)
                    {
                        foreach (var c in listMP)
                        {
                            var MPComposant = t.MassTotale * Convert.ToSingle(txtLength.Text);
                            var MPrimaire = c.MassTotaleDispo;
                            if (t.Composant == c.Composant)
                            {
                                dgvComp.Rows.Add(t.Composant, t.MassTotale, MPComposant, MPrimaire);
                                if (t.MassTotale > c.MassTotaleDispo)
                                {
                                    MessageBox.Show("Le composant " + t.Composant
                                                                   + " est insuffisant pour lancer cette OF", "Attention"
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                }
                            }
                        }
                    }


                    dgvComp.Columns[0].Width = 90;
                    dgvComp.Columns[1].Width = 123;
                    dgvComp.Columns[2].Width = 107;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOF_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvSeq.Rows.Clear();
            //dgvMMPU.Rows.Clear();
            //first get Ordre fabrication Id
            var id = Convert.ToInt32(dgvOF.CurrentRow.Cells[0].Value.ToString());

            var OF = _context.OrdreFabrications.Find(id);
            ////Get the sequence list 

            var SeqList = (from t in _context.NomenclatureSequenceses
                    where t.NomenclatureID == OF.NomenclatureID
                    join l in _context.Sequences on t.SequenceId equals l.ID
                    group l by l.Designation into g
                    select new {  Sequence = g.Key }
                ).ToList();
            dgvSeq.DataSource = SeqList;

            var n = (from t in _context.MPUtilisers
                where t.OFID == id
                join k in _context.MatierePrimaires on t.MPID equals k.ID 
                group k by k.Matricule into g
                select new {MatriculeMP = g.Key}).ToList();
            dgvMMPU.DataSource = n;
        }

        private void btnAncm_Click(object sender, EventArgs e)
        {
            SuiviOF f = new SuiviOF();
            f.ShowDialog();
        }
    }
}
