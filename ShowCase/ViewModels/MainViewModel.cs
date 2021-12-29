using System;
using System.Windows;
using System.Numerics;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using DigitalSignalProcessing;

namespace ShowCase
{
    public class MainViewModel : Utils.ObservableObject
    {
        public PlotModel MyModel { get; private set; }

        private int buttonCount;
        private double[] hammingWindow;
        private Complex[] hammingFFT;

        private string _ButtonLabel;
        public string ButtonLabel
        {
            get { return _ButtonLabel; }
            set
            {
                if(value != _ButtonLabel)
                {
                    _ButtonLabel = value;
                    OnPropertyChanged(nameof(ButtonLabel));
                }
            }
        }

        public MainViewModel()
        {
            int numPoints = 1024;
            hammingWindow = DSP.Sinc(51, 0.3);
            hammingWindow = DSP.ZeroPad(hammingWindow, numPoints);
            hammingFFT = DSP.FFT(hammingWindow);
            MyModel = new PlotModel { Title = "Example 1" };

            LineSeries hammingSeries = new LineSeries();
            hammingSeries.Title = "Hamming Window";

            for(int i = 0; i < hammingFFT.Length; i++)
            {
                //hammingSeries.Points.Add(new DataPoint((double)i / hammingFFT.Length, DSP.DB(hammingFFT[i].Magnitude)));
                hammingSeries.Points.Add(new DataPoint((double)i / hammingFFT.Length, hammingFFT[i].Magnitude));
                //hammingSeries.Points.Add(new DataPoint((double)i / hammingFFT.Length, hammingWindow[i]));
            }

            MyModel.Series.Add(hammingSeries);
            MyModel.Title = "Hamming Window";
            LinearAxis xAxis = new LinearAxis();
            xAxis.Position = AxisPosition.Bottom;
            xAxis.Title = "Sample Number";
            MyModel.Axes.Add(xAxis);
            ButtonLabel = "You've initialized!";
            buttonCount = 0;
        }

        public void CountButtonClicked(object sender, EventArgs e)
        {
            buttonCount++;
            ButtonLabel = $"You clicked the button. Count: {buttonCount}.";
        }
    }
}
