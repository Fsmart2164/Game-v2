using System;
using System.Collections.Generic;

namespace Game_v2
{
    internal class Program
    {
        static string Setup()
        {
            Console.WriteLine("welcome to the adventure game \r\nuse W A S D to move \r\npress tab to open inventory \r\npress e to interact with an object\r\nyour player is p\r\nenemys are E\r\nchests are M\r\nwalls look like walls and doors are stick out of walls\r\nplease enter your name");
            string name = Console.ReadLine();
            Console.Clear();
            return name;
        }
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
            };
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
            };
            Area map2 = new Area(secondcoords);

            List<Coord> sighthcoords = new List<Coord>() 
            {
                new edge(2,1,"-"),
                new edge(3,1,"-"),
                new edge(4,1,"-"),
                new edge(5,1,"-"),

                new edge(1,2,"|"),
                new edge(6,2,"|"),

                new edge(1,3,"|"),
                new door(6,3,23),

                new edge(2,4,"-"),
                new edge(6,4,"|"),

                new edge(3,5,"|"),
                new edge(6,5,"|"),

                new edge(4,6,"-"),
                new edge(5,6,"-"),
            };
            Area map3 = new Area(sighthcoords);

            //enemys
            map2.add(new Warrior("asylum demon", 10, 12, 12));

            // adding to main maps
            List<Area> maps = new List<Area>();
            maps.Add(map1);
            maps.Add(map2);
            maps.Add(map3);

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
                    else if (key != 0)                        // doorkey
                    {
                        dooruse teleport = changemaps(maps, key, x);
                        x = teleport.index;
                        Console.Clear();
                        maps[x].printmap();
                        myplayer.changearea(teleport.x, teleport.y, maps[x]);
                        howmany_after_tp = 0;
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
            Console.WriteLine("u died");
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

                if (mc.canheal())
                {
                    RightScreen.print("would you like to heal? y/n");
                    char intput = Console.ReadKey(true).KeyChar;
                    if (intput == 'y') mc.heal();
                }
            }
            bool win = whoWon(mc, enemy);
            RightScreen.clear();
            return win;
        }
        static bool whoWon(Warrior p1, Warrior p2)
        {
            if (p1.isalive()) 
            { 
                RightScreen.print(p1.getName()+" has vanquished " + p2.getName());
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
