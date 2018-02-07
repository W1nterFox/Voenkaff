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
        //public int[] marks;
        public List<int> _marks;

        public string startName = "";
        public Panel parentPanel;
        public FormChooseTestName(FormHello formHello, int index)
        {
            InitializeComponent();

            

            _formHello = formHello;
            _index = index;
            //marks = new int[3] { 0, 0, 0 };
            _marks = new List<int> { 0, 0, 0 };
            buttonNext.Enabled = false;

            textBoxMark5.TextChanged += buttonNext_checkNullMarks;
            textBoxMark4.TextChanged += buttonNext_checkNullMarks;
            textBoxMark3.TextChanged += buttonNext_checkNullMarks;
            textBoxUserChooseTestName.TextChanged += buttonNext_checkNullMarks;
            comboBoxCourse.SelectedIndexChanged += buttonNext_checkNullMarks;

            comboBoxCourse.Items.AddRange(Courses.Get().ToArray());


            



            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

        }

        private void buttonNext_checkNullMarks(object sender, System.EventArgs e)
        {
            int fake;
            Boolean markIsOk = false;
            Boolean markIsGrow = false;
            Boolean courseIsOk = false;
            if (textBoxMark5.Text != null && textBoxMark5.Text != "" && textBoxMark4.Text != null && textBoxMark4.Text != "" && textBoxMark3.Text != null && textBoxMark3.Text != "")
            {


                if (Int32.TryParse(textBoxMark5.Text, out fake) && Int32.TryParse(textBoxMark4.Text, out fake) && Int32.TryParse(textBoxMark3.Text, out fake))
                {
                    if (Int32.Parse(textBoxMark5.Text) < 0 || Int32.Parse(textBoxMark5.Text) > 100 || Int32.Parse(textBoxMark4.Text) < 0 || Int32.Parse(textBoxMark4.Text) > 100 || Int32.Parse(textBoxMark3.Text) < 0 || Int32.Parse(textBoxMark3.Text) > 100)
                    {
                        buttonNext.Enabled = false;
                        labelOnlyDigit.Visible = true;
                    }
                    else
                    {
                        markIsOk = true;
                        buttonNext.Enabled = true;
                        labelOnlyDigit.Visible = false;
                    }

                    if (Int32.Parse(textBoxMark5.Text) > Int32.Parse(textBoxMark4.Text) && Int32.Parse(textBoxMark4.Text) > Int32.Parse(textBoxMark3.Text) )
                    {
                        markIsGrow = true;
                        labelMarksAreGrow.Visible = false;
                    }
                    else
                    {
                        buttonNext.Enabled = false;
                        labelMarksAreGrow.Visible = true;
                    }

                }

                else
                {
                    buttonNext.Enabled = false;
                    labelOnlyDigit.Visible = true;
                }
                
            }
            else
            {
                buttonNext.Enabled = false;
                labelOnlyDigit.Visible = true;
            }

            
            if (comboBoxCourse.SelectedItem == null)
            {
                buttonNext.Enabled = false;
                labelChooseCourse.Visible = true;
            }
            else
            {
                courseIsOk = true;
                labelChooseCourse.Visible = false;
            }


            if (textBoxUserChooseTestName.Text == null || textBoxUserChooseTestName.Text == "" || textBoxUserChooseTestName.Text.Length < 3)
            {

                buttonNext.Enabled = false;
                labelLabelErrorMin3.Visible = true;
            }
            else
            {
                if (markIsOk && markIsGrow && courseIsOk) buttonNext.Enabled = true;
                labelLabelErrorMin3.Visible = false;
            }

            

            
            

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

            

            _formHello.Controls.Find("linkLabelTest" + _index, true)[0].Text = textBoxUserChooseTestName.Text;
            


            _marks[0] = Int32.Parse(textBoxMark5.Text);
            _marks[1] = Int32.Parse(textBoxMark4.Text);
            _marks[2] = Int32.Parse(textBoxMark3.Text);


            bool testNameAlreadyExist = false;
            foreach (KeyValuePair<Panel, Test> keyValue in _formHello.ListTests)
            {
                if (keyValue.Value.TestName == textBoxUserChooseTestName.Text)
                {
                    testNameAlreadyExist = true;
                }

            }
            if (checkBoxIsFirstOpen.Checked)
            {
                
                
                if (!testNameAlreadyExist)
                {

                    _formHello.TestNameAndMarks.Add(textBoxUserChooseTestName.Text, _marks);

                    Test peremTest = new Test(_formHello, textBoxUserChooseTestName.Text, _formHello.TestNameAndMarks[textBoxUserChooseTestName.Text], comboBoxCourse.SelectedItem.ToString());
                    _formHello.ListTests[parentPanel] = peremTest;

                    //FormChooseVzvod formChooseVzvod = new FormChooseVzvod(_formHello);
                    //_formHello._listVzvodovAndLS.Add(formChooseVzvod);
                    startName = textBoxUserChooseTestName.Text;
                    this.Visible = false;
                    _formHello.Visible = true;
                }
                else
                {
                    MessageBox.Show("Такой тест уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            else
            {
                
                if (!testNameAlreadyExist || startName == textBoxUserChooseTestName.Text)
                {

                    
                    _formHello.Controls.Find("linkLabelTest" + _index, true)[0].Text = textBoxUserChooseTestName.Text;
                    _formHello.TestNameAndMarks[startName] = _marks;
                    

                    

                    _formHello.ListTests[parentPanel].setTestName(textBoxUserChooseTestName.Text);
                    _formHello.ListTests[parentPanel].setTesListMarks(_marks);
                    _formHello.ListTests[parentPanel].Course = comboBoxCourse.SelectedItem.ToString();
                    var ctrlsInPQ = _formHello.ListTests[parentPanel].Controls.Find("panelQuestion", true)[0].Controls;
                    foreach (Control ctrl in ctrlsInPQ)
                    {
                        if (ctrl is PictureBox)
                        {
                            ctrl.Name = ctrl.Name.Replace(startName, textBoxUserChooseTestName.Text);
                        }
                    }

                    startName = textBoxUserChooseTestName.Text;

                    this.Visible = false;
                    _formHello.Visible = true;
                }
                else
                {
                    MessageBox.Show("Такой тест уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


            //не момогло
            //int koef = 0;
            //foreach (Panel pnl in _formHello.ListPanelsTestsOnPanel)
            //{
            //    pnl.Visible = true;
            //    pnl.Location = new Point(28, 78 + 70 * koef);
            //    pnl.Visible = true;
            //    koef++;
            //}
            //_formHello.Redistribution(_formHello.ListPanelsTestsOnPanel);
         
            //_formHello.Controls.Find("panelMain", true)[0].Controls.Find("buttonCreateTest", true)[0].Location = new Point(580, 81 + 70 * koef);
            ////

            //_formHello.buttonFilterOff_Click(this, e);




        }

        
    }
}
