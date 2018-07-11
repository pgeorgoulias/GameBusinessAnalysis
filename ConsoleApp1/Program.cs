using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var path = "C:\\Users\\Panos\\Desktop\\test.xlsx";
            if (File.Exists(path))
            {
                 File.Delete(path);
            }
            using (ExcelPackage xlPackage = new ExcelPackage(new System.IO.FileInfo("C:\\Users\\Panos\\Desktop\\test.xlsx")))
            {
                var mysheet = getSheet(xlPackage);
                PlainService.Test(10000,20000, mysheet);
                mysheet.Cells[1, 1].Value = "Selected Planets";

                xlPackage.Save();
                Console.ReadLine();
            }

            
           
              
            /*
            var number_of_it = 1000;
            var n = 2;
            var tests = new [] { 50, 80, 100, 150, 250, 500, 750, 900, 1000 };
            foreach (var test in tests)
            {
                 getStandardAvg(test);
                var results = new List<double> { };

                for (var s = 1; s <= 50; s++)
               {
                   var result = PopulatePlanets.ComposePlanetCollection(test, 10, 100, 1000, n, 5);
                    var sum = result.OrderByDescending(x => x).Take(n).Sum();
                    var std = Math.Abs((test - (double)sum) / (double)test);
                    Console.WriteLine(string.Join(",", result));
                    Console.WriteLine(std);
                    results.Add(std);
                }

                var average_of_sum = results.Average();

                Console.WriteLine("===========================");
            }

            Console.ReadLine();

    */
        }

        public static ExcelWorksheet getSheet(ExcelPackage xlPackage)
        {
            var mysheet = xlPackage.Workbook.Worksheets.Add("test");
            return mysheet;
        }


        public static void popCells() { 
}
        
        public static double getStandardAvg(int test)
        {
            int loopSize = 1000;
            double standardSum = 0;
            double standardAvg = 0;

            Console.WriteLine("===============================================================================");
            for (int i = 0; i < loopSize; i++)
            {
                var avg = getAverage(test, 10, 100, 1000);
                var std = getStandard(avg, test);
                //Console.WriteLine(avg);
                //Console.WriteLine(std + "%");
                standardSum = standardSum + std;
            }

            standardAvg = standardSum / loopSize;
            Console.WriteLine("The average of the standard deviation is: " + standardAvg + "%");

            return standardAvg;
        }


        public static double getStandard(double avg, int actual)
        {
            double standard = ((avg - actual) / actual) * 100;
            return Math.Abs(standard);
        }

        public static double getAverage(double avg, double r1, double r2, double r3)
        {
            int number_of_it = 1000;
            var maxPayout = 2 * ((r2 * r3) / (r2 + r3));
            Probabilities possibilities = new Probabilities();

            if (maxPayout > avg)
            {
                possibilities = Helper.GetNormalProbabilities(r1, r2, r3, avg);
            }
            else
            {
                possibilities = Helper.GetHighProbabilities(r1, r2, r3, avg);
            }

            Random rand = new Random();
            double sum = 0;
            var list1 = new List<double>();

            int size = 1000;
            for (var k = 0; k < size * possibilities.P1; k++)
            {
                list1.Add(r1);
            }

            int mediumSizePoss = (int)(size * possibilities.P2);

            for (var q = 0; q < mediumSizePoss; q++)
            {
                list1.Add(r2);
            }

            for (var x = 0; x < size * possibilities.P3; x++)
            {
                list1.Add(r3);
            }



            for (var s = 1; s <= number_of_it; s++)
            {
                var index = rand.Next(0, 1000);
                sum = sum + list1[index];
            }

            var average_of_sum = sum / number_of_it;



            //Console.WriteLine(average_of_sum);
            return average_of_sum;
        }







    }
}
