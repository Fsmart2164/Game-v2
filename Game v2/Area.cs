using System;
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
            foreach (Warrior w in enemys)
            {
                Coord c = w.getlocation();
                if (x == c.getx() && y == c.gety() && c.getedgetype() != "start" && w.isalive())
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

        public bool isenemy(int x, int y)
        {
            foreach (Warrior warrior in enemys)
            {
                Coord c = warrior.getlocation();
                if (x == c.getx() && y == c.gety() && c.getedgetype() == "enemy")
                {
                    return true;
                }

            }
            return false;
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

        public bool ischest(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() == "chest")
                {
                    return true;
                }
            }
            return false;
        }

        public List<inventoryitem> interactwithchest(int x, int y)
        {
            foreach (Coord c in cordlist)
            {
                if (x == c.getx() && y == c.gety() && c.getedgetype() == "chest")
                {
                    return c.interactchest();
                }
            }
            return null;
        }

        private List<Coord> cordlist;
        private List<Warrior> enemys;

        public Area(List<Coord> coords)
        {
            cordlist = new List<Coord>(coords);
            enemys = new List<Warrior>();
        }
        public void printmap()
        {
            foreach (Coord c in cordlist)
            {

                Console.CursorLeft = c.getx();
                Console.CursorTop = c.gety();
                Console.Write(c.icon());
            }
            foreach (Warrior w in enemys)
            {
                Coord c = w.getlocation();
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

        public void add(Warrior e)
        {
            enemys.Add(e);
        }

        public Warrior interactwithenemy(int x, int y)
        {
            foreach (Warrior w in enemys)
            {
                Coord c = w.getlocation();
                if (x == c.getx() && y == c.gety() && c.getedgetype() == "enemy")
                {
                    return w;
                }
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
        public virtual List<inventoryitem> interactchest()
        {
            return null;
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
        public door(int inx, int iny, int key) : base(inx, iny, "/")
        {
            this.key = key;
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

    public class enemy : Coord
    {

        public enemy(int x, int y) : base(x, y)
        {

        }
        public override string getedgetype()
        {
            return "enemy";
        }
        public override string icon()
        {
            return "E";
        }
    }
}

