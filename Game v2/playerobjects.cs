using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{
    public class pointer
    {
        private Area inthisarea;
        private int x;
        private int y;
        private ConsoleKey direction;
        private char icon;
        public pointer(Area area)
        {
            icon = 'P';
            inthisarea = area;
            Coord start = area.getstart();
            x = start.getx();
            y = start.gety();
            direction = ConsoleKey.D;
            BottomScreen.mov(direction);
            draw();

        }
        public ConsoleKey getdirection()
        {
            return direction;
        }
        public void changearea(int inx, int iny, Area area)
        {
            inthisarea = area;
            x = inx;
            y = iny;
            draw();
        }
        public bool mov(ConsoleKey direction)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            if (this.direction == direction)
            {
                switch (direction)
                {
                    case ConsoleKey.W:
                        if (!inthisarea.isedge(x, (y - 1)))
                        {
                            Console.Write(" ");
                            y--;
                            draw();
                            return true;
                        }
                        break;
                    case ConsoleKey.S:
                        if (!inthisarea.isedge(x, (y + 1)))
                        {
                            Console.Write(" ");
                            y++;
                            draw();
                            return true;

                        }
                        break;
                    case ConsoleKey.D:
                        if (!inthisarea.isedge(x+1, y ))
                        {
                            Console.Write(" ");
                            x++;
                            draw(); 
                            return true;

                        }
                        break;
                    case ConsoleKey.A:
                        if (!inthisarea.isedge(x - 1, y))
                        {
                            Console.Write(" ");
                            x--;
                            draw(); 
                            return true;
                        }
                        break;
                }
            }
            else if (direction == ConsoleKey.D || direction == ConsoleKey.A || direction == ConsoleKey.W || direction == ConsoleKey.S)
            {
                this.direction = direction;
                BottomScreen.mov(direction);
            }
            return false;
        }
        public int interact()
        {
            switch (direction)
            {
                case ConsoleKey.W:
                    if (inthisarea.ischest(x, y - 1)) 
                    {
                        return 1;
                    }
                    else if (inthisarea.interact(x, (y - 1)))
                    {
                        return inthisarea.getdoorkey(x, (y - 1));
                    }
                    break;
                case ConsoleKey.S:
                    if (inthisarea.ischest(x, y + 1))
                    {
                        return 1;
                    }
                    else if (inthisarea.interact(x, (y + 1)))
                    {
                        return inthisarea.getdoorkey(x, (y + 1));
                    }
                    break;
                case ConsoleKey.D:
                    if (inthisarea.ischest(x + 1, y))
                    {
                        return 1;
                    }
                    else if (inthisarea.interact(x + 1, y))
                    {
                        return inthisarea.getdoorkey(x+1,y);
                    }
                    break;

                case ConsoleKey.A:
                    if (inthisarea.ischest(x - 1, y))
                    {
                        return 1;
                    }
                    else if (inthisarea.interact(x - 1, y))
                    {
                        return inthisarea.getdoorkey(x -1 , y);
                    }
                    break;
            }
            return 0;
        }
        private void draw()
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
            Console.Write(icon);
        }

        public List<inventoryitem> chestinteract()
        {
            switch (direction)
            {
                case ConsoleKey.W:
                    return inthisarea.interactwithchest(x, y-1);
                case ConsoleKey.S:
                    return inthisarea.interactwithchest(x, y + 1);
                case ConsoleKey.D:
                    return inthisarea.interactwithchest(x+1,y);
                case ConsoleKey.A:
                    return inthisarea.interactwithchest(x-1, y);

            }
            return new List<inventoryitem>();
        }
    }
    public class player
    {
        private int health;
        private inventory myinventory;

        public player()
        {
            myinventory = new inventory();
        }

        public void addtoinventory(List<inventoryitem> p)
        {
            foreach (inventoryitem item in p)
            {
                myinventory.additems(item);
            }
        }
        public void inventoryprint()
        {
            RightScreen.print(myinventory.getitems(), myinventory.getweapons());
        }
    }
    public class  inventory
    {
        protected List<inventoryitem> items;
        protected Stack<inventoryitem> weapons;
        public inventory()
        {
            items = new List<inventoryitem>();
            items.Add(new health_potion(10, 1));
            weapons = new Stack<inventoryitem>(100);
            weapons.Push(new weapon("fists", 1, "hand", "blunt"));
        }
        public void additems(inventoryitem i)
        {
            if (i.getitemtype() == "weapon")
            {
                weapons.Push(i);
            }
            else
            {
                items.Add(i);
            }
        }
        public string getweaponinhand()
        {
            return weapons.Peek().getdescription();
        }
        public void dropweapon()
        {
            weapons.Pop();
        }
        
        public List<inventoryitem> getitems()
        {
            return items;
        }

        public Stack<inventoryitem> getweapons()
        {
            return weapons;
        }
    }
}
