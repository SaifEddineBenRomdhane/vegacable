using GestionDuProduction.DAL;
using GestionDuProduction.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionDuProduction.BL.Domain;
using Utilities.BunifuCheckBox.Transitions;
using Utilities.BunifuImageButton.Transitions;
using Group = GestionDuProduction.BL.Domain.Group;

namespace GestionDuProduction.PL
{
    public partial class UserGroup : Form
    {
        private static int Nexist = 0;
        private static int Pexist = 0;
        public VegaContext _context = new VegaContext();

        public UserGroup()
        {
            InitializeComponent();
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

        private void UserGroup_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            var Usergroup = (from t in _context.Groups
                             where t.ID != 19
                             select new
                             {
                                 t.ID,
                                 Role = t.NomGroup,
                                 Nomcl = t.NomCla.ToString(),
                                 OrdF = t.OrderF.ToString(),
                                 Grp = t.UseG.ToString(),
                                 MtrP = t.MatierP.ToString(),
                                 User = t.User.ToString()
                             }).ToList();
            dgvUserGroup.DataSource = Usergroup;
            dgvUserGroup.Columns[0].Width = 25;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Form m = new Main();
            //m.Show();
            this.Close();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            //Form m = new Main();
            //m.Show();
            this.Close();
        }

        private void btnajt_Click(object sender, EventArgs e)
        {
            if (lblGroup.Text != "")
            {
                //verify the user Group
                foreach (DataGridViewRow r in dgvUserGroup.Rows)
                {
                    if (r.Cells[1].Value.ToString().ToLower() == lblGroup.Text.ToLower())
                    {
                        Nexist++;
                    }
                    else
                    {
                        var c = _context.Groups.Where(d => d.NomCla == P1.Checked
                                                                    && d.OrderF == P2.Checked
                                                                    && d.UseG == P3.Checked
                                                                    && d.MatierP == P4.Checked
                                                                    && d.User == P5.Checked);

                        Pexist = c.Count();
                    }

                }
                if (Nexist == 0 && Pexist == 0)
                {
                    _context.Groups.Add(new Group
                    {
                        NomGroup = lblGroup.Text,
                        NomCla = P1.Checked,
                        OrderF = P2.Checked,
                        UseG = P3.Checked,
                        MatierP = P4.Checked,
                        User = P5.Checked
                    });

                    _context.SaveChanges();

                    var Usergroup = (from t in _context.Groups
                                     where t.ID != 19
                                     select new
                                     {
                                         t.ID,
                                         Role = t.NomGroup,
                                         Nomcl = t.NomCla.ToString(),
                                         OrdF = t.OrderF.ToString(),
                                         Grp = t.UseG.ToString(),
                                         MtrP = t.MatierP.ToString(),
                                         User = t.User.ToString()
                                     }).ToList();
                    dgvUserGroup.DataSource = Usergroup;
                    dgvUserGroup.Columns[0].Width = 25;
                }
                if (Nexist != 0)
                {
                    MessageBox.Show("Cet Nom de Group d'utilisateur Deja exist ", "Atenttion", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Clear Text In txtUName textbox
                    lblGroup.Text = "";
                }
                else if (Pexist != 0)
                {

                    MessageBox.Show("Un Group Utilisateur ayant les meme droit deja exist", "Atenttion", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veillez entre un nom", "Attenttion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            if (lblGroup.Text != "")
            {
                //verify the user Group
                foreach (DataGridViewRow r in dgvUserGroup.Rows)
                {

                    if (r.Cells[1].Value.ToString().ToLower() == lblGroup.Text.ToLower())
                    {
                        Nexist++;
                    }
                    else
                    {
                        var c = _context.Groups.Where(d => d.NomCla == P1.Checked
                                                           && d.OrderF == P2.Checked
                                                           && d.UseG == P3.Checked
                                                           && d.MatierP == P4.Checked
                                                           && d.User == P5.Checked);

                        Pexist = c.Count();
                    }

                    if (Nexist == 0 && Pexist == 0)
                    {
                        var group = _context.Groups.Find(
                            Convert.ToInt16(dgvUserGroup.CurrentRow.Cells[0].Value.ToString()));

                        group.NomGroup = lblGroup.Text;
                        group.NomCla = P1.Checked;
                        group.OrderF = P2.Checked;
                        group.UseG = P3.Checked;
                        group.MatierP = P4.Checked;
                        group.User = P5.Checked;

                        _context.SaveChanges();

                        var Usergroup = (from t in _context.Groups
                            where t.ID != 19
                            select new
                            {
                                t.ID,
                                Role = t.NomGroup,
                                Nomcl = t.NomCla.ToString(),
                                OrdF = t.OrderF.ToString(),
                                Grp = t.UseG.ToString(),
                                MtrP = t.MatierP.ToString(),
                                User = t.User.ToString()
                            }).ToList();
                        dgvUserGroup.DataSource = Usergroup;
                        dgvUserGroup.Columns[0].Width = 25;
                    }

                    if (Nexist != 0)
                    {
                        MessageBox.Show("Cet Nom de Group d'utilisateur Deja exist ", "Atenttion", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //Clear Text In txtUName textbox
                        lblGroup.Text = "";
                    }
                    else if (Pexist != 0)
                    {

                        MessageBox.Show("Un Group Utilisateur ayant les meme droit deja exist", "Atenttion",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvUserGroup_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    var group = _context.Groups.Find(Convert.ToInt16(dgvUserGroup.CurrentRow.Cells[0].Value.ToString()));
                    lblGroup.Text = group.NomGroup;
                    P1.Checked = group.NomCla;
                    P2.Checked = group.OrderF;
                    P3.Checked = group.UseG;
                    P4.Checked = group.MatierP;
                    P5.Checked = group.User;
                }

                private void btnSup_Click(object sender, EventArgs e)
                {
                    var group = _context.Groups.Find(Convert.ToInt16(dgvUserGroup.CurrentRow.Cells[0].Value.ToString()));
                    _context.Groups.Remove(group);
                    _context.SaveChanges();
                    var Usergroup = (from t in _context.Groups
                                     where t.ID != 19
                                     select new
                                     {
                                         t.ID,
                                         Role = t.NomGroup,
                                         Nomcl = t.NomCla.ToString(),
                                         OrdF = t.OrderF.ToString(),
                                         Grp = t.UseG.ToString(),
                                         MtrP = t.MatierP.ToString(),
                                         User = t.User.ToString()
                                     }).ToList();
                    dgvUserGroup.DataSource = Usergroup;
                    dgvUserGroup.Columns[0].Width = 25;

                }
                
            }
        }
