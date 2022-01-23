using DigitalSignalProcessing;
using ShowCase.Utils;
using OxyPlot;

namespace ShowCase.ViewModels
{
    public class FilterViewModel : ObservableObject
    {
        private IFilter filter;
        public PlotModel FilterFrequencyPlot { get; private set; }
        public PlotModel FilterKernelPlot { get; private set; }
    }
}
