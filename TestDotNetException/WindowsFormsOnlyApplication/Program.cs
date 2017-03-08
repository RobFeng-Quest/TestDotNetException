using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsOnlyApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Application.ThreadException += Application_ThreadException;

            Application.Run(new MainWindow());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string errorMessage = string.Format("Application_ThreadException - An unhandled exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception == null)
            {
                string errorMessage = string.Format("AppDomain.CurrentDomain.UnhandledException - An unhandled exception occurred: {0}", e.ExceptionObject + ", IsTerminating=" + e.IsTerminating);
                MessageBox.Show(errorMessage, "Error");
            }
            else
            {
                string errorMessage = string.Format("AppDomain.CurrentDomain.UnhandledException - An unhandled exception occurred: {0}", exception.Message + ", IsTerminating=" + e.IsTerminating);
                MessageBox.Show(errorMessage, "Error");
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            string errorMessage = string.Format("TaskScheduler.UnobservedTaskException - An unhandled exception occurred: {0}", e.Exception.Message + ", Observed=" + e.Observed);
            e.SetObserved();
            MessageBox.Show(errorMessage, "Error");
        }
    }
}
