using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalSignalProcessing;

namespace ShowCase.Models
{
    public static class UnitTests
    {
        private static StringBuilder loggedTests;

        static UnitTests()
        {
            loggedTests = new StringBuilder();
            LogMessage("Unit testing begin");
        }

        private static void LogMessage(string message)
        {
            DateTime now = DateTime.Now;
            loggedTests.AppendLine($">> {now.Year}/{now.Month}/{now.Day} {now.Hour}:{now.Minute}:{now.Second} >> {message}");
        }

        private static void LogTest(string testName, bool result)
        {
            if(testName.Length > 20) { testName = $"{testName.Substring(0, 17)}..."; }
            if(testName.Length < 20)
            {
                for(int i = testName.Length; i < 20; i++)
                {
                    testName += ' ';
                }
            }
            string message = $"{testName} : {result}";
            LogMessage(message);
        }

        public static string GetTestSummary()
        {
            return loggedTests.ToString();
        }

        public static void RunTests()
        {
            loggedTests.Clear();
            LogMessage("Name of Test             : Result");
            LogTest(nameof(TestConvAccuracy), TestConvAccuracy());
        }

        private static bool TestConvAccuracy()
        {
            double[] x = new double[] { 1, 2, 3, 4, 5 };
            double[] h = new double[] { 1, 1, 1 };
            double[] trueY = new double[] { 1, 3, 6, 9, 12, 9, 5 };

            double[] yNaive = DSP.NaiveConv(x, h);
            double[] yOptim = DSP.OptimConv(x, h);
            double[] yNFlip = DSP.NaiveConv(h, x);
            double[] yOFlip = DSP.OptimConv(h, x);

            if(trueY.Length != yNaive.Length) { return false; }
            if(trueY.Length != yOptim.Length) { return false; }
            if(trueY.Length != yNFlip.Length) { return false; }
            if(trueY.Length != yOFlip.Length) { return false; }

            for (int i = 0; i < trueY.Length; i++)
            {
                if(trueY[i] != yNaive[i]) { return false; }
                if(trueY[i] != yOptim[i]) { return false; }
                if(trueY[i] != yNFlip[i]) { return false; }
                if(trueY[i] != yOFlip[i]) { return false; }
            }

            return true;
        }
    }
}
