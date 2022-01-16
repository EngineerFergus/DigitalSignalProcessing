using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using OxyPlot;
using DigitalSignalProcessing;
using ShowCase.Utils;

namespace ShowCase.ViewModels
{
    public class WindowedSincViewModel
    {
        private readonly double[] sincSequence;
        private readonly double[] windowedSincSeq;
        private readonly Complex[] sincTransform;
        private readonly Complex[] windowedSincTransform;

        public PlotModel SincPlot { get; private set; }
        public PlotModel WindowedSincPlot { get; private set; }
        public PlotModel SincMagnitudePlot { get; private set; }
        public PlotModel WindowedSincMagnitudePlot { get; private set; }
        public PlotModel SincDBPlot { get; private set; }
        public PlotModel WindowedSincDBPlot { get; private set; }

        public WindowedSincViewModel()
        {
            int M = 151;
            int MPad = 256;
            double fc = 0.1;
            sincSequence = DSP.Sinc(M, fc);
            windowedSincSeq = DSP.WindowedSinc(M, fc);

            SincPlot = ChartFormatter.FormatDigitalSequence(sincSequence, "Sinc");
            WindowedSincPlot = ChartFormatter.FormatDigitalSequence(windowedSincSeq, "Windowed-Sinc");

            sincSequence = DSP.ZeroPad(sincSequence, MPad);
            windowedSincSeq = DSP.ZeroPad(windowedSincSeq, MPad);
            sincTransform = DSP.FFT(sincSequence);
            windowedSincTransform = DSP.FFT(windowedSincSeq);

            SincMagnitudePlot = ChartFormatter.FormatSpectrumMagnitude(sincTransform, "Sinc Spectrum");
            WindowedSincMagnitudePlot = ChartFormatter.FormatSpectrumMagnitude(windowedSincTransform, "Windowed-Sinc Spectrum");

            SincDBPlot = ChartFormatter.FormatSpectrumMagnitudeDB(sincTransform, "Sinc Spectrum (DB)");
            WindowedSincDBPlot = ChartFormatter.FormatSpectrumMagnitudeDB(windowedSincTransform, "Windowed-Sinc Spectrum (DB)");
        }
    }
}
