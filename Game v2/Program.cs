using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            List<Coord> coordList = new List<Coord>()
            {
                new edge(11,11,"topleft"),
                new edge(11,12,"top"),
                new edge (11,13,"top"),
                new edge(11,14,"topright"),

                new edge(12,11,"left"),
                new Coord(12,12),
                new Coord(12,13),
                new edge(12,14,"right"),

                new edge(13,11,"bottomleft"),
                new edge(13,12,"bottom"),    
                new edge(13, 13,"bottom"),
                new edge(13,14,"bottomright"),
            };
            Area start = new Area(coordList);
            start.printmap();
            Console.CursorTop = 10;
            Console.CursorLeft = 10;
            Console.ReadKey(true);
            Console.CursorTop--;
            Console.Write("-");
            Console.ReadKey(true);


        }
    }
}
