namespace Voenkaff
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelAnswer = new System.Windows.Forms.Panel();
            this.panelListOfTasks = new System.Windows.Forms.Panel();
            this.buttonTaskCreate = new System.Windows.Forms.Button();
            this.panelTaskStart = new System.Windows.Forms.Panel();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelListOfTasks.SuspendLayout();
            this.panelTaskStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1275, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 642);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 373);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Добавить надпись";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(23, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить изображение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить текстовое поле";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelQuestion
            // 
            this.panelQuestion.AutoScroll = true;
            this.panelQuestion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(5, 5);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(1100, 632);
            this.panelQuestion.TabIndex = 1;
            this.panelQuestion.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panelAnswer
            // 
            this.panelAnswer.AutoScroll = true;
            this.panelAnswer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panelAnswer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAnswer.Location = new System.Drawing.Point(165, 524);
            this.panelAnswer.Name = "panelAnswer";
            this.panelAnswer.Size = new System.Drawing.Size(1110, 118);
            this.panelAnswer.TabIndex = 3;
            // 
            // panelListOfTasks
            // 
            this.panelListOfTasks.AutoScroll = true;
            this.panelListOfTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelListOfTasks.Controls.Add(this.buttonTaskCreate);
            this.panelListOfTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelListOfTasks.Location = new System.Drawing.Point(0, 0);
            this.panelListOfTasks.Name = "panelListOfTasks";
            this.panelListOfTasks.Size = new System.Drawing.Size(165, 642);
            this.panelListOfTasks.TabIndex = 4;
            // 
            // buttonTaskCreate
            // 
            this.buttonTaskCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonTaskCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTaskCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonTaskCreate.Location = new System.Drawing.Point(29, 12);
            this.buttonTaskCreate.Name = "buttonTaskCreate";
            this.buttonTaskCreate.Size = new System.Drawing.Size(107, 30);
            this.buttonTaskCreate.TabIndex = 1;
            this.buttonTaskCreate.Text = "Новое задание";
            this.buttonTaskCreate.UseVisualStyleBackColor = false;
            this.buttonTaskCreate.Click += new System.EventHandler(this.buttonTaskCreate_Click);
            // 
            // panelTaskStart
            // 
            this.panelTaskStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTaskStart.Controls.Add(this.panelQuestion);
            this.panelTaskStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskStart.Location = new System.Drawing.Point(165, 0);
            this.panelTaskStart.Margin = new System.Windows.Forms.Padding(10);
            this.panelTaskStart.Name = "panelTaskStart";
            this.panelTaskStart.Padding = new System.Windows.Forms.Padding(5);
            this.panelTaskStart.Size = new System.Drawing.Size(1110, 642);
            this.panelTaskStart.TabIndex = 5;
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.White;
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(165, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(1110, 642);
            this.panelMiddle.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 642);
            this.Controls.Add(this.panelAnswer);
            this.Controls.Add(this.panelTaskStart);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelListOfTasks);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelListOfTasks.ResumeLayout(false);
            this.panelTaskStart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelAnswer;
        private System.Windows.Forms.Panel panelListOfTasks;
        private System.Windows.Forms.Panel panelTaskStart;
        private System.Windows.Forms.Button buttonTaskCreate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelMiddle;
    }
}

