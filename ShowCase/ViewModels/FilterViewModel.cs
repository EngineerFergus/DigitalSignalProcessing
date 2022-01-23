using DigitalSignalProcessing;
using ShowCase.Utils;
using ShowCase.Utils.Enums;
using OxyPlot;
using System.Numerics;
using System.Windows;
using System.Windows.Input;
using System;

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
                    _GenerateFilterCommand = new RelayCommand(CanGenerateFilter, OnGenerateFilterClicked);
                }

                return _GenerateFilterCommand;
            }
        }

        private PlotModel _FilterFrequencyPlot;
        public PlotModel FilterFrequencyPlot
        {
            get { return _FilterFrequencyPlot; }
            set
            {
                if(value != _FilterFrequencyPlot)
                {
                    _FilterFrequencyPlot = value;
                    OnPropertyChanged(nameof(FilterFrequencyPlot));
                }
            }
        }

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

        public void OnGenerateFilterClicked(object data)
        {
            _CutoffOne = ClampFrequency(_CutoffOne);
            _CutoffTwo = ClampFrequency(_CutoffTwo);

            filter = selectedType switch
            {
                FilterType.LowPass => new LowPassFilter(_CutoffOne, M),
                FilterType.HighPass => new HighPassFilter(_CutoffOne, M),
                FilterType.BandPass => new BandPassFilter(_CutoffOne, _CutoffTwo, M),
                FilterType.BandReject => new BandRejectFilter(_CutoffOne, _CutoffTwo, M),
                _ => new LowPassFilter(_CutoffOne, M),
            };
            Complex[] freqZ = filter.FrequencyResponse();
            FilterFrequencyPlot = ChartFormatter.FormatSpectrumMagnitudeDB(freqZ, "Spectrum");
        }

        public static bool CanGenerateFilter(object data)
        {
            return true;
        }

        public static double ClampFrequency(double frequency)
        {
            frequency = Math.Max(0.01, frequency);
            frequency = Math.Min(0.49, frequency);
            return frequency;
        }

    }
}
