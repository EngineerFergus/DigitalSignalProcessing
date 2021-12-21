using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignalProcessing
{
    static class GuardClauses
    {
        public static void IsOutOfBounds(string methodName, string argumentName, string maxName, int givenValue, int maxValue)
        {
            if(givenValue >= maxValue)
            {
                throw new ArgumentException($"Exception in {methodName}, {argumentName} must be less than {maxName}.");
            }

            if(givenValue < 0)
            {
                throw new ArgumentException($"Exception in {methodName}, {argumentName} must be greater than or equal zero.");
            }
        }

        public static void IsEven(string methodName, string argumentName, int givenValue)
        {
            if(givenValue % 2 == 0)
            {
                throw new ArgumentException($"Exception in {methodName}, {argumentName} cannot be even.");
            }
        }

        public static void IsOdd(string methodName, string argumentName, int givenValue)
        {
            if(givenValue % 2 == 1)
            {
                throw new ArgumentException($"Exception in {methodName}, {argumentName} cannot be odd.");
            }
        }

        public static void IsLessThan(string methodName, string argumentName, int givenValue, int minValue)
        {
            if(givenValue < minValue)
            {
                throw new Exception($"Exception in {methodName}, {argumentName} must be greater than or equal to {minValue}");
            }
        }
    }
}
