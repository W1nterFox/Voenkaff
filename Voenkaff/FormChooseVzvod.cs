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


        Dictionary<string, List<string>> _vzvodAndLS = new Dictionary<string, List<string>> { };



        public FormChooseVzvod(FormHello formHello)
        {
            InitializeComponent();
            _formHello = formHello;

            listBoxVzvoda.SelectedIndexChanged += listBoxVzvoda_SelectedIndexChanged;
        }

        void listBoxVzvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxLS.Items.Clear();
            if (listBoxVzvoda.SelectedItem != null)
            {
                string selectedVzvod = listBoxVzvoda.SelectedItem.ToString();
                _LSInVzvoda = _vzvodAndLS[selectedVzvod];
                listBoxLS.Items.AddRange(_LSInVzvoda.ToArray());
            }
            
        }

        

        

        private void buttonVzvodAdd_Click(object sender, EventArgs e)
        {
            if (textBoxVzvoda.Text != "")
            {

                _vzvodAndLS.Add(textBoxVzvoda.Text, new List<string> {});


                listBoxVzvoda.Items.Add(textBoxVzvoda.Text);
                textBoxVzvoda.Text = "";
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
            if (listBoxVzvoda.SelectedItem != null)
            {
                _vzvodAndLS[listBoxVzvoda.SelectedItem.ToString()].Remove(listBoxLS.SelectedItem.ToString());
                listBoxLS.Items.Remove(listBoxLS.SelectedItem);
            }
            
        }

        private void buttonLSClear_Click(object sender, EventArgs e)
        {
            listBoxLS.Items.Clear();
        }

        private void buttonLSSort_Click(object sender, EventArgs e)
        {
            listBoxLS.Sorted = true;
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            this.Visible = false;
            Program.formHello.Visible = true;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _formHello.Visible = true;
            _formHello._vzvodAndLS = _vzvodAndLS;
        }
    }
}
