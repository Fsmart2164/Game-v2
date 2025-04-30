using System;
using System.Collections.Generic;

namespace Game_v2
{

    public static class RightScreen
    {
        private static int x = 50;
        private static int y = 1;

        public static void print(string[] input)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            foreach (string strings in input)
            {
                Console.Write(strings);
                Console.CursorLeft = x;
                Console.CursorTop++;
            }
        }
        public static void clear()
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("                                                ");
                y++;
                Console.CursorLeft = x;
            }


        }
        public static void print(List<inventoryitem> inventory)
        {
            int i = 0;
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write("which option would you like");
            Console.CursorLeft = x;
            Console.CursorTop++;
            foreach (inventoryitem strings in inventory)
            {
                Console.Write(" :  ");
                Console.Write(strings.getdescription());
                Console.CursorLeft = x;
                Console.CursorTop++;
                i++;
            }
            Console.Write("   return");
            Console.CursorTop = y+1;
            Console.CursorLeft = x + 2;
            Console.Write(">");
            Console.CursorLeft = x + 2;
            int choice = 0;
            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                if (input == ConsoleKey.W && choice > 0)
                {
                    Console.Write(" ");
                    Console.CursorLeft = x + 2;
                    choice--;
                    Console.CursorTop--;
                    Console.Write(">");
                    Console.CursorLeft = x + 2;
                }
                else if (input == ConsoleKey.S && choice < inventory.Count)
                {
                    Console.Write(" ");
                    Console.CursorLeft = x + 2;
                    choice++;
                    Console.CursorTop++;
                    Console.Write(">");
                    Console.CursorLeft = x + 2;
                }
                else if (input == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
            if (choice != inventory.Count)
            {
                // add to player inventory
                inventory.Remove(inventory[choice]);
                print(inventory);
            }
            else
            {
                RightScreen.clear();
            }

        }
        public static void print(string input)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(input);
        }
    }
    public static class BottomScreen
    {
        private static int x = 1;
        private static int y = 30;

        public static void mov(ConsoleKey key)
        {
            clear();
            Console.Write("player is facing in direction: ");
            switch (key)
            {
                case ConsoleKey.W:
                    Console.WriteLine("up");
                    break;
                case ConsoleKey.S:
                    Console.WriteLine("down");
                    break;
                case ConsoleKey.D:
                    Console.WriteLine("right");
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("left");
                    break;
            }
        }
        public static void bump(Coord c)
        {
            Console.CursorTop = y + 1;
            Console.CursorLeft = x;
            Console.WriteLine("                                                          ");
            Console.CursorTop = y + 1;
            Console.CursorLeft = x;
            switch (c.getedgetype())
            {
                case "wall":
                    Console.Write("you cannot walk through a wall");
                    break;
                case "chest":
                    Console.Write("that is a chest, press e to interact");
                    break;
                case "door":
                    Console.Write("that is a door, press e to interact");
                    break;
            }
        }
        public static void clear()
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.WriteLine("                                                    ");
            Console.WriteLine("                                                    ");
            Console.CursorTop = y;
            Console.CursorLeft = x;
        }
    }
}
