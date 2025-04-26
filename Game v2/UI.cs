using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        public static void print(List<inventoryitem> input)
        {
            int i = 0;
            Console.CursorTop = y;
            Console.CursorLeft = x;
            foreach (inventoryitem strings in input)
            {
                Console.Write(i + ":  ");
                Console.Write(strings.getdescription());
                Console.CursorLeft = x;
                Console.CursorTop++;
                i++;
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
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.WriteLine("                                                    ");
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(" player is facing in direction: ");
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
    }
}
