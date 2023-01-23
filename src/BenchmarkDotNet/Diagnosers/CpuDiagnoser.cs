using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BenchmarkDotNet.Diagnosers
{
    public class CpuDiagnoser : IDiagnoser
    {
        private Process proc;

        public CpuDiagnoser()
        {
            this.proc = Process.GetCurrentProcess();
        }

        public IEnumerable<string> Ids => new[] { "CPU" };

        public IEnumerable<IExporter> Exporters => Array.Empty<IExporter>();

        public IEnumerable<IAnalyser> Analysers => Array.Empty<IAnalyser>();

        public void DisplayResults(ILogger logger)
        {
        }

        public RunMode GetRunMode(BenchmarkCase benchmarkCase)
        {
            return RunMode.NoOverhead;
        }

        private long userStart, userEnd;
        private long privStart, privEnd;

        public void Handle(HostSignal signal, DiagnoserActionParameters parameters)
        {
            if (signal == HostSignal.BeforeActualRun)
            {
                userStart = proc.UserProcessorTime.Ticks;
                privStart = proc.PrivilegedProcessorTime.Ticks;
            }
            if (signal == HostSignal.AfterActualRun)
            {
                userEnd = proc.UserProcessorTime.Ticks;
                privEnd = proc.PrivilegedProcessorTime.Ticks;
            }
        }

        public IEnumerable<Metric> ProcessResults(DiagnoserResults results)
        {
            yield return new Metric(CpuUserMetricDescriptor.Instance, (userEnd - userStart) * 100d / results.TotalOperations);
            yield return new Metric(CpuPrivilegedMetricDescriptor.Instance, (privEnd - privStart) * 100d / results.TotalOperations);
        }

        public IEnumerable<ValidationError> Validate(ValidationParameters validationParameters)
        {
            yield break;
        }
    }
}
