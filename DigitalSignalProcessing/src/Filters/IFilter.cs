using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalProcessing
{
    public interface IFilter
    {
        double CutoffFrequency { get; }
        double[] Filter(double[] x);
    }
}
