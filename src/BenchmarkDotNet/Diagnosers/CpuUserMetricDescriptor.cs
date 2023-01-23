using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Columns;

namespace BenchmarkDotNet.Diagnosers
{
    internal class CpuUserMetricDescriptor : IMetricDescriptor
    {
        internal static readonly IMetricDescriptor Instance = new CpuUserMetricDescriptor();

        public string Id => "CPU User Time";
        public string DisplayName => Id;
        public string Legend => Id;
        public string NumberFormat => "0.##";
        public UnitType UnitType => UnitType.Time;
        public string Unit => "ns";
        public bool TheGreaterTheBetter => false;
        public int PriorityInCategory => 1;
    }
}
