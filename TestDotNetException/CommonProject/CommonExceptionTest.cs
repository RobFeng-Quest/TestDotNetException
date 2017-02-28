using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommonProject
{
    public class CommonExceptionTest
    {
        private readonly bool FUseCodeException = false;

        public CommonExceptionTest(bool aUseCodeException)
        {
            FUseCodeException = aUseCodeException;
        }

        public void ExceptionInMainThread()
        {
            var thrower = new ExceptionThrower();
            thrower.RaiseException(FUseCodeException);
        }

        private void ExceptionWithThreadSleepSecMinute()
        {
            System.Diagnostics.Trace.WriteLine("Start sleep." + DateTime.Now.Millisecond);
            Thread.Sleep(2000);
            System.Diagnostics.Trace.WriteLine("End sleep." + DateTime.Now.Millisecond);
            var thrower = new ExceptionThrower();
            thrower.RaiseException(FUseCodeException);
        }

        public void ExceptionInBackgroundThread()
        {
            Thread thread = new Thread(new ThreadStart(ExceptionWithThreadSleepSecMinute));
            thread.Start();
        }

        public void ExceptionInTask()
        {
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            Action doit = () =>
            {
                //var error = Task.Factory.StartNew(
                //    () => { ExceptionWithSleepSecMinute(); },
                //    CancellationToken.None,
                //    TaskCreationOptions.None,
                //    ui);
                var error = Task.Factory.StartNew(
                    () => { ExceptionWithThreadSleepSecMinute(); });
                //try
                //{
                error.RunSynchronously();
                //}
                //catch (Exception ex)
                //{
                //    System.Diagnostics.Trace.WriteLine(ex);
                //}

                System.Diagnostics.Trace.WriteLine("ExceptionInTask: Exception before this code line.");
            };
            doit.BeginInvoke(null, null);
        }
    }

    public class ExceptionThrower
    {

        public void RaiseException(bool aUseCodeException = false)
        {
            if (aUseCodeException)
            {
                StringBuilder sb = new StringBuilder();
                sb.Insert(-1, "CodeException: Text insert in wrong index.");
            }
            else
            {
                throw new InvalidOperationException("ThrowException: use throw keyword to raise exception.");
            }
        }
    }
}
