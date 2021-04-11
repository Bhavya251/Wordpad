using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordPad
{
    public partial class About : MetroFramework.Forms.MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblProductName.Text = "Bittu's Wordpad";
            lblVersion.Text = "1.0.2.0";
            lblCopyright.Text = "Copyright ©  2018";
        }
    }
}
