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
            this.buttonCreateTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.сохранитьТестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelMain.Controls.Add(this.buttonCreateTest);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMain.Location = new System.Drawing.Point(13, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(901, 510);
            this.panelMain.TabIndex = 0;
            // 
            // buttonCreateTest
            // 
            this.buttonCreateTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateTest.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.buttonCreateTest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCreateTest.Location = new System.Drawing.Point(365, 63);
            this.buttonCreateTest.Name = "buttonCreateTest";
            this.buttonCreateTest.Size = new System.Drawing.Size(149, 45);
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
            this.label1.Location = new System.Drawing.Point(344, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Конструктор тестов\r\nСписок";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьТестыToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // сохранитьТестыToolStripMenuItem
            // 
            this.сохранитьТестыToolStripMenuItem.Name = "сохранитьТестыToolStripMenuItem";
            this.сохранитьТестыToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.сохранитьТестыToolStripMenuItem.Text = "Сохранить тесты";
            this.сохранитьТестыToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТестыToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // FormHello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 549);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormHello";
            this.Text = "FormHello";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}