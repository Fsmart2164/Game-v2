using System;
using System.CodeDom;
using System.Collections.Generic;

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

        public void interact(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() != "start")
                {
                    c.interact();
                   
                }
            }
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
        public virtual void interact()
        {

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
        int[] linked;
        public door(int inx, int iny, int[] linked) : base(inx, iny,"/")
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
            return "door";
        }
    }


}

