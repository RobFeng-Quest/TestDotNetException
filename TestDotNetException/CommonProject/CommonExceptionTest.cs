using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CommonProject
{
    public class CommonExceptionTest
    {
        public void CodeExceptionInMainThread()
        {
            var thrower = new ExceptionThrower();
            thrower.RaiseException();
        }

        public void ThrowExceptionInMainThread()
        {
            var thrower = new ExceptionThrower();
            thrower.RaiseException();
        }

        public void CodeExceptionInBackgrounThread()
        {
            //Thread thread = new Thread();
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
