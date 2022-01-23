using DigitalSignalProcessing;
using ShowCase.Utils;
using ShowCase.Utils.Enums;
using OxyPlot;

namespace ShowCase.ViewModels
{
    public class FilterViewModel : ObservableObject
    {
        private IFilter filter;

        private FilterType filterType;
        public FilterType SelectedType
        {
            get { return filterType; }
            set
            {
                if(value != filterType)
                {
                    filterType = value;
                    OnPropertyChanged(nameof(SelectedType));
                }
            }
        }
        public PlotModel FilterFrequencyPlot { get; private set; }
        public PlotModel FilterKernelPlot { get; private set; }

        public FilterViewModel()
        {
            SelectedType = FilterType.LowPass;
        }

    }
}
