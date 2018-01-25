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
        private FormHello _formHello;
        public List<string> listOfCourses = new List<string>(){};
        public FormCourse(FormHello formHello)
        {
            InitializeComponent();
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
            }
            
        }

        private void buttonCourseSave_Click(object sender, EventArgs e)
        {
            _formHello.listOfCourses = listOfCourses;
            this.Visible = false;
            _formHello.Visible = true;

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
                listOfCourses.Remove(listBoxCourse.SelectedItem.ToString());
                listBoxCourse.Items.Remove(listBoxCourse.SelectedItem);
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
