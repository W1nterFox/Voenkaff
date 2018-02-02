namespace Voenkaff
{
    partial class Test
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.panelListOfTasks = new System.Windows.Forms.Panel();
            this.buttonTaskCreate = new System.Windows.Forms.Button();
            this.panelTaskStart = new System.Windows.Forms.Panel();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTest = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBoxShowTBLabels = new System.Windows.Forms.GroupBox();
            this.buttonShowTBLabels = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelListOfTasks.SuspendLayout();
            this.panelTaskStart.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxShowTBLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.groupBoxShowTBLabels);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(939, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 618);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(3, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 75);
            this.button3.TabIndex = 2;
            this.button3.Text = "Вставить текст задания";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(3, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить изображение";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(3, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вставить поле для ответа";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelQuestion
            // 
            this.panelQuestion.AutoScroll = true;
            this.panelQuestion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelQuestion.Location = new System.Drawing.Point(5, 5);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(761, 610);
            this.panelQuestion.TabIndex = 1;
            this.panelQuestion.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panelListOfTasks
            // 
            this.panelListOfTasks.AutoScroll = true;
            this.panelListOfTasks.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelListOfTasks.Controls.Add(this.buttonTaskCreate);
            this.panelListOfTasks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelListOfTasks.Location = new System.Drawing.Point(0, 24);
            this.panelListOfTasks.Name = "panelListOfTasks";
            this.panelListOfTasks.Size = new System.Drawing.Size(165, 618);
            this.panelListOfTasks.TabIndex = 4;
            // 
            // buttonTaskCreate
            // 
            this.buttonTaskCreate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonTaskCreate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonTaskCreate.FlatAppearance.BorderSize = 2;
            this.buttonTaskCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTaskCreate.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonTaskCreate.ForeColor = System.Drawing.Color.Black;
            this.buttonTaskCreate.Location = new System.Drawing.Point(24, 12);
            this.buttonTaskCreate.Name = "buttonTaskCreate";
            this.buttonTaskCreate.Size = new System.Drawing.Size(116, 75);
            this.buttonTaskCreate.TabIndex = 1;
            this.buttonTaskCreate.Text = "Новое задание";
            this.buttonTaskCreate.UseVisualStyleBackColor = false;
            this.buttonTaskCreate.Click += new System.EventHandler(this.buttonTaskCreate_Click);
            // 
            // panelTaskStart
            // 
            this.panelTaskStart.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTaskStart.Controls.Add(this.panelQuestion);
            this.panelTaskStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskStart.Location = new System.Drawing.Point(165, 24);
            this.panelTaskStart.Margin = new System.Windows.Forms.Padding(10);
            this.panelTaskStart.Name = "panelTaskStart";
            this.panelTaskStart.Padding = new System.Windows.Forms.Padding(5);
            this.panelTaskStart.Size = new System.Drawing.Size(774, 618);
            this.panelTaskStart.TabIndex = 5;
            // 
            // panelMiddle
            // 
            this.panelMiddle.BackColor = System.Drawing.Color.White;
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(165, 24);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(774, 618);
            this.panelMiddle.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.файлToolStripMenuItem.Text = "Меню";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
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
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // отменаToolStripMenuItem
            // 
            this.отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
            this.отменаToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.отменаToolStripMenuItem.Text = "Отмена";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // groupBoxShowTBLabels
            // 
            this.groupBoxShowTBLabels.Controls.Add(this.label1);
            this.groupBoxShowTBLabels.Controls.Add(this.buttonShowTBLabels);
            this.groupBoxShowTBLabels.Location = new System.Drawing.Point(6, 255);
            this.groupBoxShowTBLabels.Name = "groupBoxShowTBLabels";
            this.groupBoxShowTBLabels.Size = new System.Drawing.Size(136, 112);
            this.groupBoxShowTBLabels.TabIndex = 3;
            this.groupBoxShowTBLabels.TabStop = false;
            // 
            // buttonShowTBLabels
            // 
            this.buttonShowTBLabels.BackColor = System.Drawing.Color.LightBlue;
            this.buttonShowTBLabels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowTBLabels.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonShowTBLabels.Location = new System.Drawing.Point(7, 40);
            this.buttonShowTBLabels.Name = "buttonShowTBLabels";
            this.buttonShowTBLabels.Size = new System.Drawing.Size(120, 64);
            this.buttonShowTBLabels.TabIndex = 0;
            this.buttonShowTBLabels.Text = "Сделать невидимыми";
            this.buttonShowTBLabels.UseVisualStyleBackColor = false;
            this.buttonShowTBLabels.Click += new System.EventHandler(this.buttonShowTBLabels_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номера ответов";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 642);
            this.ControlBox = false;
            this.Controls.Add(this.panelTaskStart);
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelListOfTasks);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Test";
            this.Text = "currentTest";
            this.panel1.ResumeLayout(false);
            this.panelListOfTasks.ResumeLayout(false);
            this.panelTaskStart.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxShowTBLabels.ResumeLayout(false);
            this.groupBoxShowTBLabels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panelListOfTasks;
        private System.Windows.Forms.Panel panelTaskStart;
        private System.Windows.Forms.Button buttonTaskCreate;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveTest;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBoxShowTBLabels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonShowTBLabels;
    }
}

