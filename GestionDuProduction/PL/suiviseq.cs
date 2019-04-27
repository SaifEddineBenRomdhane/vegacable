using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDuProduction.PL
{
    public partial class suiviseq : UserControl
    {
        public suiviseq()
        {
            InitializeComponent();
        }

        private void S3_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (S3.Checked == true)
            {
                S2.Checked = true;
            }
            
        }


        private void S2_Click(object sender, EventArgs e)
        {

            if(S2.Checked == true)
            {
                S3.Checked = false;
            }
        }
    }
}
