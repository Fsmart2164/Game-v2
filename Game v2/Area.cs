using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Game_v2
{

    public class Area
    {
        public bool isedge(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() != "start")
                {
                    BottomScreen.bump(c);
                    return true;
                }
            }
            return false;
        }
        public Coord findstart()
        {
            foreach (Coord c in cordlist)
            {
                string temp = c.getedgetype();
                if (temp == "start")
                {
                    return c;
                }
            }
            return null;
        }

        public bool interact(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() != "start")
                {
                    return c.interact();
                }
            }
            return false;
        }

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
                Console.Write(c.icon());
            }
        }

        public Coord getstart()
        {
            foreach (Coord c in cordlist)
            {
                if (c.getedgetype() == "start") return c;
            }
            return null;
        }

        public int getdoorkey(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() == "door")
                {
                    
                    return c.getkey();
                }
            }
            return 0;
        }

        public Coord findcorrespondingdoor(int key)
        {
            foreach (Coord c in cordlist)
            {
                if (c.getkey() == key) return c;
            }
            return null;
        }
    }
    public class Coord
    {
        protected string icond;
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

        public virtual string icon()
        {
            return " ";
        }

        public virtual string getedgetype()
        {
            return "none";
        }
        public virtual bool interact()
        {
            return false;
        }
        public virtual int getkey()
        {
            return 0;
        }
    }

    public class startpoint : Coord
    {
        public startpoint(int inx, int iny) : base(inx, iny)
        {

        }
        public override string getedgetype()
        {
            return "start";
        }
    }

    public class edge : Coord
    {
        public edge(int inx, int iny, string doortype) : base(inx, iny)
        {
            icond = doortype;
        }

        public override string getedgetype()
        {
            return "wall";
        }
        public override string icon()
        {
            return icond;
        }

    }

    public class door : edge
    {
        int key;
        bool used;
        public door(int inx, int iny, int key) : base(inx, iny,"/")
        {
            this.key = key;
            used = true;
        }
        public override bool interact()
        {
            return true;

        }
        public override int getkey()
        {
            return key;
        }
        public override string getedgetype()
        {
            return "door";
        }
    }


}

