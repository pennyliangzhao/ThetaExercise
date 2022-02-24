using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ThetaExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\zhaolian2\Desktop\weather.txt";
            List<DailyTemp> temps = new List<DailyTemp>();
            List<string> lines = File.ReadLines(filePath).Skip(8).Take(30).ToList();

            foreach (var line in lines)
            {
         
                string[] entries = new string[5];
              
                DailyTemp newDailyTemp = new DailyTemp();

                newDailyTemp.Dy =entries[0];
                newDailyTemp.MxT = entries[1];
                newDailyTemp.MnT = entries[2];
                temps.Add(newDailyTemp);

                
            }
            foreach (var dailyTemp in temps)
            {

                Console.WriteLine($"{dailyTemp.Dy}:{dailyTemp.MxT},{dailyTemp.MnT}");
            }

            Console.ReadLine();

        }
    }
}