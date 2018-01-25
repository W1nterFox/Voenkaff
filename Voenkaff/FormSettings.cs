using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            directory.Text = parameters.GetPath();
        }

        private void Закрыть_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void directory_Leave(object sender, EventArgs e)
        {
            var path = ((Control)sender).Text;
            if (Directory.Exists(path))
            {
                parameters.SetTestPath(path);
            }
            else
            {
                var dialogResult = MessageBox.Show("Папки " + path + " не существует, создать?", "Папки не существует",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}
