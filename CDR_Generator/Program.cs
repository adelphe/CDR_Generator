using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var folder = @"D:\SANDBOX\Archives";
            var RowsCount = 300000;
            //var delimiter = "/t";
            DateTime start = new DateTime(2021, 6, 1);
            DateTime end = new DateTime(2021, 6, 30);

            while (DateTime.Compare(start, end) <= 0)
            {

                var fileName = Path.Combine(folder, string.Format("CDR_{0}.csv", start.ToString("yyyyMMdd")));
                using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
                {
                    writer.WriteLine(string.Format("{0},{1},{2},{3},{4}", "Date", "Duration", "Cost", "TrafficType", "Userclass"));
                    for (int j = 0; j < RowsCount; j++)
                    {
                        writer.WriteLine(string.Format("{0},{1},{2},{3},{4}", start.ToString("yyyy-MM-dd"), GetRandomDuration(), GetPrice(GetRandomDuration()), GetRandomTraffic(), GetRandomUserClass()));
                    }
                }
                Console.WriteLine("{0} is generated.", fileName);
                start = start.AddDays(1);
            }
            Console.ReadKey();
        }


        static int GetRandomDuration()
        {
            var minDuration = 1;
            var maxDuration = 180;
            return new Random().Next(minDuration, maxDuration);
        }

        static double GetPrice(int _duration)
        {
            double a = _duration * 1;   // 0.15
            return a;
        }

        static string GetRandomTraffic()
        {
            var traffics = new string[] { "voice", "sms" };
            Random gen = new Random();
            return traffics[gen.Next(1000) % traffics.Length];
        }


        static string GetRandomUserClass()
        {
            var userclass = new string[] { "Silver", "Gold", "Premium" };
            Random gen = new Random();
            return userclass[gen.Next(1000) % userclass.Length];
        }




    }
}
