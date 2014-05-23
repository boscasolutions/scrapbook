namespace ChatApp.Counters
{
    using System.Diagnostics;

    public class PerfCounterWrapper
    {
        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, instance, readOnly: true);

            Name = name;
        }

        public string Name { get; set; }

        public float Value
        {
            get { return _counter.NextValue(); }
        }

        private PerformanceCounter _counter;

    }
}