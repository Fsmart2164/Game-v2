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
        public void mov(ConsoleKey direction)
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
                        }
                        break;
                    case ConsoleKey.S:
                        if (!inthisarea.isedge(x, (y + 1)))
                        {
                            Console.Write(" ");
                            y++;
                            draw();
                        }
                        break;
                    case ConsoleKey.D:
                        if (!inthisarea.isedge(x+1, y ))
                        {
                            Console.Write(" ");
                            x++;
                            draw();
                        }
                        break;
                    case ConsoleKey.A:
                        if (!inthisarea.isedge(x - 1, y))
                        {
                            Console.Write(" ");
                            x--;
                            draw();
                        }
                        break;
                }
            }
            else if (direction == ConsoleKey.D || direction == ConsoleKey.A || direction == ConsoleKey.W || direction == ConsoleKey.S)
            {
                this.direction = direction;
                BottomScreen.mov(direction);
            }
                

        }
        public int interact()
        {
            switch (direction)
            {
                case ConsoleKey.W:
                    if (inthisarea.interact(x, (y - 1)))
                    {
                        return inthisarea.getdoorkey(x,(y - 1));
                    }
                    break;
                case ConsoleKey.S:
                    if (inthisarea.interact(x, (y + 1)))
                    {
                        return inthisarea.getdoorkey(x, (y + 1));
                    }
                    break;
                case ConsoleKey.D:
                    if (inthisarea.interact(x + 1, y))
                    {
                        return inthisarea.getdoorkey(x+1,y);
                    }
                    break;

                case ConsoleKey.A:
                    if (inthisarea.interact(x - 1, y))
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

    }
    public class player
    {
        private int health;

    }
    public class  inventory
    {
        private List<inventoryitem> items;
        private Stack<inventoryitem> weapons;
        public inventory()
        {
            items = new List<inventoryitem>();
            weapons = new Stack<inventoryitem>(100); 
        }
        public void additems(inventoryitem i)
        {
            if (i.getitemtype() == "weapon")
            {
                weapons.Push(i);
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
    }
}
