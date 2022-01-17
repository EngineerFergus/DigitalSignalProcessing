using System.Numerics;

namespace DigitalSignalProcessing
{
    public interface IFilter
    {
        public double[] Kernel { get; }
        double[] Filter(double[] x);
        Complex[] FrequencyResponse(int length = 1024);
    }
}
