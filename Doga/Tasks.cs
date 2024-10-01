using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Doga
{
    internal class Tasks
    {
        List<Beolvas> list;
        public Tasks()
        {
            list = new List<Beolvas>();
        }

        public void FileRead(string path)
        {
            foreach (var i in File.ReadAllLines(path, Encoding.UTF8).Skip(1))
            {
                var x = i.Split(';');
                string route = x[0];
                double distance = Convert.ToDouble(x[1]);
                int height = Convert.ToInt32(x[2]);
                int time = Convert.ToInt32(x[3]);

                list.Add(new Beolvas(route, distance, height, time));
            }
        }

        public void Task3()
        {
            Console.WriteLine("Task 3: ");
            Console.WriteLine($"Number of the routes:{list.Count}");

            int Pilis = 0;
            double db = list.Where(x => x.Route.Contains("Pilis")).Count();
            Console.WriteLine(db);
            double percentage = (db / list.Count) * 100;
            Console.WriteLine($"{Math.Round(percentage, 2)} % of the routes contains Pilis.");
        }

        public void Task4()
        {
            Console.WriteLine("Task 4:");
            var shortest = list.OrderBy(x => x.Distance).First();
            Console.WriteLine($"The shortest route is: {shortest.Route} and it is {shortest.Distance} km long;");
        }

        public void Task5()
        {
            Console.WriteLine("Task 5: ");
            Console.Write("Give the minimum height:");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Give the maximum height: ");
            int max = Convert.ToInt32(Console.ReadLine());


            var routes = list.Where(x => x.Height > min && x.Height < max).ToList();
            Console.WriteLine($"Between the given heights, there are {routes.Count} routes.");
        }

        public void Task6()
        {
            Console.WriteLine("Task 6:");
            double avg = list.Where(x => x.Distance > 8).Average(x => x.Time);
            Console.WriteLine($"The average time to complete the routes that are longer than 8km: {avg:N2} minutes");
        }

        public void Task8()
        {
            Console.WriteLine("Task 8: ");

            var same = list.GroupBy(x => x.Height).Select(x => new
            {
                y = x.Key,
                db = x.Count()
            }).OrderBy(x => x.y);

            foreach (var i in same)
            {
                Console.WriteLine($"{i.y} meters: {i.db} db");
            }
        }


        public void Task9()
        {
            Console.WriteLine("Task 9: Done!");

            var twohundred = list.Where(x => x.Time > 200).ToList();
            string data = "";
            foreach (var i in twohundred)
            {
                data += $"{i.Route}; {i.Distance}; {i.Height}; {i.Time}\n";    
            }
            File.WriteAllText("above200.txt", data);
        }

        public void Task10()
        {
            Console.WriteLine("Task 10: ");

            double longest = list.Max(x => x.Distance);
            double shortest = list.Min(x => x.Distance);
            Console.WriteLine($"The difference between the longest and the shortest route is: {longest-shortest}"+
                $" The shortest route is {Math.Round(shortest/longest*100, 2) } percentage of the longest route");    
        }
    }
}
