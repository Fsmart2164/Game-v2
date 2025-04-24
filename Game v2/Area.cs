using System;
using System.Collections.Generic;

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
                        Console.Write("/");
                        break;

                    case "leftD":
                        Console.CursorLeft--;
                        Console.Write("/");
                        break;
                    case "rightD":
                        Console.CursorLeft++;
                        Console.Write("/");
                        break;
                    case "bottomD":
                        Console.CursorTop++;
                        Console.Write("/");
                        break;


                    case "item":
                        Console.Write(c.icon());
                        break;


                }
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
    public class startpoint : Coord
    {
        startpoint(int inx, int iny) : base(inx, iny)
        {

        }
        public override string getedgetype()
        {
            return "start";
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
            return base.getedgetype() + "D";
        }
    }
    public class item : Coord
    {
        protected string name;
        public static void print(string[] input)
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
        public static void print(List<inventoryitem> input)
        {
            int i = 0;
            Console.CursorTop = 1;
            Console.CursorLeft = 40;
            foreach (inventoryitem strings in input)
            {
                Console.Write(i + ":  ");
                Console.Write(strings.getdescription());
                Console.CursorLeft = 40;
                Console.CursorTop++;
                i++;
            }
        }
        public static void print(string input)
        {
            Console.CursorTop = 1;
            Console.CursorLeft = 40;
            Console.Write(input);
        }
        public item(int inx, int iny) : base(inx, iny)
        {

        }
        public override string getedgetype()
        {
            return "item";
        }

        public virtual void interact()
        {
            item.print("generic item");
        }
    }
    public class chest : item
    {
        private List<inventoryitem> items;
        public chest(int inx, int iny, List<inventoryitem> inventory) : base(inx, iny)
        {
            items = inventory;
        }
        public override char icon()
        {
            return 'M';
        }
        public override string getedgetype()
        {
            return base.getedgetype();
        }
        public override void interact()
        {
            item.print(items);
        }
        public inventoryitem getitem(string name)
        {
            foreach (inventoryitem I in items)
            {
                if (I.getname() == name)
                {
                    items.Remove(I);
                    return I;
                }
            }
            return null;
        }
    }

    public abstract class inventoryitem
    {
        public abstract string getname();

        public abstract int use();

        public abstract string getdescription();


    }

    public class health_potion : inventoryitem
    {
        protected bool used;
        protected int amount;
        protected int strength;
        public health_potion(string health, int amount)
        {
            strength = amount;
            this.amount = amount;
            used = false;
        }
        public override string getname()
        {
            return "health potion";
        }
        public override int use()
        {
            amount--;
            if (amount == 0) used = true;
            return strength;
        }

        public override string getdescription()
        {
            return (getname() + " with a potency of " + strength);
        }

    }

    public class weapon : inventoryitem
    {
        private string name; private string weapontype; private string damagetype;
        private int attack;

        public weapon(string name, int attackdamage, string weapontype, string damagetype)
        {
            this.name = name;
            this.attack = attackdamage;
            this.weapontype = weapontype;
            this.damagetype = damagetype;
        }
        public override string getdescription()
        {
            return ("A type of " + weapontype + " " + name + " which does " + attack + " " + damagetype + " damage");
        }

        public override string getname()
        {
            return name;
        }

        public override int use()
        {
            return attack;
        }
    }

    public class pointer
    {
        private Area inthisarea;
        private int x;
        private int y;
        private string direction;
        private char icon;
        public pointer(int inx, int iny)
        {
            x = inx;
            y = iny;
            direction = "right";
        }
        public void mov(string direction)
        {
            if (this.direction == direction)
            {
                Console.Write(" ");
                if (direction == "right" &&)
                {
                    Console.Write(icon);
                }
            }
            this.direction = direction;

        }

    }
}

