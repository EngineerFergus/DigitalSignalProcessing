using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using ShowCase.Utils;
using DigitalSignalProcessing;

namespace ShowCase.ViewModels
{
    public class WindowsViewModel
    {
        private readonly double[] Hamming;
        private readonly double[] Blackman;

        public PlotModel HammingPlot { get; private set; }
        public PlotModel BlackmanPlot { get; private set; }

        public WindowsViewModel()
        {
            int M = 32;
            Hamming = DSP.Hamming(M);
            Blackman = DSP.Blackman(M);
            HammingPlot = ChartFormatter.FormatDigitalSequence(Hamming, "Hamming Window");
            BlackmanPlot = ChartFormatter.FormatDigitalSequence(Blackman, "Blackman Window");
        }
    }
}
