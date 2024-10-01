using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga
{
    internal class Beolvas
    {
        public Beolvas(string route, double distance, int height, int time)
        {
            Route = route;
            Distance = distance;
            Height = height;
            Time = time;
        }

        public string Route { get; set; }
        public double Distance { get; set; }  
        public int Height { get; set; }  
        public int Time { get; set; }


        public string Difficulty()
        {
            if (Distance < 4.5)
            {
                return "easy";
            }

            else if (Distance < 8)
            {
                return "medium";
            }

            else { return "hard"; }
        }
    }
}
