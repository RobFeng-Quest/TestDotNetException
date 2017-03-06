using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonProject;

namespace WindowsFormsControlProject
{
    public partial class WinformExceptionTestView : UserControl
    {
        private bool FUseCodeException = true;

        public WinformExceptionTestView()
        {
            InitializeComponent();
        }

        private void ExceptionInMainThread_Click(object sender, EventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInMainThread();
        }

        private void ExceptionInBackgroundThread_Click(object sender, EventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInBackgroundThread();
        }

        private void ExceptionInTask_Click(object sender, EventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInTask();
        }

        private void InvokeExceptionInMainThread_Click(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
                commonExceptionTest.ExceptionInMainThread();
            }));
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
