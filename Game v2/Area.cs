using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{
    public class Map
    {
        List<Area> map;
        public Map()
        {

        }
    }

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

                Console.CursorTop = c.getx();
                Console.CursorLeft = c.gety();
                switch (c.getedgetype())
                {
                    case "top":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.CursorLeft--;
                        break;
                    case "left":
                        Console.CursorLeft--;
                        Console.Write("|");
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        break;
                    case "right":
                        Console.CursorLeft++;
                        Console.Write("|");
                        break;
                    case "bottom":
                        Console.CursorTop++;
                        Console.Write("-");
                        Console.CursorLeft--;
                        break;
                    case "topleft":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.Write("|");
                        Console.CursorLeft--;
                        break;
                    case "topright":
                        Console.CursorTop--;
                        Console.Write("-");
                        Console.CursorTop++;
                        Console.Write('|');
                        Console.CursorLeft--;
                        break;
                    case "bottomleft":
                        Console.CursorTop++;
                        Console.Write("-");
                        Console.CursorTop--;
                        Console.CursorLeft--;
                        Console.CursorLeft--;
                        Console.Write('|');
                        Console.CursorLeft--;
                        break;
                    case "bottomright":
                        Console.CursorTop++;
                        Console.Write("-");
                        Console.CursorTop--;
                        Console.Write('|');
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

    public class Gateway : edge
    {
        Area[] linked;
        public Gateway(int inx, int iny, Area[] linked, string edgetype) : base(inx, iny, edgetype)
        {
            this.linked = linked;
        }
    }
}

