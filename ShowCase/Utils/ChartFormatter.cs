using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace ShowCase.Utils
{
    public static class ChartFormatter
    {
        /// <summary>
        /// Formats a digital sequence with black rectangular markers for each data point. Since it is a digital signal,
        /// the x-axis is labeled as "Sample Number" and the y-axis is labeled as "Magnitude". 
        /// </summary>
        /// <param name="sequence">Input digital signal</param>
        /// <param name="title">Title of the chart</param>
        /// <returns>Formatted PlotModel</returns>
        public static PlotModel FormatDigitalSequence(double[] sequence, string title)
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
                Title = "Amplitude",
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = lightGray
            };
            plotModel.Axes.Add(yAxis);

            return plotModel;
        }


        public static PlotModel FormatSpectrumMagnitude(Complex[] spectrum, string title)
        {
            PlotModel plotModel = new() { Title = title };
            LineSeries series = new();

            for (int i = 0; i < spectrum.Length; i++)
            {
                double f = (double)i / spectrum.Length;
                series.Points.Add(new DataPoint(f, spectrum[i].Magnitude));
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
                Title = "Digital Frequency",
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = lightGray
            };
            plotModel.Axes.Add(xAxis);

            LinearAxis yAxis = new()
            {
                Position = AxisPosition.Left,
                Title = "Amplitude",
                MajorGridlineStyle = LineStyle.Dot,
                MajorGridlineColor = lightGray
            };
            plotModel.Axes.Add(yAxis);

            return plotModel;
        }
    }
}
