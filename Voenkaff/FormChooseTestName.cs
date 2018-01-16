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
    public partial class FormChooseTestName : Form
    {
        FormHello _formHello;
        int _index;
        public int[] marks;

        public FormChooseTestName(FormHello formHello, int index)
        {
            InitializeComponent();
            _formHello = formHello;
            _index = index;
            marks = new int[3] { 0, 0, 0 };
            buttonNext.Enabled = false;

            textBoxMark5.TextChanged += buttonNext_checkNullMarks;
            textBoxMark4.TextChanged += buttonNext_checkNullMarks;
            textBoxMark3.TextChanged += buttonNext_checkNullMarks;
            textBoxUserChooseTestName.TextChanged += buttonNext_checkNullMarks;
        }

        private void buttonNext_checkNullMarks(object sender, System.EventArgs e)
        {
            if (textBoxMark5.Text == null || textBoxMark5.Text == "" ||
                textBoxMark4.Text == null || textBoxMark4.Text == "" ||
                textBoxMark3.Text == null || textBoxMark3.Text == "" ||
                textBoxUserChooseTestName.Text == null || textBoxUserChooseTestName.Text == "" ||
                textBoxUserChooseTestName.Text.Length<3)
                buttonNext.Enabled = false;
            else
                buttonNext.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            _formHello.Controls.Find("linkLabelTest" + _index, true)[0].Text = textBoxUserChooseTestName.Text;
            this.Visible = false;
            _formHello.Visible = true;

            
            marks[0] = Int32.Parse(textBoxMark5.Text);
            marks[1] = Int32.Parse(textBoxMark4.Text);
            marks[2] = Int32.Parse(textBoxMark3.Text);

            _formHello._listmarks.Add(marks);


            //_formHello._listmarks = new List<int[]> { };

        }
    }
}
