namespace Voenkaff
{
    partial class FormCourse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCoursesAreSaved = new System.Windows.Forms.Label();
            this.buttonCourseSave = new System.Windows.Forms.Button();
            this.buttonCourseSort = new System.Windows.Forms.Button();
            this.buttonCourseClear = new System.Windows.Forms.Button();
            this.buttonCourseDelete = new System.Windows.Forms.Button();
            this.buttonCourseAdd = new System.Windows.Forms.Button();
            this.textBoxCourse = new System.Windows.Forms.TextBox();
            this.listBoxCourse = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.labelCoursesAreSaved);
            this.panel1.Controls.Add(this.buttonCourseSave);
            this.panel1.Controls.Add(this.buttonCourseSort);
            this.panel1.Controls.Add(this.buttonCourseClear);
            this.panel1.Controls.Add(this.buttonCourseDelete);
            this.panel1.Controls.Add(this.buttonCourseAdd);
            this.panel1.Controls.Add(this.textBoxCourse);
            this.panel1.Controls.Add(this.listBoxCourse);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 497);
            this.panel1.TabIndex = 0;
            // 
            // labelCoursesAreSaved
            // 
            this.labelCoursesAreSaved.AutoSize = true;
            this.labelCoursesAreSaved.Font = new System.Drawing.Font("Century Gothic", 12.75F);
            this.labelCoursesAreSaved.ForeColor = System.Drawing.Color.Green;
            this.labelCoursesAreSaved.Location = new System.Drawing.Point(191, 465);
            this.labelCoursesAreSaved.Name = "labelCoursesAreSaved";
            this.labelCoursesAreSaved.Size = new System.Drawing.Size(100, 21);
            this.labelCoursesAreSaved.TabIndex = 18;
            this.labelCoursesAreSaved.Text = "Сохранено";
            this.labelCoursesAreSaved.Visible = false;
            // 
            // buttonCourseSave
            // 
            this.buttonCourseSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCourseSave.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.buttonCourseSave.Location = new System.Drawing.Point(154, 417);
            this.buttonCourseSave.Name = "buttonCourseSave";
            this.buttonCourseSave.Size = new System.Drawing.Size(176, 45);
            this.buttonCourseSave.TabIndex = 16;
            this.buttonCourseSave.Text = "Сохранить";
            this.buttonCourseSave.UseVisualStyleBackColor = true;
            this.buttonCourseSave.Click += new System.EventHandler(this.buttonCourseSave_Click);
            // 
            // buttonCourseSort
            // 
            this.buttonCourseSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCourseSort.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCourseSort.Location = new System.Drawing.Point(3, 185);
            this.buttonCourseSort.Name = "buttonCourseSort";
            this.buttonCourseSort.Size = new System.Drawing.Size(174, 35);
            this.buttonCourseSort.TabIndex = 12;
            this.buttonCourseSort.Text = "Сортировать";
            this.buttonCourseSort.UseVisualStyleBackColor = true;
            this.buttonCourseSort.Click += new System.EventHandler(this.buttonCourseSort_Click);
            // 
            // buttonCourseClear
            // 
            this.buttonCourseClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCourseClear.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCourseClear.Location = new System.Drawing.Point(3, 144);
            this.buttonCourseClear.Name = "buttonCourseClear";
            this.buttonCourseClear.Size = new System.Drawing.Size(174, 35);
            this.buttonCourseClear.TabIndex = 11;
            this.buttonCourseClear.Text = "Очистить";
            this.buttonCourseClear.UseVisualStyleBackColor = true;
            this.buttonCourseClear.Click += new System.EventHandler(this.buttonCourseClear_Click);
            // 
            // buttonCourseDelete
            // 
            this.buttonCourseDelete.Enabled = false;
            this.buttonCourseDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCourseDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCourseDelete.Location = new System.Drawing.Point(3, 103);
            this.buttonCourseDelete.Name = "buttonCourseDelete";
            this.buttonCourseDelete.Size = new System.Drawing.Size(174, 35);
            this.buttonCourseDelete.TabIndex = 10;
            this.buttonCourseDelete.Text = "Удалить";
            this.buttonCourseDelete.UseVisualStyleBackColor = true;
            this.buttonCourseDelete.Click += new System.EventHandler(this.buttonCourseDelete_Click);
            // 
            // buttonCourseAdd
            // 
            this.buttonCourseAdd.Enabled = false;
            this.buttonCourseAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCourseAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCourseAdd.Location = new System.Drawing.Point(3, 62);
            this.buttonCourseAdd.Name = "buttonCourseAdd";
            this.buttonCourseAdd.Size = new System.Drawing.Size(174, 35);
            this.buttonCourseAdd.TabIndex = 9;
            this.buttonCourseAdd.Text = "Добавить";
            this.buttonCourseAdd.UseVisualStyleBackColor = true;
            this.buttonCourseAdd.Click += new System.EventHandler(this.buttonCourseAdd_Click);
            // 
            // textBoxCourse
            // 
            this.textBoxCourse.Location = new System.Drawing.Point(184, 62);
            this.textBoxCourse.Name = "textBoxCourse";
            this.textBoxCourse.Size = new System.Drawing.Size(300, 20);
            this.textBoxCourse.TabIndex = 8;
            this.textBoxCourse.TextChanged += new System.EventHandler(this.textBoxCourse_TextChanged);
            // 
            // listBoxCourse
            // 
            this.listBoxCourse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxCourse.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.listBoxCourse.FormattingEnabled = true;
            this.listBoxCourse.HorizontalScrollbar = true;
            this.listBoxCourse.ItemHeight = 20;
            this.listBoxCourse.Location = new System.Drawing.Point(183, 88);
            this.listBoxCourse.Name = "listBoxCourse";
            this.listBoxCourse.Size = new System.Drawing.Size(301, 302);
            this.listBoxCourse.TabIndex = 7;
            this.listBoxCourse.SelectedIndexChanged += new System.EventHandler(this.listBoxCourse_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 17.75F);
            this.label1.Location = new System.Drawing.Point(171, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Предметы";
            // 
            // FormCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 519);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormCourse";
            this.Text = "Предметы";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCourseSort;
        private System.Windows.Forms.Button buttonCourseClear;
        private System.Windows.Forms.Button buttonCourseDelete;
        private System.Windows.Forms.Button buttonCourseAdd;
        private System.Windows.Forms.TextBox textBoxCourse;
        private System.Windows.Forms.ListBox listBoxCourse;
        private System.Windows.Forms.Button buttonCourseSave;
        private System.Windows.Forms.Label labelCoursesAreSaved;
    }
}