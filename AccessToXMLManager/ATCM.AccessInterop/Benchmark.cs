using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ATCM.AccessInterop
{
    /// <summary>
    /// Measuring code execution time
    /// </summary>
    /// <example>
    /// -- Usage:
    /// using (var bench = new Benchmark($"Insert {n} records:"))
    /// {
    /// ... yout code here
    /// }
    /// -- Output:
    /// Insert 10 records: 00:00:00.0617594
    /// </example>
    internal class Benchmark : IDisposable
    {
        private readonly Stopwatch FTimer = new Stopwatch();
        private readonly string FBenchmarkName;
        private readonly StringBuilder FLogMessage = null;

        public Benchmark(string aBenchmarkName)
            : this(aBenchmarkName, null)
        {
        }

        public Benchmark(string aBenchmarkName, StringBuilder aLogMessage)
        {
            FBenchmarkName = aBenchmarkName;
            FLogMessage = aLogMessage;
            FTimer.Start();
        }

        public void Dispose()
        {
            FTimer.Stop();

            var message = $"{FBenchmarkName} {FTimer.Elapsed}";
            Console.WriteLine(message);
            if (FLogMessage != null)
            {
                FLogMessage.AppendLine(message);
            }
        }
    }
}
