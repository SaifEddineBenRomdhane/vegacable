using GestionDuProduction.DAL;
using GestionDuProduction.PL;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDuProduction
{
    public partial class Login : Form
    {
        public VegaContext _context = new VegaContext();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
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

        private void btnConx_Click(object sender, EventArgs e)
        {
                var q = _context.Utilisateurs.Join(_context.Groups, c => c.GroupId, c => c.ID, (user, group) => new
                {
                    user.ID,
                    user.NomUtilisateur,
                    user.MotdePass,
                    user.Nom,
                    group = group.NomGroup,
                    NomCla = group.NomCla,
                    OrderF = group.OrderF,
                    UseG = group.UseG,
                    MatierP = group.MatierP,
                    User = group.User
                }).SingleOrDefault(c => c.NomUtilisateur == txtName.Text && c.MotdePass == txtPass.Text);
            
            if (q != null)
            {
                Main m = new Main();
                m.lblNom.Text = q.Nom;
                m.lblId.Text = q.ID.ToString();
                m.lblRole.Text = q.group;
                m.btnNmcl.Enabled = q.NomCla;
                m.btnOF.Enabled = q.OrderF;
                m.btnUG.Enabled = q.UseG;
                m.btnMP.Enabled = q.MatierP;
                m.btnUtl.Enabled = q.User;
                m.Show();
                this.Hide();
            }
            else if (q == null)
            {
                MessageBox.Show("Wrong Combination User Name Password ");
            }
            
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConx.PerformClick();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            RemoteServerConfig s = new RemoteServerConfig();
            s.ShowDialog();
        }
    }
}
