using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PopulatePlanets
    {
        public static List<int> ComposePlanetCollection(int avg, int r1, int r2, int r3, int n, int m)
        {
            var selectedPlanets = GetMultiplePlanets(avg, r1, r2, r3, n);
            var otherPlanetsLength = m - n;
            var otherPlanets = GetOtherPlanets(otherPlanetsLength, selectedPlanets.Min(), r1, r2, r3);
            selectedPlanets.AddRange(otherPlanets);
            return selectedPlanets;
        }

        //public static int GetSinglePlanet(int avg, int r1, int r2, int r3)
        //{
        //    var prob = Helper.GetProbabilities(avg, r1, r2, r3);
        //    var selectedPlanet = ChooseRandom(prob, r1, r2, r3);
        //    return selectedPlanet;
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="r1">10</param>
        /// <param name="r2">100</param>
        /// <param name="r3">1000</param>
        /// <param name="n">The eligibility number</param>
        /// <returns></returns>
        /// 


        public static List<int> GetMultiplePlanets(int avg, int r1, int r2, int r3, int n)
        {
            var prob = Helper.GetProbabilities(avg, r1, r2, r3);
            var result = new List<int>() { };
            for (var i = 0; i < n; i++)
            {
                result.Add(ChooseRandom(prob, r1, r2, r3));

            }

            return result;
        }

        private static List<int> GetOtherPlanets(int length, int maxValue, int r1, int r2, int r3)
        {
            var rewards = new[] { r1, r2, r3 };
            var result = new List<int>() { };
            for (int i = 0; i < length; i++)
            {
                var reward = rewards.Where(r => r <= maxValue).First();
                result.Add(reward);
            }



            return result;
        }

        public static int ChooseRandom(Probabilities possibilities, int r1, int r2, int r3)
        {
            var list1 = new List<int>();
            int size = 1000;

            for (var k = 0; k < size * possibilities.P1; k++)
            {
                list1.Add(r1);
                
            }

            int mediumSizePoss = (int)(size * possibilities.P2);

            for (var i = 0; i < mediumSizePoss; i++)
            {
                list1.Add(r2);
            }

            for (var x = 0; x < size * possibilities.P3; x++)
            {
                list1.Add(r3);
            }

            Random rand = new Random();
            var index = rand.Next(0, 1000);
            return list1[index];
        }
    }
}
