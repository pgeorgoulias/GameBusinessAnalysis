using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DailyCrystals
    {
        public static int ConvertToCrystals(int budget)
        {
            return budget * 1000;

            /*
             * the total budget for the month = 150.000.000 (in crystals).
             */
        }


        public static int DailyBudgetPerWin(int daysLeft, int budget, int winsPerDays)
        {
            return (budget / daysLeft) / winsPerDays;
            /*
             * The daily average.
             */
        }
    }

}
