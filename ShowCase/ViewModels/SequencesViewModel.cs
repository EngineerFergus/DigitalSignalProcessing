using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalSignalProcessing;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ShowCase.ViewModels
{
    public class SequencesViewModel
    {
        private readonly double[] ImpulseSequence;
        private readonly double[] StepSequence;
        private readonly double[] RectangleSequence;

        public PlotModel ImpulsePlot { get; private set; }
        public PlotModel StepPlot { get; private set; }
        public PlotModel RectanglePlot { get; private set; }

        public SequencesViewModel()
        {
            int M = 32;
            ImpulseSequence = DSP.Impulse(M);
            StepSequence = DSP.Step(M, 1, M / 2);
            RectangleSequence = DSP.Rectangle(M, M / 4, 1, M / 4);
            ImpulsePlot = InitializePlotModel(ImpulseSequence, "Impulse");
            StepPlot = InitializePlotModel(StepSequence, "Step");
            RectanglePlot = InitializePlotModel(RectangleSequence, "Rectangle");
        }

        private static PlotModel InitializePlotModel(double[] sequence, string title)
        {
            PlotModel plotModel = new() { Title = title };
            LineSeries series = new();

            for (int i = 0; i < sequence.Length; i++)
            {
                series.Points.Add(new DataPoint(i, sequence[i]));
            }

            OxyColor black = OxyColor.FromRgb(0, 0, 0);
            OxyColor lightGray = OxyColor.FromRgb(80, 80, 80);
            series.Color = black;
            series.MarkerType = MarkerType.Square;
            series.MarkerSize = 3;
            series.MarkerFill = black;
            series.StrokeThickness = 1;

            plotModel.Series.Add(series);

            LinearAxis xAxis = new()
            {
                Position = AxisPosition.Bottom,
                Title = "Sample Number",
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = lightGray
            };
            plotModel.Axes.Add(xAxis);

            LinearAxis yAxis = new()
            {
                Position = AxisPosition.Left,
                Title = "Magnitude",
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = lightGray
            };
            plotModel.Axes.Add(yAxis);

            return plotModel;
        }
    }
}
