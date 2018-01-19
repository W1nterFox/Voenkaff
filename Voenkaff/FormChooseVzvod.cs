using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voenkaff
{
    public partial class FormChooseVzvod : Form
    {
        FormHello _formHello;
        public List<string> _LSInVzvoda;


        public Dictionary<string, List<string>> _vzvodAndLS = new Dictionary<string, List<string>> { };



        public FormChooseVzvod(FormHello formHello)
        {
            InitializeComponent();
            _formHello = formHello;

            listBoxVzvoda.SelectedIndexChanged += listBoxVzvoda_SelectedIndexChanged;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        void listBoxVzvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLS.Items.Clear();
            if (listBoxVzvoda.SelectedItem != null)
            {
                string selectedVzvod = listBoxVzvoda.SelectedItem.ToString();
                _LSInVzvoda = _vzvodAndLS[selectedVzvod];
                listBoxLS.Items.AddRange(_LSInVzvoda.ToArray());

                buttonLSAddMany.Enabled = true;
                
                
                buttonLSSort.Enabled = true;
                buttonLSClear.Enabled = true;
                listBoxLS.Enabled = true;
                textBoxLicnySostav.Enabled = true;


                buttonVzvodClear.Enabled = true;
                buttonVzvodDelete.Enabled = true;
                

            }

            else
            {
                buttonLSAddMany.Enabled = false;
                buttonLSAdd.Enabled = false;
                buttonLSDelete.Enabled = false;
                buttonLSSort.Enabled = false;
                buttonLSClear.Enabled = false;
                listBoxLS.Enabled = false;
                textBoxLicnySostav.Enabled = false;

                buttonVzvodClear.Enabled = true;
                buttonVzvodDelete.Enabled = true;
            }
            
        }

        private void textBoxVzvoda_TextChanged(object sender, EventArgs e)
        {
            if (textBoxVzvoda != null && textBoxVzvoda.Text != "")
            {
                buttonVzvodAdd.Enabled = true;
            }
            else
            {
                buttonVzvodAdd.Enabled = false;
            }
        }

        private void textBoxLicnySostav_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLicnySostav != null && textBoxLicnySostav.Text != "")
            {
                buttonLSAdd.Enabled = true;
            }
            else
            {
                buttonLSAdd.Enabled = false;
            }
        }

        private void listBoxLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxLS.SelectedItem != null)
            {
                buttonLSDelete.Enabled = true;
                
            }
            else
            {
                buttonLSDelete.Enabled = false;
                
            }
        }




        private void buttonVzvodAdd_Click(object sender, EventArgs e)
        {
            List <string> fake;
            if (textBoxVzvoda.Text != "")
            {
                if (!_vzvodAndLS.TryGetValue(textBoxVzvoda.Text, out fake))
                {
                    _vzvodAndLS.Add(textBoxVzvoda.Text, new List<string> { });


                    listBoxVzvoda.Items.Add(textBoxVzvoda.Text);
                    textBoxVzvoda.Text = "";
                }
                else
                {
                    MessageBox.Show("Такой взвод уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }

        private void buttonVzvodDelete_Click(object sender, EventArgs e)
        {
            if (listBoxVzvoda.SelectedItem != null)
            {
                _vzvodAndLS.Remove(listBoxVzvoda.SelectedItem.ToString());
                listBoxVzvoda.Items.Remove(listBoxVzvoda.SelectedItem);
            }
            
        }

        private void buttonVzvodClear_Click(object sender, EventArgs e)
        {
            listBoxVzvoda.Items.Clear();
            _vzvodAndLS.Clear();

            listBoxLS.Items.Clear();
        }

        private void buttonVzvodSort_Click(object sender, EventArgs e)
        {
            listBoxVzvoda.Sorted = true;
        }





        private void buttonLSAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLicnySostav.Text != "" && listBoxVzvoda.SelectedItem != null)
            {
                _vzvodAndLS[listBoxVzvoda.SelectedItem.ToString()].Add(textBoxLicnySostav.Text);

                listBoxLS.Items.Add(textBoxLicnySostav.Text);
                textBoxLicnySostav.Text = "";

            }
        }

        private void buttonLSDelete_Click(object sender, EventArgs e)
        {
            if (listBoxVzvoda.SelectedItem != null && listBoxLS.SelectedItem != null)
            {
                _vzvodAndLS[listBoxVzvoda.SelectedItem.ToString()].Remove(listBoxLS.SelectedItem.ToString());
                listBoxLS.Items.Remove(listBoxLS.SelectedItem);
            }
            
        }

        private void buttonLSClear_Click(object sender, EventArgs e)
        {
            listBoxLS.Items.Clear();
            _vzvodAndLS[listBoxVzvoda.SelectedItem.ToString()].Clear();
        }

        private void buttonLSSort_Click(object sender, EventArgs e)
        {
            listBoxLS.Sorted = true;
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Visible = false;
            Program.FormHello.Visible = true;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _formHello.Visible = true;
            _formHello._vzvodAndLS = _vzvodAndLS;
        }

        private void buttonLSAddMany_Click(object sender, EventArgs e)
        {
            FormLSInputMany formLSInputmany = new FormLSInputMany(this);
            this.Visible = false;
            formLSInputmany.Visible = true;
        }

        
    }
}
