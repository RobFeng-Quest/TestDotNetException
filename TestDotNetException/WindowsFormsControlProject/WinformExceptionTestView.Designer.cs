namespace WindowsFormsControlProject
{
    partial class WinformExceptionTestView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ExceptionInMainThread = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ExceptionInBackgroundThread = new System.Windows.Forms.Button();
            this.ExceptionInTask = new System.Windows.Forms.Button();
            this.InvokeExceptionInMainThread = new System.Windows.Forms.Button();
            this.btnGC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExceptionInMainThread
            // 
            this.ExceptionInMainThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExceptionInMainThread.Location = new System.Drawing.Point(0, 13);
            this.ExceptionInMainThread.Name = "ExceptionInMainThread";
            this.ExceptionInMainThread.Size = new System.Drawing.Size(515, 23);
            this.ExceptionInMainThread.TabIndex = 0;
            this.ExceptionInMainThread.Text = "Exception in main thread";
            this.toolTip1.SetToolTip(this.ExceptionInMainThread, "Handle by: Application.ThreadException");
            this.ExceptionInMainThread.UseVisualStyleBackColor = true;
            this.ExceptionInMainThread.Click += new System.EventHandler(this.ExceptionInMainThread_Click);
            // 
            // ExceptionInBackgroundThread
            // 
            this.ExceptionInBackgroundThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExceptionInBackgroundThread.Location = new System.Drawing.Point(0, 36);
            this.ExceptionInBackgroundThread.Name = "ExceptionInBackgroundThread";
            this.ExceptionInBackgroundThread.Size = new System.Drawing.Size(515, 23);
            this.ExceptionInBackgroundThread.TabIndex = 1;
            this.ExceptionInBackgroundThread.Text = "Exception in background thread (Crash)";
            this.toolTip1.SetToolTip(this.ExceptionInBackgroundThread, "Handle by: AppDomain.CurrentDomain.UnhandledException");
            this.ExceptionInBackgroundThread.UseVisualStyleBackColor = true;
            this.ExceptionInBackgroundThread.Click += new System.EventHandler(this.ExceptionInBackgroundThread_Click);
            // 
            // ExceptionInTask
            // 
            this.ExceptionInTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExceptionInTask.Location = new System.Drawing.Point(0, 59);
            this.ExceptionInTask.Name = "ExceptionInTask";
            this.ExceptionInTask.Size = new System.Drawing.Size(515, 23);
            this.ExceptionInTask.TabIndex = 2;
            this.ExceptionInTask.Text = "Exception in Task";
            this.toolTip1.SetToolTip(this.ExceptionInTask, "Handle by: TaskScheduler.UnobservedTaskException");
            this.ExceptionInTask.UseVisualStyleBackColor = true;
            this.ExceptionInTask.Click += new System.EventHandler(this.ExceptionInTask_Click);
            // 
            // InvokeExceptionInMainThread
            // 
            this.InvokeExceptionInMainThread.Dock = System.Windows.Forms.DockStyle.Top;
            this.InvokeExceptionInMainThread.Location = new System.Drawing.Point(0, 82);
            this.InvokeExceptionInMainThread.Name = "InvokeExceptionInMainThread";
            this.InvokeExceptionInMainThread.Size = new System.Drawing.Size(515, 23);
            this.InvokeExceptionInMainThread.TabIndex = 3;
            this.InvokeExceptionInMainThread.Text = "Invoke Exception in main thread";
            this.toolTip1.SetToolTip(this.InvokeExceptionInMainThread, "Handle by: Application_ThreadException");
            this.InvokeExceptionInMainThread.UseVisualStyleBackColor = true;
            this.InvokeExceptionInMainThread.Click += new System.EventHandler(this.InvokeExceptionInMainThread_Click);
            // 
            // btnGC
            // 
            this.btnGC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGC.Location = new System.Drawing.Point(0, 105);
            this.btnGC.Name = "btnGC";
            this.btnGC.Size = new System.Drawing.Size(515, 23);
            this.btnGC.TabIndex = 4;
            this.btnGC.Text = "GC";
            this.btnGC.UseVisualStyleBackColor = true;
            this.btnGC.Click += new System.EventHandler(this.btnGC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Winform Controls";
            // 
            // WinformExceptionTestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGC);
            this.Controls.Add(this.InvokeExceptionInMainThread);
            this.Controls.Add(this.ExceptionInTask);
            this.Controls.Add(this.ExceptionInBackgroundThread);
            this.Controls.Add(this.ExceptionInMainThread);
            this.Controls.Add(this.label1);
            this.Name = "WinformExceptionTestView";
            this.Size = new System.Drawing.Size(515, 339);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExceptionInMainThread;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button ExceptionInBackgroundThread;
        private System.Windows.Forms.Button ExceptionInTask;
        private System.Windows.Forms.Button InvokeExceptionInMainThread;
        private System.Windows.Forms.Button btnGC;
        private System.Windows.Forms.Label label1;
    }
}
