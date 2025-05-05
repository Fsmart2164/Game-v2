using System;
using System.Collections.Generic;
using System.Threading;
using Game_v2;

namespace Game_v2
{

    public static class RightScreen
    {
        private static List<inventoryitem> transfer = new List<inventoryitem>();
        private static int x = 50;
        private static int y = 1;
        private static int howmanyindentsblud = 0;
        private static int yowhatdafrickisdis = 1;

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
            for (int i = 0; i < 50; i++)
            {
                Console.Write("                                                                                                                                           ");
                Console.CursorTop++;
                Console.CursorLeft = x;
            }


        }
        public static List<inventoryitem> print(List<inventoryitem> inventory)
        {
            howmanyindentsblud++;
            int wegeekin = howmanyindentsblud;
            RightScreen.clear();
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
            Console.CursorTop = y + 1;
            Console.CursorLeft = x + 2;
            Console.Write(">");
            Console.CursorLeft = x + 2;
            int choice = 0;
            while (true)
            {
                if (inventory.Count == 0)
                {
                    break;
                }
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
                    break;
                }
            }
            if (choice != inventory.Count)
            {
                // add to player inventory
                transfer.Add(inventory[choice]);
                inventory.Remove(inventory[choice]);
                print(inventory);
            }
            if (wegeekin == 1)
            {
                List<inventoryitem> transering = new List<inventoryitem>();
                foreach (inventoryitem item in transfer)
                {
                    transering.Add(item);
                }
                transfer.Clear();
                RightScreen.clear();
                return transering;
            }
            else
            {
                RightScreen.clear();
                return null;
            }
        }

        public static void print(List<inventoryitem> inventory, Stack<inventoryitem> hand)
        {
            RightScreen.clear();
            int i = 0;
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write("select an item to get its description or select weapon in main hand to discard it and replace with former weapon - cannot get rid of hands");
            Console.CursorLeft = x;
            Console.CursorTop++;
            foreach (inventoryitem strings in inventory)
            {
                Console.Write(" : ");
                Console.Write(strings.getname());
                Console.CursorLeft = x;
                Console.CursorTop++;
                i++;
            }
            Console.Write(" : " + hand.Peek().getname());
            Console.CursorLeft = x;
            Console.CursorTop++;
            Console.Write(" : return");
            Console.CursorTop = y + 1;
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
                else if (input == ConsoleKey.S && choice < inventory.Count + 1)
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
                    break;
                }
            }
            if (choice == inventory.Count)
            {
                hand.Pop();
                if (hand.Count == 0) hand.Push(new weapon("fists", 1, "hand", "blunt"));
                RightScreen.clear();
            }
            else if (choice != inventory.Count + 1)
            {
                RightScreen.clear();
                Console.CursorTop = y;
                Console.CursorLeft = x;
                Console.Write("press any key to continue");
                Console.CursorTop++;
                Console.CursorLeft = x;
                Console.Write(inventory[choice].getdescription());
                Console.ReadKey(true);
                print(inventory, hand);
            }

            else
            {
                RightScreen.clear();
            }
        }

        public static void print(string s)
        {
            Console.CursorTop = yowhatdafrickisdis;
            Console.CursorLeft = x;
            foreach (char c in s)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            yowhatdafrickisdis++;
        }
        public static void reset_fight_print()
        {
            yowhatdafrickisdis = y;
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

