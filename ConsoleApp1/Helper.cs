using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Helper
    {
        public static Probabilities GetProbabilities(double avg, double r1, double r2, double r3)
        {
            if (GetMaxAverage(r1, r2, r3) > avg)
                return GetNormalProbabilities(r1, r2, r3, avg);

            return GetHighProbabilities(r1, r2, r3, avg);
        }

        public static double GetMaxAverage(double r1, double r2, double r3)
        {
            var maxPayout = 2 * ((r2 * r3) / (r2 + r3));
            return maxPayout;
        }

        public static Probabilities GetNormalProbabilities(double r1, double r2, double r3, double avg)
        {
            double p2 = (r3 * (avg - r1)) / (-(r1 * r2) - (r1 * r3) + (2 * r2 * r3));
            double p3 = p2 * (r2 / r3);

            var round_p2 = Math.Round(p2, 2);
            var round_p3 = Math.Round(p3, 2);
            var round_p1 = Math.Round(1 - round_p2 - round_p3, 2);


            return new Probabilities
            {
                P1 = round_p1,
                P2 = round_p2,
                P3 = round_p3
            };
        }

        public static Probabilities GetHighProbabilities(double r1, double r2, double r3, double avg)
        {
            double p1 = 0;
            double p3 = (avg - r2) / (r3 - r2);

            var round_p3 = Math.Round(p3, 2);
            var round_p2 = Math.Round(1 - round_p3, 2);

            return new Probabilities
            {
                P1 = p1,
                P2 = round_p2,
                P3 = round_p3
            };
        }
    }
}
