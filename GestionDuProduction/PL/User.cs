using GestionDuProduction.DAL;
using GestionDuProduction.DAL.Repositories;
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

namespace GestionDuProduction
{
    public partial class User : Form
    {
        public static bool exist;
        public VegaContext _context = new VegaContext();
        
        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            FadeIn(this, 20);

            var users = new Repository<Utilisateur>(_context);
            var groups = new Repository<Group>(_context);
            var Usergroup = users.GetAllQueryable().Join(groups.GetAllQueryable(),
                user => user.GroupId,
                group => group.ID,
                (user, group) => new
                {
                    ID = user.ID,
                    Name = user.Nom,
                    Identifiant = user.NomUtilisateur,
                    Mobile = user.Mobile,
                    UserGroup = group.NomGroup
                }).Where(c => c.ID !=2).ToList();
            dgvUser.DataSource = Usergroup;
            this.dgvUser.Columns[0].Width = 20;

            var glist = (from t in _context.Groups
                         where t.ID != 19
                         select t.NomGroup).ToList();
            foreach (object t in glist)
            {
                DwnGroup.Items.Add(t);
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

        private void txtSearch_TextChange(object sender, EventArgs e)
        {
            var matches = (from m in _context.Utilisateurs
                           join k in _context.Groups on m.GroupId equals k.ID
                           where m.Nom.Contains(txtSearch.Text)
                                 || m.NomUtilisateur.Contains(txtSearch.Text)
                                 || m.Mobile.ToString().Contains(txtSearch.Text)
                                 || m.ID.ToString().Contains(txtSearch.Text)
                                 || k.NomGroup.Contains(txtSearch.Text)
                           select new
                           {
                               ID = m.ID,
                               Name = m.Nom,
                               Identifiant = m.NomUtilisateur,
                               Mobile = m.Mobile,
                               UserGroup = k.NomGroup
                           }).Where(c => c.ID != 2).ToList();
            dgvUser.DataSource = matches;
        }

        private void btnAjt_Click(object sender, EventArgs e)
        {
            //some controls
            if (txtName.Text != ""
                && txtPass.Text != ""
                && txtPhone.Text != ""
                && txtUName.Text != ""
                && DwnGroup.selectedIndex != -1)
            {
                //verify the user name
                foreach (DataGridViewRow r in dgvUser.Rows)
                {
                    if (r.Cells[2].Value.ToString().ToLower() != txtUName.Text.ToLower())
                    {
                        exist = false;
                    }
                    else
                    {
                        exist = true;
                        MessageBox.Show("Nom Utilisateur Deja Utiliser ", "Atenttion", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //Clear Text In txtUName textbox
                        txtUName.Text = "";
                    }
                }
                if (exist == false)
                {
                    
                    var c = _context.Groups.Take(DwnGroup.selectedIndex + 1).OrderByDescending(b => b.ID).First().ID;
                    _context.Utilisateurs.Add(new Utilisateur
                    {
                        Nom = txtName.Text,
                        NomUtilisateur = txtUName.Text,
                        Mobile = Convert.ToInt32(txtPhone.Text),
                        MotdePass = txtPass.Text,
                        GroupId = c
                    });

                    _context.SaveChanges();

                    var users = new Repository<Utilisateur>(_context);
                    var groups = new Repository<Group>(_context);
                    var Usergroup = users.GetAllQueryable().Join(groups.GetAllQueryable(),
                        user => user.GroupId,
                        group => group.ID,
                        (user, group) => new
                        {
                            ID = user.ID,
                            Name = user.Nom,
                            Identifiant = user.NomUtilisateur,
                            Mobile = user.Mobile,
                            UserGroup = group.NomGroup
                        }).Where(b => b.ID != 2).ToList();
                    dgvUser.DataSource = Usergroup;
                    this.dgvUser.Columns[0].Width = 20; 
                }
            }
            else
            {
                MessageBox.Show("Veuillez Remplir Tous Les Case", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMdf_Click(object sender, EventArgs e)
        {
            if (txtName.Text != ""
                && txtPass.Text != ""
                && txtPhone.Text != ""
                && txtUName.Text != ""
                && DwnGroup.selectedIndex != -1)
            {
                //verify the user name
                foreach (DataGridViewRow r in dgvUser.Rows)
                {
                    if (r.Cells[2].Value.ToString() != txtUName.Text)
                    {
                        exist = false;

                    }
                    else
                    {
                        exist = true;
                        MessageBox.Show("Nom Utilisateur Deja Utiliser ", "Atenttion", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //Clear Text In txtUName textbox
                        txtUName.Text = "";
                    }
                }

                if (exist == false)
                {
                    var usr = _context.Utilisateurs.Find(Convert.ToInt16(dgvUser.CurrentRow.Cells[0].Value.ToString()));
                    var c = _context.Groups.Take(DwnGroup.selectedIndex + 1).OrderByDescending(b => b.ID).First().ID;
                    usr.Nom = txtName.Text;
                    usr.NomUtilisateur = txtUName.Text;
                    usr.Mobile = Convert.ToInt32(txtPhone.Text);
                    usr.MotdePass = txtPass.Text;
                    usr.GroupId = c;

                    _context.SaveChanges();

                    var users = new Repository<Utilisateur>(_context);
                    var groups = new Repository<Group>(_context);
                    var Usergroup = users.GetAllQueryable().Join(groups.GetAllQueryable(),
                        user => user.GroupId,
                        group => group.ID,
                        (user, group) => new
                        {
                            ID = user.ID,
                            Name = user.Nom,
                            Identifiant = user.NomUtilisateur,
                            Mobile = user.Mobile,
                            UserGroup = group.NomGroup
                        }).ToList();
                    dgvUser.DataSource = Usergroup;
                    this.dgvUser.Columns[0].Width = 20; 
                }
            }
            else
            {
                MessageBox.Show("Veuillez Remplir Tous Les Case", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            if (dgvUser.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("voulez vous vraiment supprimez l'utilisateur"
                                                      + dgvUser.CurrentRow.Cells[1].Value.ToString(),
                    "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var usr = _context.Utilisateurs.Find(Convert.ToInt16(dgvUser.CurrentRow.Cells[0].Value.ToString()));
                    _context.Utilisateurs.Remove(usr);
                    _context.SaveChanges();

                    var users = new Repository<Utilisateur>(_context);
                    var groups = new Repository<Group>(_context);
                    var Usergroup = users.GetAllQueryable().Join(groups.GetAllQueryable(),
                        user => user.GroupId,
                        group => group.ID,
                        (user, group) => new
                        {
                            ID = user.ID,
                            Name = user.Nom,
                            Identifiant = user.NomUtilisateur,
                            Mobile = user.Mobile,
                            UserGroup = group.NomGroup
                        }).Where(c => c.ID != 2 && c.ID != Convert.ToInt32(Main.id.ToString())).ToList();
                    dgvUser.DataSource = Usergroup;
                    this.dgvUser.Columns[0].Width = 20;
                }
            }
            else
            {
                MessageBox.Show("Il Exist aucun utilisateur a supprimer","Attention",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var usr = _context.Utilisateurs.Find(Convert.ToInt16(dgvUser.CurrentRow.Cells[0].Value.ToString()));
            var FirstId = _context.Groups.First().ID;
            var idObj = _context.Groups.Take(DwnGroup.selectedIndex + 1).OrderByDescending(b => b.ID).First().ID;
            txtName.Text = usr.Nom;
            txtUName.Text = usr.NomUtilisateur;
            txtPhone.Text = usr.Mobile.ToString();
            txtPass.Text = usr.MotdePass;
            DwnGroup.selectedIndex = idObj - FirstId;
        }


        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
