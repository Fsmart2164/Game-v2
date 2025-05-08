using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Game_v2
{
    internal class Program
    {
        static string Setup()
        {
            Console.CursorVisible = true;
            Console.WriteLine("welcome to the adventure game \r\nuse W A S D to move\r\nmake sure you dont hold down any keys \r\npress tab to open inventory \r\npress e to interact with an object\r\nyour player is p\r\nenemys are E\r\nchests are M\r\nwalls look like walls and doors are stick out of walls\r\nplease enter your name");
            string name = Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = false;
            return name;
        }
        static dooruse changemaps(List<Area> m, int key, int currentmapindex)
        {
            int ind = 0;
            Coord c;
            dooruse d = new dooruse();
            for (int i = 0; i < m.Count + 1; i++)
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
                new chest(10,3,new List<inventoryitem> {new health_potion(30,2)}),
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
            };  // finished
            Area map1 = new Area(startcords);

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
            };// finished
            Area map2 = new Area(secondcoords);

            List<Coord> sighthcoords = new List<Coord>()
            {
                new edge(2,1,"-"),
                new edge(3,1,"-"),
                new edge(4,1,"-"),
                new edge(5,1,"-"),

                new edge(1,2,"|"),
                new edge(6,2,"|"),
                new chest(2,2,new List<inventoryitem> {new weapon("claymore",5,"greatsword","slash")}),

                new edge(1,3,"|"),
                new door(6,3,23), // door
                new edge(7,3," "), // doorback
                new chest(2,3,new List<inventoryitem> {new weapon("longsword",5,"straitsword","slash")}),

                new edge(2,4,"-"),
                new edge(6,4,"|"),

                new edge(3,5,"|"),
                new edge(6,5,"|"),

                new edge(4,6,"-"),
                new edge(5,6,"-"),
            };// finished
            Area map3 = new Area(sighthcoords);

            List<Coord> fithcoords = new List<Coord>()
            {
                new edge(2,1,"-"),
                new edge(3,1,"-"),
                new edge(4,1,"-"),
                new edge(5,1,"-"),
                new edge(6,1,"-"),
                new edge(7,1,"-"),
                new door(8,1,25),       // door
                new edge(8,0," "),      // doorback
                new edge(9,1,"-"),
                new edge(10,1,"-"),

                new edge(1,2,"|"),
                new edge(7,2,"|"),
                new edge(11,2,"|"),

                new edge(1,3,"|"),
                new edge(3,3,"-"),
                new edge(4,3,"-"),
                new edge(5,3,"|"),
                new edge(9,3,"|"),
                new edge(12,3,"|"),

                new edge(1,4,"|"),
                new edge(5,4,"-"),
                new edge(6,4,"-"),
                new edge(7,4,"-"),
                new edge(8,4,"-"),
                new edge(9,4,"-"),
                new edge(10,4,"-"),
                new edge(12,4,"|"),

                new edge(1,5,"|"),
                new edge(2,5,"-"),
                new edge(3,5,"-"),
                new edge(6,5,"|"),
                new edge(12,5,"|"),
                new edge(13,5,"-"),
                new edge(14,5,"-"),
                new edge(15,5,"-"),

                new edge(1,6,"|"),
                new chest(2,6,new List<inventoryitem> {new weapon("broadsword",5,"straitsword","slash")}),
                new edge(3,6,"|"),
                new edge(4,6,"-"),
                new edge(6,6,"|"),
                new edge(8,6,"-"),
                new edge(9,6,"-"),
                new edge(10,6,"-"),
                new edge(11,6,"-"),
                new edge(12,6,"|"),
                new edge(16,6,"|"),

                new edge(1,7,"|"),
                new edge(4,7,"|"),
                new edge(6,7,"|"),
                new edge(9,7,"|"),
                new edge(12,7,"|"),
                new chest(13,7,new List<inventoryitem> {new health_potion(10,2)}),
                new edge(14,7,"|"),
                new edge(16,7,"|"),

                new edge(1,8,"|"),
                new edge(3,8,"-"),
                new edge(4,8,"-"),
                new edge(6,8,"|"),
                new edge(7,8,"-"),
                new edge(9,8,"|"),
                new edge(11,8,"-"),
                new edge(12,8,"-"),
                new edge(13,8,"-"),
                new edge(16,8,"|"),

                new edge(1,9,"|"),
                new edge(6,9,"|"),
                new edge(14,9,"-"),
                new edge(16,9,"|"),

                new edge(1,10,"|"),
                new edge(2,10,"-"),
                new edge(3,10,"-"),
                new edge(4,10,"-"),
                new edge(7,10,"-"),
                new edge(8,10,"-"),
                new edge(9,10,"-"),
                new edge(10,10,"-"),
                new edge(11,10,"-"),
                new edge(16,10,"|"),

                new edge(1,11,"|"),
                new edge(7,11,"|"),
                new edge(10,11,"-"),
                new edge(11,11,"-"),
                new edge(12,11,"-"),
                new edge(13,11,"-"),
                new edge(16,11,"|"),

                new edge(1,12,"|"),
                new edge(2,12,"-"),
                new edge(4,12,"-"),
                new edge(5,12,"-"),
                new edge(8,12,"-"),
                new edge(15,12,"-"),
                new edge(16,12,"|"),

                new door(1,13,53),       //door
                new edge(0,13," "),      //doorback
                new edge(1,14," "),
                new edge(5,13,"|"),
                new edge(9,13,"|"),
                new edge(11,13,"-"),
                new edge(12,13,"-"),
                new edge(13,13,"-"),
                new edge(16,13,"|"),

                new edge(2,14,"-"),
                new edge(3,14,"-"),
                new edge(4,14,"-"),
                new edge(5,14,"-"),
                new edge(6,14,"-"),
                new edge(7,14,"-"),
                new edge(8,14,"-"),
                new edge(9,14,"-"),
                new door(10,14,54),      //door
                new edge(10,15," "),     //doorback
                new edge(11,14,"-"),
                new edge(12,14,"-"),
                new edge(13,14,"-"),
                new edge(14,14,"-"),
                new edge(15,14,"-"),
            };  // finished
            Area map4 = new Area(fithcoords);

            List<Coord> fiurthcoord = new List<Coord>()
            {
                new edge(2,1,"-"),
                new door(3,1,47),      // door
                new edge(3,0," "),     // door back
                new edge(4,1,"-"),
                new edge(5,1,"-"),
                new edge(6,1,"-"),
                new edge(7,1,"-"),
                new edge(8,1,"-"),
                new edge(9,1,"-"),
                new edge(10,1,"-"),
                new edge(11,1,"-"),

                new edge(1,2,"|"),
                new chest(6,2,new List<inventoryitem>{new weapon("great club",12,"colosal weapon","blunt")}),
                new edge(7,2,"|"),
                new edge(12,2,"|"),

                new edge(1,3,"|"),
                new edge(2,3,"-"),
                new edge(3,3,"-"),
                new edge(6,3,"-"),
                new edge(7,3,"|"),
                new edge(9,3,"-"),
                new edge(10,3,"-"),
                new edge(12,3,"|"),

                new edge(1,4,"|"),
                new edge(7,4,"|"),
                new edge(10,4,"|"),
                new edge(12,4,"|"),

                new edge(1,5,"|"),
                new edge(3,5,"-"),
                new edge(4,5,"-"),
                new edge(5,5,"-"),
                new edge(6,5,"|"),
                new edge(9,5,"-"),
                new edge(10,5,"-"),
                new edge(12,5,"|"),

                new edge(1,6,"|"),
                new edge(6,6,"|"),
                new edge(8,6,"|"),
                new edge(12,6,"|"),

                new edge(1,7,"|"),
                new edge(2,7,"-"),
                new edge(3,7,"-"),
                new edge(4,7,"-"),
                new edge(6,7,"|"),
                new edge(8,7,"|"),
                new edge(10,7,"-"),
                new edge(11,7,"-"),
                new edge(12,7,"|"),

                new edge(1,8,"|"),
                new edge(6,8,"|"),
                new edge(8,8,"|"),
                new edge(12,8,"|"),

                new edge(1,9,"|"),
                new edge(3,9,"-"),
                new edge(4,9,"-"),
                new edge(5,9,"-"),
                new edge(6,9,"|"),
                new edge(9,9,"-"),
                new edge(10,9,"-"),
                new edge(12,9,"|"),

                new edge(1,10,"|"),
                new edge(5,10,"|"),
                new edge(8,10,"|"),
                new edge(12,10,"|"),

                new edge(1,11,"|"),
                new edge(2,11,"-"),
                new edge(3,11,"-"),
                new edge(5,11,"|"),
                new edge(7,11,"-"),
                new edge(8,11,"|"),
                new edge(10,11,"-"),
                new edge(11,11,"-"),
                new edge(12,11,"|"),

                new edge(1,12,"|"),
                new edge(5,12,"|"),
                new edge(8,12,"|"),
                new edge(12,12,"|"),

                new edge(1,13,"|"),
                new edge(3,13,"-"),
                new edge(4,13,"|"),
                new edge(6,13,"-"),
                new edge(8,13,"|"),
                new edge(9,13,"-"),
                new edge(10,13,"-"),
                new edge(12,13,"|"),

                new edge(1,14,"|"),
                new edge(4,14,"|"),
                new edge(8,14,"|"),
                new edge(12,14,"|"),

                new edge(1,15,"|"),
                new edge(4,15,"|"),
                new edge(8,15,"|"),
                new edge(10,15,"-"),
                new edge(11,15,"-"),
                new edge(12,15,"|"),

                new edge(1,16,"|"),
                new edge(2,16,"-"),
                new edge(5,16,"-"),
                new edge(7,16,"-"),
                new edge(8,16,"|"),
                new edge(12,16,"|"),

                new edge(1,17,"|"),
                new edge(5,17,"|"),
                new edge(9,17,"-"),
                new edge(10,17,"|"),
                new edge(12,17,"|"),

                new edge(1,18,"|"),
                new edge(3,18,"-"),
                new edge(4,18,"-"),
                new edge(5,18,"|"),
                new edge(6,18,"-"),
                new edge(7,18,"-"),
                new edge(9,18,"|"),
                new edge(10,18,"|"),
                new edge(12,18,"|"),

                new edge(1,19,"|"),
                new edge(9,19,"|"),
                new edge(12,19,"|"),

                new edge(2,20,"-"),
                new edge(3,20,"-"),
                new edge(4,20,"-"),
                new edge(5,20,"-"),
                new edge(6,20,"-"),
                new edge(7,20,"-"),
                new edge(8,20,"-"),
                new edge(9,20,"-"),
                new door(10,20,24),      // door
                new edge(10,21," "),     // door back
                new edge(11,20,"-"),
            }; // finished
            Area map5 = new Area(fiurthcoord);

            List<Coord> sevencoord = new List<Coord>()
            {
                new edge(2,1,"-"),
                new edge(3,1,"-"),
                new edge(4,1,"-"),
                new edge(6,1,"-"),
                new edge(7,1,"-"),
                new edge(8,1,"-"),

                new edge(1,2,"|"),
                new edge(5,2,"|"),
                new edge(9,2,"|"),

                new edge(1,3,"|"),
                new door(9,3,78),          // door
                new edge(10,3," "),        // door back

                new edge(1,4,"|"),
                new edge(5,4,"|"),
                new edge(9,4,"|"),

                new edge(2,5,"-"),
                new edge(4,5,"-"),
                new edge(6,5,"-"),
                new edge(7,5,"-"),
                new edge(8,5,"-"),

                new edge(1,6,"|"),
                new edge(5,6,"|"),

                new edge(1,7,"|"),
                new edge(5,7,"|"),
                new edge(8,7,"-"),
                new edge(9,7,"-"),
                new edge(10,7,"-"),

                new edge(1,8,"|"),
                new edge(5,8,"|"),
                new edge(7,8,"|"),
                new edge(11,8,"|"),

                new edge(2,9,"-"),
                new edge(4,9,"-"),
                new door(7,9,89),          // door
                new edge(6,9," "),          // door back
                new chest(10,9,new List<inventoryitem>{new health_potion(120,2),new note("this is the wrong way to go btw")}),
                new edge(11,9,"|"),

                new edge(1,10,"|"),
                new edge(5,10,"|"),
                new edge(7,10,"|"),
                new edge(11,10,"|"),

                new edge(1,11,"|"),
                new edge(5,11,"|"),
                new edge(8,11,"-"),
                new edge(9,11,"-"),
                new edge(10,11,"-"),

                new edge(1,12,"|"),
                new edge(5,12,"|"),

                new edge(2,13,"-"),
                new edge(4,13,"-"),

                new edge(1,14,"|"),
                new edge(5,14,"|"),

                new edge(1,15,"|"),
                new edge(5,15,"|"),

                new edge(1,16,"|"),
                new edge(5,16,"|"),

                new edge(2,17,"-"),
                new door(3,17,47),        // door
                new edge(3,18," "),       // doorback
                new edge(4,17,"-"),
            };  // finished
            Area map6 = new Area(sevencoord);

            List<Coord> lockcoords = new List<Coord>()
            {
                new edge(4,1,"-"),
                new door(5,1,53),           // door
                new edge(5,0," "),          // doorback
                new edge(6,1,"-"),

                new edge(4,2,"|"),
                new edge(6,2,"|"),

                new edge(4,3,"|"),
                new edge(6,3,"|"),

                new edge(4,4,"|"),
                new edge(6,4,"|"),

                new edge(3,5,"-"),
                new edge(7,5,"-"),

                new edge(2,6,"-"),
                new edge(8,6,"-"),

                new edge(1,7,"|"),
                new edge(9,7,"|"),

                new edge(1,8,"|"),
                new edge(9,8,"|"),

                new edge(1,9,"|"),
                new chest(5,9,new List<inventoryitem>{new health_potion(50,3),new weapon("potion sword",-1,"balloon","squish")}),
                new edge(9,9,"|"),

                new edge(1,10,"|"),
                new edge(9,10,"|"),

                new edge(2,11,"-"),
                new edge(8,11,"-"),

                new edge(3,12,"-"),
                new edge(7,12,"-"),

                new edge(4,13,"-"),
                new edge(5,13,"-"),
                new edge(6,13,"-"),
            };  // finished
            Area map7 = new Area(lockcoords);

            List<Coord> fakecoords = new List<Coord>()
            {
                new edge(2,1,"|"),
                new edge(3,1,"-"),
                new edge(4,1,"-"),
                new edge(5,1,"-"),
                new edge(6,1,"-"),
                new edge(7,1,"-"),
                new edge(8,1,"-"),
                new edge(9,1,"-"),
                new edge(10,1,"|"),
                new edge(11,1,"-"),
                new door(12,1,54),           // door
                new edge(12,0," "),          // doorback
                new edge(13,1,"-"),
                new edge(14,1,"|"),

                new edge(2,2,"|"),
                new edge(14,2,"|"),

                new edge(2,3,"|"),
                new chest(3,3,new List<inventoryitem>{new weapon("curved greatsword",9,"greatsword","slash")}),
                new edge(10,3,"|"),
                new edge(14,3,"|"),

                new edge(2,4,"|"),
                new edge(3,4,"-"),
                new edge(4,4,"-"),
                new edge(5,4,"-"),
                new edge(7,4,"-"),
                new edge(8,4,"-"),
                new edge(9,4,"-"),
                new edge(10,4,"|"),
                new edge(11,4,"-"),
                new edge(12,4,"-"),
                new edge(13,4,"-"),
                new edge(14,4,"|"),

                new edge(2,5,"|"),
                new edge(10,5,"|"),

                new edge(2,6,"|"),
                new edge(10,6,"|"),

                new edge(2,7,"|"),
                new edge(3,7,"-"),
                new edge(4,7,"-"),
                new edge(5,7,"-"),
                new edge(7,7,"-"),
                new edge(8,7,"-"),
                new edge(9,7,"-"),
                new edge(10,7,"|"),

                new edge(2,8,"|"),
                new edge(10,8,"|"),

                new edge(2,9,"|"),
                new chest(3,9,new List<inventoryitem>{new health_potion(100,1),new note("seek below")}),
                new edge(10,9,"|"),

                new edge(2,10,"|"),
                new edge(3,10,"-"),
                new edge(4,10,"-"),
                new edge(5,10,"-"),
                new door(6,10,98),      //door
                new edge(6,11," "),     //doorback
                new edge(7,10,"-"),
                new edge(8,10,"-"),
                new edge(9,10,"-"),
                new edge(10,10,"|"),
            };  // finished
            Area map8 = new Area(fakecoords);

            List<Coord> nearlylast = new List<Coord>()
            {
                new edge(2,1,"-"),
                new edge(3,1,"-"),
                new edge(5,1,"-"),
                new door(6,1,98),     // door
                new edge(6,0," "),    // doorback
                new edge(7,1,"-"),
                new edge(9,1,"-"),
                new edge(10,1,"-"),

                new edge(1,2,"|"),
                new edge(4,2,"|"),
                new edge(8,2,"|"),
                new edge(11,2,"|"),

                new edge(1,3,"|"),
                new edge(4,3,"|"),
                new edge(8,3,"|"),
                new edge(11,3,"|"),

                new edge(1,4,"|"),
                new chest(2,4,new List<inventoryitem>{new health_potion(30,3)}),
                new chest(10,4,new List<inventoryitem>{new note("nothing")}),
                new edge(11,4,"|"),

                new edge(1,5,"|"),
                new edge(4,5,"|"),
                new edge(8,5,"|"),
                new edge(11,5,"|"),

                new edge(1,6,"|"),
                new edge(4,6,"|"),
                new edge(8,6,"|"),
                new edge(11,6,"|"),

                new edge(2,7,"-"),
                new edge(3,7,"-"),
                new edge(5,7,"-"),
                new edge(7,7,"-"),
                new edge(9,7,"-"),
                new edge(10,7,"-"),

                new edge(4,8,"|"),
                new edge(8,8,"|"),

                new edge(4,9,"|"),
                new edge(8,9,"|"),

                new edge(5,10,"-"),
                new door(6,10,100),         // door
                new edge(6,11," "),         // doorback
                new edge(6,11," "),
                new edge(7,10,"-"),
            };
            Area map9 = new Area(nearlylast);

            List<Coord> last = new List<Coord>()
            {
                new edge(4,1,"-"),
                new door(5,1,100),     // door
                new edge(5,0," "),     // doorback
                new edge(6,1,"-"),

                new edge(4,2,"|"),
                new edge(6,2,"|"),

                new edge(4,3,"|"),
                new edge(6,3,"|"),

                new edge(4,4,"|"),
                new edge(6,4,"|"),

                new edge(3,5,"-"),
                new chest(4,5,new List<inventoryitem>{new note("turn back")}),
                new chest(6,5,new List<inventoryitem>{new note("flee while you still can")}),
                new edge(7,5,"-"),

                new edge(2,6,"-"),
                new edge(8,6,"-"),

                new edge(1,7,"-"),
                new edge(9,7,"-"),

                new edge(2,8,"-"),
                new edge(3,8,"-"),
                new edge(4,8,"-"),
                new door(5,8,101),
                new edge(6,8,"-"),
                new edge(7,8,"-"),
                new edge(8,8,"-"),
            };
            Area map10 = new Area(last);

            List<Coord> mark = new List<Coord>()
            {
                new edge(2,1,"-"),

                new edge(1,2,"|"),
                new door(3,2,89),         // door
                new edge(3,1," "),
                new edge(4,2," "),
                new edge(5,2,"-"),
                new edge(6,2,"-"),

                new edge(1,3,"|"),
                new edge(3,3,"|"),
                new edge(4,3,"|"),
                new edge(7,3,"|"),

                new edge(1,4,"|"),
                new edge(3,4,"|"),
                new door(4,4,78),
                new edge(7,4,"|"),

                new edge(1,5,"|"),
                new edge(3,5,"|"),
                new edge(4,5,"|"),
                new edge(7,5,"|"),

                new edge(1,6,"|"),
                new edge(3,6,"-"),
                new edge(6,6,"|"),

                new edge(1,7,"|"),
                new edge(6,7,"|"),

                new edge(2,8,"-"),
                new edge(3,8,"-"),
                new edge(4,8,"-"),
                new edge(5,8,"-"),
            };
            Area map11 = new Area(mark);
            //enemys
            map2.add(new Warrior("asylum demon", 10, 12, 12,100));
            map4.add(new Warrior("undead soldier", 3, 4, 2, 50));
            map4.add(new Warrior("undead soldier", 3, 11, 4, 50));
            map4.add(new Warrior("undead soldier", 3, 2, 8, 50));
            map4.add(new Warrior("undead soldier", 3, 13, 10, 50));
            map4.add(new Warrior("perc goblin", 12, 7, 13, 30));
            map6.add(new Warrior("mark", 12, 9, 9, 125));

            map5.add(new Warrior("hollow", 6, 6, 11, 100));
            map7.add(new Warrior("potion goblin", 3, 5, 3, 300));
            map8.add(new Warrior("jailer", 7, 6,4 , 100));
            map8.add(new Warrior("jailer", 7, 6, 6, 90));
            map8.add(new Warrior("jailer", 7, 6, 9, 120));
            map9.add(new Warrior("misbegotten", 8, 4, 4, 160));
            map9.add(new Warrior("misbegotten", 8, 8, 4, 160));
            map9.add(new Warrior("misbegotten", 8, 6, 7, 150));
            map10.add(new Warrior("living failures",18,5,7,300));


            // adding to main maps
            List<Area> maps = new List<Area>();
            maps.Add(map1);
            maps.Add(map2);
            maps.Add(map3);
            maps.Add(map4);
            maps.Add(map5);
            maps.Add(map6);
            maps.Add(map7);
            maps.Add(map8);
            maps.Add(map9);
            maps.Add(map10);
            maps.Add(map11);
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
            player me = new player(Setup());
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
                    if (key == 1)                             // chest
                    {
                        List<inventoryitem> reach = myplayer.chestinteract();
                        me.addtoinventory(reach);
                    }
                    else if (key == 2)                        // enemy
                    {
                        Warrior foe = myplayer.enemyinteract();
                        
                        if (fight(me, foe))
                        {
                            break;
                        }
                        
                    }
                    else if (key == 101)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("you escaped");

                        while (true)
                        {
                            Console.ReadKey(true);
                        }
                    }
                    else if (key != 0)                        // doorkey
                    {
                        dooruse teleport = changemaps(maps, key, x);
                        x = teleport.index;
                        Console.Clear();
                        maps[x].printmap();
                        myplayer.changearea(teleport.x, teleport.y, maps[x]);
                        howmany_after_tp = 0;
                    }
                    if (key == 2)
                    {
                        maps[x].printmap();
                        myplayer.draw();
                    }
                    

                }
                if (input == ConsoleKey.Tab)
                {
                    me.inventoryprint();
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
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.Red;
            while (true)
            {
                Console.Write("u died");
                if (Console.CursorLeft == 100)
                {
                    Console.CursorTop++;
                    Console.CursorLeft = 0;
                }
                if (Console.CursorTop == 60) break;
            }
           
        }
        static bool fight(player mc, Warrior enemy)
        {
            dice sixsideddie = new dice();
            while (mc.isalive() && enemy.isalive())
            {
                mc.attack(enemy, sixsideddie.roll());
                Console.WriteLine();
                RightScreen.print(mc.getName() + " attacks");
                RightScreen.print(mc.getName() + " health is " + mc.getHealth() + "                       " + enemy.getName() + " health is " + enemy.getHealth());
                if (!enemy.isalive()) break;


                enemy.attack(mc, sixsideddie.roll());
                Console.WriteLine();
                RightScreen.print(enemy.getName() + " attacks");
                RightScreen.print(mc.getName() + " health is " + mc.getHealth() + "                       " + enemy.getName() + " health is " + enemy.getHealth());

                if (mc.canheal() && mc.isalive())
                {
                    while (true)
                    {
                        RightScreen.print("would you like to heal? y/n");
                        ConsoleKey intput = Console.ReadKey(true).Key;
                        if (intput == ConsoleKey.Y)
                        {
                            mc.heal();
                            break;
                        }
                        else if (intput == ConsoleKey.N)
                        {
                            break;
                        }
                    }
                }
            }
            bool win = whoWon(mc, enemy);
            RightScreen.clear();
            RightScreen.reset_fight_print();
            return win;
        }
        static bool whoWon(Warrior p1, Warrior p2)
        {
            if (p1.isalive())
            {
                RightScreen.print(p1.getName() + " has vanquished " + p2.getName());
                Console.ReadKey(true);
                return false;
            }
            else if (p2.isalive()) RightScreen.print(p2.getName() + " has vanquished " + p1.getName());
            else RightScreen.print(p1.getName() + " and " + p2.getName() + " both perished fighting eachother");
            Console.ReadKey(true);
            return true;
        }
        struct dooruse
        {
            public int x;
            public int y;
            public int index;
        }
    }
}
