using System;
using System.Windows;
using OxyPlot;
using OxyPlot.Series;

namespace ShowCase
{
    public class MainViewModel : Utils.ObservableObject
    {
        public PlotModel MyModel { get; private set; }

        private int buttonCount;
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
            MyModel = new PlotModel { Title = "Example 1" };
            MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
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
