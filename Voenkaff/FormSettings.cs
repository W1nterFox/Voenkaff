using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Voenkaff.Properties;

namespace Voenkaff
{
    public partial class FormSettings : Form
    {
        DynamicParams parameters = new DynamicParams();
        public FormSettings()
        {
            InitializeComponent();
            directory.Text = parameters.Get().TestPath;
        }

        private void directory_TextChanged(object sender, EventArgs e)
        {
            parameters.SetTestPath(((Control)sender).Text);
        }

        private void Закрыть_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
