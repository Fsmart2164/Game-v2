using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{
    internal class Program
    {
        static void createmap(List<edge> edges)
        {
            bool top = true;
            List<Coord> area = new List<Coord>();
            for (int i = 0; i < edges.Count; i++)
            {
                area.Add(edges[i]);
                int x = edges[i].getx();
                int y = edges[i].gety();
                while (x != edges[i + 1].getx() && y != edges[i + 1].gety())
                {

                }
            }
        }
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
