﻿namespace WindowsFormsOnlyApplication
{
    partial class MainWindow
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
            this.winformExceptionTestView1 = new WindowsFormsControlProject.WinformExceptionTestView();
            this.SuspendLayout();
            // 
            // winformExceptionTestView1
            // 
            this.winformExceptionTestView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winformExceptionTestView1.Location = new System.Drawing.Point(0, 0);
            this.winformExceptionTestView1.Name = "winformExceptionTestView1";
            this.winformExceptionTestView1.Size = new System.Drawing.Size(284, 262);
            this.winformExceptionTestView1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.winformExceptionTestView1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsControlProject.WinformExceptionTestView winformExceptionTestView1;
    }
}

