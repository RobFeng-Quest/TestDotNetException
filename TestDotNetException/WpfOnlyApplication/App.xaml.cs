using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfOnlyApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            //Dispatcher.UnhandledException += Dispatcher_UnhandledException;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
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

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            string errorMessage = string.Format("TaskScheduler.UnobservedTaskException - An unhandled exception occurred: {0}", e.Exception.Message + ", Observed=" + e.Observed);
            e.SetObserved();
            MessageBox.Show(errorMessage, "Error");
        }

        private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("Dispatcher.UnhandledException - An unhandled exception occurred: {0}", e.Exception.Message + ", Handled=" + e.Handled);
            MessageBox.Show(errorMessage, "Error");
            e.Handled = true;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("Application.Current.DispatcherUnhandledException - An unhandled exception occurred: {0}", e.Exception.Message + ", Handled=" + e.Handled);
            MessageBox.Show(errorMessage, "Error");
            e.Handled = true;
        }
    }
}
