using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{

    public class Area
    {
        List<Coord> cordlist;
        public Area(List<Coord> coords)
        {
            cordlist = new List<Coord>(coords);
        }
        public void printmap()
        {
            foreach (Coord c in cordlist)
            {

                Console.CursorLeft = c.getx();
                Console.CursorTop = c.gety();
                switch (c.getedgetype())
                {
                    case "top":
                        Console.CursorTop--;
                        Console.Write("-");
                        break;
                    case "left":
                        Console.CursorLeft--;
                        Console.Write("|");
                        break;
                    case "right":
                        Console.CursorLeft++;
                        Console.Write("|");
                        break;
                    case "bottom":
                        Console.CursorTop++;
                        Console.Write("-");
                        break;
                    case "topleft":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.Write("|");
                        break;
                    case "topright":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.Write('|');
                        break;
                    case "bottomleft":
                        Console.CursorTop++;
                        Console.Write("-");
                        Console.CursorTop--;
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.Write('|');
                        break;
                    case "bottomright":
                        Console.CursorTop++;
                        Console.Write("-");
                        Console.CursorTop--;
                        Console.Write('|');
                        break;
                    case "topleftright":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.Write('|');
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.Write('|');
                        break;
                    case "leftright":
                        Console.CursorLeft--;
                        Console.Write("|");
                        Console.CursorLeft++;
                        Console.Write("|");
                        break;

                    case "topD":
                        Console.CursorTop--;
                        Console.Write("D");
                        break;

                    case "leftD":
                        Console.CursorLeft--;
                        Console.Write("D");
                        break;
                    case "rightD":
                        Console.CursorLeft++;
                        Console.Write("D");
                        break;
                    case "bottomD":
                        Console.CursorTop++;
                        Console.Write("D");
                        break;


                    case "item":
                        Console.Write(c.icon());
                        break;


                }
            }
        }

    }
    public class Coord
    {
        protected int x; protected int y;
        public Coord(int inx, int iny)
        {
            x = inx;
            y = iny;
        }
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }

        public virtual char icon()
        {
            return ' ';
        }

        public virtual string getedgetype()
        {
            return "none";
        }
    }
    public class edge : Coord
    {
        protected string edgetype;
        public edge(int inx, int iny, string edgetype) : base(inx, iny)
        {
            this.edgetype = edgetype;
        }

        public override string getedgetype()
        {
            return edgetype;
        }
    }

    public class door : edge
    {
        int[] linked;
        public door(int inx, int iny, string doorposition, int[] linked) : base(inx, iny, doorposition)
        {
            this.linked = linked;
        }
        public int transport(int innow)
        {
            if (linked[1] == innow) return linked[0];
            else return linked[1];
        }
        public override string getedgetype()
        {
            return base.getedgetype()+"D";
        }
    }
    abstract class item : Coord
    {
        static void print(string[] input)
        {
            Console.CursorTop = 1;
            Console.CursorLeft = 40;
            foreach (string strings in input)
            {
                Console.Write(strings);
                Console.CursorLeft = 40;
                Console.CursorTop++;
            }
        }
        public item(int inx,int iny) : base(inx, iny)
        {

        }
        public override string getedgetype()
        {
            return "item";
        }

        public abstract void interact();
    }
    
    public class chest : item
    {
        public chest(int inx, int iny) : base(inx, iny)
        {
            
        }
        public override char icon()
        {
            return 'C';
        }
    }
}

