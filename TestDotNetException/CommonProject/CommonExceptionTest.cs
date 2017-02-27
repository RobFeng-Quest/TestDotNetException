using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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

        public void ExceptionInBackgroundThread()
        {
            Thread thread = new Thread(new ThreadStart(ExceptionInMainThread));
            thread.Start();
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
