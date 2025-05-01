using System;
using System.Collections.Generic;

namespace Game_v2
{
    internal class Program
    {
        static dooruse changemaps(List<Area> m, int key, int currentmapindex)
        {
            int ind = 0;
            Coord c;
            dooruse d = new dooruse();
            for (int i = 0; i < m.Count+1; i++)
            {
                if (i != currentmapindex)
                {
                   if (m[i].findcorrespondingdoor(key) != null)
                    {
                        ind = i;
                        break;
                    }
                }
            }
            c = m[ind].findcorrespondingdoor(key);
            d.index = ind;
            d.x = c.getx(); d.y = c.gety();
            return d;
        }
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

                new door(1,6,12),     // door
                new edge(0,6," "),    // doorback
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
            Area map1 = new Area(startcords);
            maps.Add(map1);
            List<Coord> secondcoords = new List<Coord>()
            {
                new edge(9,1,"-"),
                new edge(10,1,"-"),
                new edge(11,1,"-"),
                new door(12,1,24),     // door
                new edge(12,0," "),    // doorback
                new edge(13,1,"-"),
                new edge(14,1,"-"),
                new edge(15,1,"-"),

                new edge(7,2,"-"),
                new edge(8,2,"-"),
                new edge(16,2,"-"),                
                new edge(17,2,"-"),

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

                new edge(1,10,"|"),
                new edge(23,10,"|"),

                new edge(1,11,"|"),
                new edge(23,11,"|"),

                new door(1,12,23),     // door
                new edge(0,12," "),    // doorback
                new door(23,12,12),    // door
                new edge(24,12," "),   // doorback

                new edge(1,13,"|"),
                new edge(23,13,"|"),

                new edge(1,14,"|"),
                new edge(23,14,"|"),

                new edge(1,15,"|"),
                new edge(23,15,"|"),

                new edge(9,23,"-"),
                new edge(10,23,"-"),
                new edge(11,23,"-"),
                new door(12,23,25),     // door
                new edge(12,24," "),    // doorback
                new edge(13,23,"-"),
                new edge(14,23,"-"),
                new edge(15,23,"-"),

                new edge(7,22,"-"),
                new edge(8,22,"-"),
                new edge(16,22,"-"),
                new edge(17,22,"-"),

                new edge(5,21,"-"),
                new edge(6,21,"-"),
                new edge(18,21,"-"),
                new edge(19,21,"-"),

                new edge(4,20,"-"),
                new edge(20,20,"-"),

                new edge(3,19,"|"),
                new edge(21,19,"|"),

                new edge(3,18,"|"),
                new edge(21,18,"|"),

                new edge(2,17,"|"),
                new edge(22,17,"|"),

                new edge(2,16,"|"),
                new edge(22,16,"|"),
            };
            Area map2 = new Area(secondcoords);
            maps.Add(map2);
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
            bool mov = false;
            int howmany_after_tp = 5;
            List<Area> maps = initialise_maps();
            int x = 0;
            maps[x].printmap();
            pointer myplayer = new pointer(maps[x]);
            while (true)                                      // moving
            {
                ConsoleKeyInfo inp = Console.ReadKey(true);
                ConsoleKey input = inp.Key;                   // getting key input
                if (input == ConsoleKey.E)
                {
                    int key = myplayer.interact();
                    if (key != 0)
                    {
                        dooruse teleport = changemaps(maps,key,x);
                        x = teleport.index;
                        Console.Clear();
                        maps[x].printmap();
                        myplayer.changearea(teleport.x, teleport.y, maps[x]);
                        howmany_after_tp = 0;
                    }
                }
                else
                {
                    mov = myplayer.mov(input);
                }
                if (howmany_after_tp == 1)
                {
                    maps[x].printmap();
                }
                if (mov) howmany_after_tp++;
            }
        }
        struct dooruse
        {
            public int x;
            public int y;
            public int index;
        }
    }
}
