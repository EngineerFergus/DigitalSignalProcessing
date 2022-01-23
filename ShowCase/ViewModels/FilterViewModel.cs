using DigitalSignalProcessing;
using ShowCase.Utils;
using ShowCase.Utils.Enums;
using OxyPlot;
using System.Numerics;
using System.Windows;
using System.Windows.Input;

namespace ShowCase.ViewModels
{
    public class FilterViewModel : ObservableObject
    {
        private readonly int M = 101;
        private IFilter filter;

        private double _CutoffOne;
        public double CutoffOne
        {
            get { return _CutoffOne; }
            set
            {
                if(value != _CutoffOne)
                {
                    _CutoffOne = value;
                    OnPropertyChanged(nameof(CutoffOne));
                }
            }
        }

        private double _CutoffTwo;
        public double CutoffTwo
        {
            get { return _CutoffTwo; }
            set
            {
                if(value != _CutoffTwo)
                {
                    _CutoffTwo = value;
                    OnPropertyChanged(nameof(CutoffTwo));
                }
            }
        }

        private FilterType selectedType;
        public FilterType SelectedType
        {
            get { return selectedType; }
            set
            {
                if(value != selectedType)
                {
                    selectedType = value;
                    OnPropertyChanged(nameof(SelectedType));
                }
            }
        }

        private ICommand _GenerateFilterCommand;
        public ICommand GenerateFilterCommand
        {
            get
            {
                if(_GenerateFilterCommand == null)
                {
                    _GenerateFilterCommand = new RelayCommand(CanGenerateFilter, OnGenerateFilter_Clicked);
                }

                return _GenerateFilterCommand;
            }
        }

        public PlotModel FilterFrequencyPlot { get; private set; }
        public PlotModel FilterKernelPlot { get; private set; }

        public FilterViewModel()
        {
            SelectedType = FilterType.LowPass;
            CutoffOne = 0.2;
            CutoffTwo = 0.3;

            filter = new LowPassFilter(CutoffOne, M);
            Complex[] freqZ = filter.FrequencyResponse();


            FilterFrequencyPlot = ChartFormatter.FormatSpectrumMagnitudeDB(freqZ, "Spectrum");
        }

        public void OnGenerateFilter_Clicked(object data)
        {

        }

        public bool CanGenerateFilter(object data)
        {
            return true;
        }

    }
}
