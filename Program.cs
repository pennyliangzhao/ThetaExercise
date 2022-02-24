using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ThetaExercise
{
    class Program
    {
        private const String filePath = @"C:\Users\zhaolian2\Desktop\weather.txt";
        private char[] ignoreChar = {'*'};

        public Program() {
            temperatureAnalysis();
        }

        private void temperatureAnalysis() {
            List<string> lines = File.ReadLines(filePath).Skip(8).Take(30).ToList();
            List<DailyTemp> temps = createTemperatureList(lines);
            temps.Sort((x, y) => x.Dif.CompareTo(y.Dif));
            var minDifDay = temps.First();
            Console.WriteLine(" The day is: NO.{0} with the lowest minimum difference between the maximum temperature and the minimum temperature: {1}.", minDifDay.Dy, minDifDay.Dif);
        }

        private List<DailyTemp> createTemperatureList(List<string> lines)
        {
            List<DailyTemp> temps = new List<DailyTemp>();
            foreach (var line in lines)
            {
                try
                {
                    string[] entries = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    DailyTemp newDailyTemp = new DailyTemp();
                    NumberFormatInfo numFormatInfo = new NumberFormatInfo();
                    numFormatInfo.NumberDecimalSeparator = ".";
                    newDailyTemp.Dy = entries[0];
                    newDailyTemp.Dif = Convert.ToDouble(entries[1].TrimEnd(ignoreChar), numFormatInfo) - Convert.ToDouble(entries[2].TrimEnd(ignoreChar), numFormatInfo);
                    temps.Add(newDailyTemp);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (OverflowException exception)
                {
                    Console.WriteLine(exception.Message);
                }


            }
            return temps;
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }


}
