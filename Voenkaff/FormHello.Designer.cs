﻿namespace Voenkaff
{
    partial class FormHello
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonFilterOff = new System.Windows.Forms.Button();
            this.comboBoxCourseFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCreateTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьТестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.взводаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предметыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTests = new System.Windows.Forms.SaveFileDialog();
            this.AddTestPanel = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.AddTestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Controls.Add(this.buttonFilterOff);
            this.panelMain.Controls.Add(this.comboBoxCourseFilter);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMain.Location = new System.Drawing.Point(0, 28);
            this.panelMain.Margin = new System.Windows.Forms.Padding(5);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1583, 982);
            this.panelMain.TabIndex = 0;
            this.panelMain.VisibleChanged += new System.EventHandler(this.panelMain_VisibleChanged);
            // 
            // buttonFilterOff
            // 
            this.buttonFilterOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilterOff.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonFilterOff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonFilterOff.Location = new System.Drawing.Point(569, 22);
            this.buttonFilterOff.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFilterOff.Name = "buttonFilterOff";
            this.buttonFilterOff.Size = new System.Drawing.Size(173, 44);
            this.buttonFilterOff.TabIndex = 11;
            this.buttonFilterOff.Text = "Сброс";
            this.buttonFilterOff.UseVisualStyleBackColor = true;
            this.buttonFilterOff.Click += new System.EventHandler(this.buttonFilterOff_Click);
            // 
            // comboBoxCourseFilter
            // 
            this.comboBoxCourseFilter.FormattingEnabled = true;
            this.comboBoxCourseFilter.Location = new System.Drawing.Point(249, 32);
            this.comboBoxCourseFilter.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCourseFilter.Name = "comboBoxCourseFilter";
            this.comboBoxCourseFilter.Size = new System.Drawing.Size(311, 24);
            this.comboBoxCourseFilter.TabIndex = 10;
            this.comboBoxCourseFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourseFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(21, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Фильтр по предметам";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCreateTest
            // 
            this.buttonCreateTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateTest.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCreateTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCreateTest.Location = new System.Drawing.Point(703, 19);
            this.buttonCreateTest.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCreateTest.Name = "buttonCreateTest";
            this.buttonCreateTest.Size = new System.Drawing.Size(199, 55);
            this.buttonCreateTest.TabIndex = 8;
            this.buttonCreateTest.Text = "Добавить тест";
            this.buttonCreateTest.UseVisualStyleBackColor = true;
            this.buttonCreateTest.Click += new System.EventHandler(this.buttonCreateTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(752, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Конструктор тестов\r\nСписок";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьТестыToolStripMenuItem,
            this.взводаToolStripMenuItem,
            this.предметыToolStripMenuItem,
            this.toolStripMenuItem1,
            this.закрытьToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1583, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьТестыToolStripMenuItem
            // 
            this.сохранитьТестыToolStripMenuItem.Name = "сохранитьТестыToolStripMenuItem";
            this.сохранитьТестыToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.сохранитьТестыToolStripMenuItem.Text = "Сохранить тесты";
            this.сохранитьТестыToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТестыToolStripMenuItem_Click);
            // 
            // взводаToolStripMenuItem
            // 
            this.взводаToolStripMenuItem.Name = "взводаToolStripMenuItem";
            this.взводаToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.взводаToolStripMenuItem.Text = "Взвода";
            this.взводаToolStripMenuItem.Click += new System.EventHandler(this.взводаToolStripMenuItem_Click);
            // 
            // предметыToolStripMenuItem
            // 
            this.предметыToolStripMenuItem.Name = "предметыToolStripMenuItem";
            this.предметыToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.предметыToolStripMenuItem.Text = "Предметы";
            this.предметыToolStripMenuItem.Click += new System.EventHandler(this.предметыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 24);
            this.toolStripMenuItem1.Text = "Настройки";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 24);
            // 
            // AddTestPanel
            // 
            this.AddTestPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddTestPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddTestPanel.Controls.Add(this.buttonCreateTest);
            this.AddTestPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddTestPanel.Location = new System.Drawing.Point(0, 921);
            this.AddTestPanel.Name = "AddTestPanel";
            this.AddTestPanel.Size = new System.Drawing.Size(1583, 89);
            this.AddTestPanel.TabIndex = 9;
            // 
            // FormHello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 1010);
            this.Controls.Add(this.AddTestPanel);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHello";
            this.Text = "Конструктор тестов";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.AddTestPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreateTest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьТестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveTests;
        private System.Windows.Forms.ToolStripMenuItem взводаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem предметыToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxCourseFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonFilterOff;
        private System.Windows.Forms.Panel AddTestPanel;
    }
}