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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTaskCreate = new System.Windows.Forms.Button();
            this.panelTaskStart = new System.Windows.Forms.Panel();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьТестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьТестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйТестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panelListOfTasks.SuspendLayout();
            this.panelTaskStart.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.panel1.Location = new System.Drawing.Point(1275, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 618);
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
            this.panelQuestion.Size = new System.Drawing.Size(1100, 608);
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
            this.panelListOfTasks.Controls.Add(this.label2);
            this.panelListOfTasks.Controls.Add(this.buttonTaskCreate);
            this.panelListOfTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelListOfTasks.Location = new System.Drawing.Point(0, 24);
            this.panelListOfTasks.Name = "panelListOfTasks";
            this.panelListOfTasks.Size = new System.Drawing.Size(165, 618);
            this.panelListOfTasks.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 586);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
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
            this.panelTaskStart.Location = new System.Drawing.Point(165, 24);
            this.panelTaskStart.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.panelTaskStart.Name = "panelTaskStart";
            this.panelTaskStart.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelTaskStart.Size = new System.Drawing.Size(1110, 618);
            this.panelTaskStart.TabIndex = 5;
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.White;
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(165, 24);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(1110, 618);
            this.panelMiddle.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1397, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйТестToolStripMenuItem,
            this.открытьТестToolStripMenuItem,
            this.сохранитьТестToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.файлToolStripMenuItem.Text = "Меню";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.отменаToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.справкаToolStripMenuItem.Text = "Правка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // открытьТестToolStripMenuItem
            // 
            this.открытьТестToolStripMenuItem.Name = "открытьТестToolStripMenuItem";
            this.открытьТестToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.открытьТестToolStripMenuItem.Text = "Открыть тест...";
            this.открытьТестToolStripMenuItem.Click += new System.EventHandler(this.открытьТестToolStripMenuItem_Click);
            // 
            // сохранитьТестToolStripMenuItem
            // 
            this.сохранитьТестToolStripMenuItem.Name = "сохранитьТестToolStripMenuItem";
            this.сохранитьТестToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.сохранитьТестToolStripMenuItem.Text = "Сохранить тест...";
            // 
            // новыйТестToolStripMenuItem
            // 
            this.новыйТестToolStripMenuItem.Name = "новыйТестToolStripMenuItem";
            this.новыйТестToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.новыйТестToolStripMenuItem.Text = "Новый тест";
            this.новыйТестToolStripMenuItem.Click += new System.EventHandler(this.новыйТестToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // отменаToolStripMenuItem
            // 
            this.отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
            this.отменаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.отменаToolStripMenuItem.Text = "Отмена";
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelListOfTasks.ResumeLayout(false);
            this.panelListOfTasks.PerformLayout();
            this.panelTaskStart.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйТестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьТестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьТестToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

