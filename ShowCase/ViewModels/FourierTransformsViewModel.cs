using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using OxyPlot;
using DigitalSignalProcessing;
using ShowCase.Utils;

namespace ShowCase.ViewModels
{
    public class FourierTransformsViewModel
    {
        private readonly double[] Impulse;
        private readonly double[] SinWave;
        private readonly Complex[] ImpulseDFTTransform;
        private readonly Complex[] SinDFTTransform;
        private readonly Complex[] ImpulseFFTTransform;
        private readonly Complex[] SinFFTTransform;

        public PlotModel ImpulsePlot { get; private set; }
        public PlotModel ImpulseDFTTransformPlot { get; private set; }
        public PlotModel ImpulseFFTTransformPlot { get; private set; }
        public PlotModel SinPlot { get; private set; }
        public PlotModel SinDFTTransformPlot { get; private set; }
        public PlotModel SinFFTTransformPlot { get; private set; }

        public FourierTransformsViewModel()
        {
            Stopwatch sw = new Stopwatch();
            int M = 512;

            Impulse = DSP.Impulse(M);

            sw.Restart();
            ImpulseDFTTransform = DSP.DFT(Impulse);
            sw.Stop();
            long impulseDFTTime = sw.ElapsedMilliseconds;

            sw.Restart();
            ImpulseFFTTransform = DSP.FFT(Impulse);
            sw.Stop();
            long impulseFFTTime = sw.ElapsedMilliseconds;

            SinWave = DSP.SinSequence(M, 16);

            sw.Restart();
            SinDFTTransform = DSP.DFT(SinWave);
            sw.Stop();
            long sinDFTTime = sw.ElapsedMilliseconds;

            sw.Restart();
            SinFFTTransform = DSP.FFT(SinWave);
            sw.Stop();
            long sinFFTTime = sw.ElapsedMilliseconds;

            ImpulsePlot = ChartFormatter.FormatDigitalSequence(Impulse, "Impulse");
            ImpulseDFTTransformPlot = ChartFormatter.FormatSpectrumMagnitude(ImpulseDFTTransform, $"DFT Spectrum" +
                $" {impulseDFTTime} ms");
            ImpulseFFTTransformPlot = ChartFormatter.FormatSpectrumMagnitude(ImpulseFFTTransform, $"FFT Spectrum" +
                $" {impulseFFTTime} ms");

            SinPlot = ChartFormatter.FormatDigitalSequence(SinWave, "Sin Wave");
            SinDFTTransformPlot = ChartFormatter.FormatSpectrumMagnitude(SinDFTTransform, $"DFT Spectrum {sinDFTTime} ms");
            SinFFTTransformPlot = ChartFormatter.FormatSpectrumMagnitude(SinFFTTransform, $"FFT Spectrum {sinFFTTime} ms");
        }
    }
}
