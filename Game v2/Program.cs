using System;
using System.Collections.Generic;

namespace Game_v2
{
    internal class Program
    {
        static List<Area> initialise_maps()
        {
            List<Area> maps = new List<Area>();
            List<Coord> startcords = new List<Coord>()
            {
                new edge(4,1,"-"),
                new edge(5,1,"-"),
                new edge(6,1,"-"),
                new edge(7,1,"-"),

                new edge(3,2,"-"),
                new edge(8,2,"|"),
                new edge(10,2,"-"),

                new edge(2,3,"|"),
                new edge(8,3,"|"),
                new edge(9,3,"|"),
                new chest(10,3,new List<inventoryitem> {new health_potion(30,2),new weapon("zweihander",6,"greatsword","thrust")}),
                new edge(11,3,"|"),

                new edge(2,4,"|"),
                new edge(8,4,"|"),
                new edge(9,4,"|"),
                new edge(11,4,"|"),

                new edge(1,5,"|"),
                new startpoint(5,5),
                new edge(11,5,"|"),

                new door(1,6,new int[] {1,2}),
                new edge(11,6,"|"),

                new edge(1,7,"|"),
                new edge(8,7,"-"),
                new edge(9,7,"-"),
                new edge(10,7,"-"),

                new edge(2,8,"-"),
                new edge(3,8,"-"),
                new edge(4,8,"-"),
                new edge(5,8,"-"),
                new edge(6,8,"-"),
                new edge(7,8,"-"),
            };
            Area startmap = new Area(startcords);
            maps.Add(startmap);
            List<Coord> secondarea = new List<Coord>()
            {
                new edge(9,1,"-"),
                new edge(10,1,"-"),
                new edge(11,1,"-"),
                new door(12,1,new int[] {2,1}),
                new edge(13,1,"-"),
                new edge(14,1,"-"),
                new edge(15,1,"-"),

                new edge(7,2,"-"),
                new edge(8,2,"-"),
                new edge(10,2,"-"),                
                new edge(11,2,"-"),

                new edge(5,3,"-"),
                new edge(6,3,"-"),
                new edge(18,3,"-"),
                new edge(19,3,"-"),

                new edge(4,4,"-"),
                new edge(20,4,"-"),

                new edge(3,5,"|"),
                new startpoint(12,12),
                new edge(21,5,"|"),

                new edge(3,6,"|"),
                new edge(21,6,"|"),

                new edge(2,7,"|"),
                new edge(22,7,"|"),

                new edge(2,8,"|"),
                new edge(22,8,"|"),

                new edge(1,9,"|"),
                new edge(23,9,"|"),
                new edge(1,9,"|"),
                new edge(23,9,"|"),
                new edge(1,9,"|"),
                new edge(23,9,"|"),
                new edge(1,9,"|"),
                new edge(23,9,"|"),
                new edge(1,9,"|"),
                new edge(23,9,"|"),
            };
            return maps;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("you must enter fullscreen to play this");
            Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = false;
            start();
            Console.ReadKey(true);


        }
        static void start()
        {
            List<Area> maps = initialise_maps();

            maps[0].printmap();
            pointer myplayer = new pointer(maps[0]);
            while (true)
            {
                ConsoleKeyInfo inp = Console.ReadKey(true);
                ConsoleKey input = inp.Key;
                if (input == ConsoleKey.E)
                {
                    myplayer.interact();
                }
                else
                {
                    myplayer.mov(input);
                }
            }
            Console.ReadKey(true);
        }
    }
}
