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
    public partial class FormCourse : Form
    {
        
        public List<string> listOfCourses = new List<string>(){};
        FormHello _formHello;

        public FormCourse(FormHello formHello)
        {
            InitializeComponent();

            listOfCourses.AddRange(Courses.Get().ToArray());
            listBoxCourse.Items.AddRange(Courses.Get().ToArray());

            _formHello = formHello;

        }

        private void textBoxCourse_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCourse != null && textBoxCourse.Text != "")
            {
                buttonCourseAdd.Enabled = true;
            }
            else
            {
                buttonCourseAdd.Enabled = false;
            }
            
        }

        private void buttonCourseAdd_Click(object sender, EventArgs e)
        {
            bool checkList = false;
            foreach (string tb in listOfCourses)
            {
                if (tb == textBoxCourse.Text)
                {
                    checkList = true;
                }
            }

            if (checkList)
            {
                MessageBox.Show("Такой предмет уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                listOfCourses.Add(textBoxCourse.Text);
                listBoxCourse.Items.Add(textBoxCourse.Text);
                textBoxCourse.Text = "";
                labelCoursesAreSaved.Visible = false;
            }
            
        }

        private void buttonCourseSave_Click(object sender, EventArgs e)
        {
            Courses.Set(listOfCourses);
            labelCoursesAreSaved.Visible = true;
            ((ComboBox)(_formHello.Controls.Find("comboBoxCourseFilter", true)[0])).Items.Clear();
            ((ComboBox)(_formHello.Controls.Find("comboBoxCourseFilter", true)[0])).Items.AddRange(Courses.Get().ToArray());
            //_formHello.listOfCourses = listOfCourses;
            //this.Visible = false;
            //_formHello.Visible = true;
            //KeyValuePair<Panel, Test> keyValue in ListTests
            foreach (KeyValuePair<Panel, FormChooseTestName> formCTN in _formHello.ListMarksAndName)
            {
                ComboBox currentCB = (ComboBox)formCTN.Value.Controls.Find("comboBoxCourse", true)[0];
                if (currentCB.SelectedItem != null)
                {
                    string bufItem = currentCB.SelectedItem.ToString();
                    currentCB.Items.Clear();
                    currentCB.Items.AddRange(Courses.Get().ToArray());
                    currentCB.SelectedItem = Courses.Get().Find(x => (x == bufItem));
                }
                
            }
            



        }

        private void listBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBoxCourse.SelectedItem != null)
            {
                buttonCourseDelete.Enabled = true;

            }
            else
            {
                buttonCourseDelete.Enabled = false;

            }
            
        }

        private void buttonCourseDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCourse.SelectedItem != null)
            {
                if (listBoxCourse.SelectedItem.ToString() == "<Без предмета>")
                {
                    MessageBox.Show("Нельзя удалить стандартный элемент списка", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    listOfCourses.Remove(listBoxCourse.SelectedItem.ToString());
                    listBoxCourse.Items.Remove(listBoxCourse.SelectedItem);
                }
                
            }
        }

        private void buttonCourseClear_Click(object sender, EventArgs e)
        {
            listBoxCourse.Items.Clear();
            listOfCourses.Clear();
            
        }

        private void buttonCourseSort_Click(object sender, EventArgs e)
        {
            listBoxCourse.Sorted = true;
        }
    }
}
