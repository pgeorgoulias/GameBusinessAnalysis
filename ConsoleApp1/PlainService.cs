using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class PlainService
    {
        public static int r1 = 10;
        public static int r2 = 100;
        public static int r3 = 1000;
        public static int ProbabilitiesSize = 1000;

        public static void Test(int budgetinEuro, int monthlyUsers, ExcelWorksheet pg)
        {
            var budgetinCrystals = DailyCrystals.ConvertToCrystals(budgetinEuro);
            var winsPerDays = new List<int>() { };

            for (int i = 0; i < 30; i++)
            {
                var winsPerDay = i == 0
                    ? monthlyUsers / 30
                    : (int)winsPerDays.Average();

                var avg = DailyCrystals.DailyBudgetPerWin(30 - i, budgetinCrystals, winsPerDay);

                int actualAverageCostPerWin = (int)NPlanetsRecursiveTestsForAverage(avg, 3, winsPerDay,pg);
                var dailyCost = winsPerDay * actualAverageCostPerWin;
                budgetinCrystals = budgetinCrystals - dailyCost;

                winsPerDays.Add(GetRandomUsers(monthlyUsers / 30));
                
                Console.WriteLine(budgetinCrystals);
            }

            // var avgResult = RecursiveTestsForAverage(avg);

            //var accuracy = Math.Round(Math.Abs((avg - actualCost) / avg) * 100, 2);

            //Console.WriteLine($"Accuracy: {accuracy}%, Average: {avg}, Actual: {actualCost}");
            decimal initialValue = DailyCrystals.ConvertToCrystals(budgetinEuro);
            decimal dif = (budgetinCrystals / initialValue) * 1000;

            Console.WriteLine(dif);

        }

        public static void AboveOrBelowAverage(int dif, int avg)
        {
            if (dif > avg)
            {
                Console.WriteLine("Higher higher than average");
            }
            else if (dif < avg)
            {
                Console.WriteLine("Smaller than the average");
            }
            else
            {
                Console.WriteLine("The value is on point!");
            }
        }

        public static int GetRandomUsers(int center)
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.Next(center - 500, center + 500);
        }

        public static double NPlanetsRecursiveTestsForAverage(int avg, int n, int iterations, ExcelWorksheet pg)
        {
            var partialAvg = avg / n;
            var probs = Helper.GetProbabilities(partialAvg, r1, r2, r3);
            var items = GetProbList(probs);

            var session = new List<int> { };

            for (var i = 0; i < iterations; i++)
            {
                var testSum = new List<int> { };



                for (var j = 2; j < n; j++)
                {
                    var random = ChooseRandom(items);
                    testSum.Add(random);
                    pg.Cells[j, 1].Value = random;
                }

                session.Add(testSum.Sum());
            }

            return session.Average();
        }

        public static double RecursiveTestsForAverage(int avg, ExcelWorksheet sheet, int iterations = 10000)
        {
            var probs = Helper.GetProbabilities(avg, r1, r2, r3);
            var items = GetProbList(probs);

            var test = new List<int> { };

            for (var i = 0; i < iterations; i++)
            {
                var random = ChooseRandom(items);
                // Print in the cell in excel.
                test.Add(random);
            }

            return test.Average();
        }

        public static int ChooseRandom(List<int> items)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomSelection = random.Next(ProbabilitiesSize);

            return items.ToArray()[randomSelection];
        }

        public static List<int> GetProbList(Probabilities oo)
        {
            var items = new List<int>() { };

            if (oo.P1 > 0)
                items.AddRange(Enumerable.Range(0, (int)(oo.P1 * ProbabilitiesSize)).Select(x => r1).ToArray());

            if (oo.P2 > 0)
                items.AddRange(Enumerable.Range(0, (int)(oo.P2 * ProbabilitiesSize)).Select(x => r2).ToArray());

            if (oo.P3 > 0)
                items.AddRange(Enumerable.Range(0, (int)(oo.P3 * ProbabilitiesSize)).Select(x => r3).ToArray());

            if (items.Count < 1000)
            {
                var t = 0;
            }

            return items;
        }
    }
}
