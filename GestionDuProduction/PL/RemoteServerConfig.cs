using SchoolManagment3.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDuProduction.PL
{
    public partial class RemoteServerConfig : Form
    {
        public RemoteServerConfig()
        {
            InitializeComponent();
        }

        private void btnCnx_Click(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
            if (rgx.IsMatch(txtIP.Text))
            {
                Regex rg = new Regex(@"^\d{4}$");
                if (rg.IsMatch(txtPort.Text))
                {
                    var s = txtIP.Text + "," + txtPort.Text;
                    string connectionString = string.Format(" Server = {0}; User ID ={1};Password ={2}"
                        ,s,txtNom.Text,txtPass.Text);
                    SqlConnectionStringBuilder builder =
                        new SqlConnectionStringBuilder(connectionString);

                    // Supply the additional values.
                    builder.InitialCatalog = "VegaCableProd";
                    sqlHelper help = new sqlHelper(builder.ToString());
                    try
                    {
                        if (help.IsConnection)
                        {
                            MessageBox.Show("La connection est etablie avec Succes", "Connection Valide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString(), "Connection Echoue", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    txtPort.Text = "";
                    MessageBox.Show("veuillez respecter le notation de la port");
                }
            }
            else
            {
                txtIP.Text = "";
                MessageBox.Show("veuillez respecter le notation de l'adress IP");
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoteServerConfig_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCnx.PerformClick();
        }
    }
}
