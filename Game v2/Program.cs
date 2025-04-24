using System;
using System.Collections.Generic;

namespace Game_v2
{
    internal class Program
    {
        static List<Area> initialise_maps()
        {
            List<Area> maps = new List<Area>();
            List<edge> edges = new List<edge>()
            {
                new edge(1,1,"topleft"),
                new edge(2,1,"top"),
                new edge(3,1,"top"),
                new edge(4,1,"top"),
                new edge(5,1,"top"),
                new edge(6,1,"topright"),

                new edge(1,2,"left"),
                new edge(6,2,"right"),
                new edge(9,2,"topleftright"),

                new door(1,3,"left",new int[] {1,2}),
                new edge(6,3,"right"),
                new edge(9,3,"leftright"),

                new edge(1,4,"left"),
                new edge(7,4,"none"),
                new edge(8,4,"none"),
                new edge(9,4,"right"),

                new edge(1,5,"left"),
                new edge(7,5,"bottom"),
                new edge(8,5,"bottom"),
                new edge(9,5,"bottomright"),

                new edge(1,6,"bottomleft"),
                new edge(2,6,"bottom"),
                new edge(3,6,"bottom"),
                new edge(4,6,"bottom"),
                new edge(5,6,"bottom"),
                new edge(6,6,"bottomright"),
            };
            List<Coord> startcords = createmap(edges);
            Area startmap = new Area(startcords);
            maps.Add(startmap);
            return maps;
        }
        static List<Coord> createmap(List<edge> edges)
        {
            List<Coord> area = new List<Coord>();
            for (int i = 0; i < edges.Count; i++)
            {
                if (i == edges.Count) break;
                area.Add(edges[i]);
                if (edges[i].getedgetype() != "right" && edges[i].getedgetype() != "topright" && edges[i].getedgetype() != "bottomright" && edges[i].getedgetype() != "topleftright" && edges[i].getedgetype() != "leftright")
                {
                    int x = (edges[i].getx() + 1);
                    int y = (edges[i].gety());
                    while (x != edges[(i + 1)].getx())
                    {

                        area.Add(new Coord(x, y));
                        x++;
                    }
                }
            }
            return area;
        }
        static void Main(string[] args)
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            start();
            Console.ReadKey(true);


        }
        static void start()
        {
            List<Area> maps = initialise_maps();

            maps[0].printmap();
            Console.ReadKey(true);
        }
    }
}
