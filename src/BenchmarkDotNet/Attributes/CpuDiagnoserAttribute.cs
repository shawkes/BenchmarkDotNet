using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using System;

namespace BenchmarkDotNet.Attributes
{
    public class CpuDiagnoserAttribute : Attribute, IConfigSource
    {
        public IConfig Config { get; }

        public CpuDiagnoserAttribute()
        {
            Config = ManualConfig.CreateEmpty().AddDiagnoser(new CpuDiagnoser());
        }
    }
}
