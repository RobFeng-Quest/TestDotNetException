using CommonProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlProject
{
    /// <summary>
    /// Interaction logic for WpfExceptionTestView.xaml
    /// </summary>
    public partial class WpfExceptionTestView : UserControl
    {
        private bool FUseCodeException = true;

        public WpfExceptionTestView()
        {
            InitializeComponent();
        }

        private void ExceptionInMainThread_Click(object sender, RoutedEventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInMainThread();
        }

        private void ExceptionInBackgroundThread_Click(object sender, RoutedEventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInBackgroundThread();
        }

        private void InvokeExceptionInMainThread_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
                commonExceptionTest.ExceptionInMainThread();
            }));
        }

        private void ExceptionInTask_Click(object sender, RoutedEventArgs e)
        {
            var commonExceptionTest = new CommonExceptionTest(FUseCodeException);
            commonExceptionTest.ExceptionInTask();
        }

        private void btnGC_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
