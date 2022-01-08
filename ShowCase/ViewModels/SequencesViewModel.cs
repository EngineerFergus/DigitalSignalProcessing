using DigitalSignalProcessing;
using ShowCase.Utils;
using OxyPlot;

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
            ImpulsePlot = ChartFormatter.FormatDigitalSequence(ImpulseSequence, "Impulse");
            StepPlot = ChartFormatter.FormatDigitalSequence(StepSequence, "Step");
            RectanglePlot = ChartFormatter.FormatDigitalSequence(RectangleSequence, "Rectangle");
        }
    }
}
