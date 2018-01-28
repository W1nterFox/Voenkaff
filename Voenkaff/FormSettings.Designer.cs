namespace Voenkaff
{
    partial class FormSettings
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
            this.directory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Закрыть = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directory
            // 
            this.directory.Location = new System.Drawing.Point(160, 54);
            this.directory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(210, 20);
            this.directory.TabIndex = 0;
            this.directory.Text = "D:\\\\";
            this.directory.Leave += new System.EventHandler(this.directory_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Директория с тестами:";
            // 
            // Закрыть
            // 
            this.Закрыть.Location = new System.Drawing.Point(191, 219);
            this.Закрыть.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Закрыть.Name = "Закрыть";
            this.Закрыть.Size = new System.Drawing.Size(113, 30);
            this.Закрыть.TabIndex = 2;
            this.Закрыть.Text = "Закрыть";
            this.Закрыть.UseVisualStyleBackColor = true;
            this.Закрыть.Click += new System.EventHandler(this.Закрыть_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 277);
            this.Controls.Add(this.Закрыть);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.directory);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormSettings";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox directory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Закрыть;
    }
}