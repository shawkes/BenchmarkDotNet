using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Columns;

namespace BenchmarkDotNet.Diagnosers
{    internal class CpuPrivilegedMetricDescriptor : IMetricDescriptor
    {
        internal static readonly IMetricDescriptor Instance = new CpuPrivilegedMetricDescriptor();

        public string Id => "CPU Privileged Time";
        public string DisplayName => Id;
        public string Legend => Id;
        public string NumberFormat => "0.##";
        public UnitType UnitType => UnitType.Time;
        public string Unit => "ns";
        public bool TheGreaterTheBetter => false;
        public int PriorityInCategory => 1;
    }
}
