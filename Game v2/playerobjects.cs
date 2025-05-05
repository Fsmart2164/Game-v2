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
                        if (!inthisarea.isedge(x + 1, y))
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
                    else if (inthisarea.isenemy(x, y - 1))
                    {
                        return 2;
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
                    else if (inthisarea.isenemy(x, y + 1))
                    {
                        return 2;
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
                    else if (inthisarea.isenemy(x + 1, y))
                    {
                        return 2;
                    }
                    else if (inthisarea.interact(x + 1, y))
                    {
                        return inthisarea.getdoorkey(x + 1, y);
                    }
                    break;

                case ConsoleKey.A:
                    if (inthisarea.ischest(x - 1, y))
                    {
                        return 1;
                    }
                    else if (inthisarea.isenemy(x - 1, y))
                    {
                        return 2;
                    }
                    else if (inthisarea.interact(x - 1, y))
                    {
                        return inthisarea.getdoorkey(x - 1, y);
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
                    return inthisarea.interactwithchest(x, y - 1);
                case ConsoleKey.S:
                    return inthisarea.interactwithchest(x, y + 1);
                case ConsoleKey.D:
                    return inthisarea.interactwithchest(x + 1, y);
                case ConsoleKey.A:
                    return inthisarea.interactwithchest(x - 1, y);

            }
            return new List<inventoryitem>();
        }

        public Warrior enemyinteract()
        {
            switch (direction)
            {
                case ConsoleKey.W:
                    return inthisarea.interactwithenemy(x, y - 1);
                case ConsoleKey.S:
                    return inthisarea.interactwithenemy(x, y + 1);
                case ConsoleKey.D:
                    return inthisarea.interactwithenemy(x + 1, y);
                case ConsoleKey.A:
                    return inthisarea.interactwithenemy(x - 1, y);

            }
            return null;
        }
    }
    public class player : Warrior
    {
        private inventory myinventory;

        public player(string name) : base(name,0,0,0)
        {
            myinventory = new inventory();
            attackdamage = myinventory.getattackpower();
        }

        public void addtoinventory(List<inventoryitem> p)
        {
            if (p != null)
            {
                foreach (inventoryitem item in p)
                {
                    myinventory.additems(item);
                }
            }
        }
        public void inventoryprint()
        {
            RightScreen.print(myinventory.getitems(), myinventory.getweapons());
        }
        public bool canheal()
        {
            List<inventoryitem> thisinventory  = myinventory.getitems();
            foreach (inventoryitem item in thisinventory)
            {
                if (item.getitemtype() == "healthpotion")
                {
                    return true;
                }
            }
            return false;
        }
        public void heal()
        {
            List<inventoryitem> thisinventory = myinventory.getitems();
            foreach (inventoryitem item in thisinventory)
            {
                if (item.getitemtype() == "healthpotion")
                {
                    addhealth(item.use());
                    if (item.usedup()) myinventory.removeitems(item);
                    break;
                }
            }
        }

        public void addhealth(int i)
        {
            current_health += i;
            if (current_health > max_health)
            {
                current_health = max_health;
            }
        }
        public override void attack(Warrior enemy, int diceroll)
        {
            attackdamage = myinventory.getattackpower();
            enemy.attacked(diceroll, attackdamage);
        }

    }
    public class inventory
    {
        protected List<inventoryitem> items;
        protected Stack<inventoryitem> weapons;
        public inventory()
        {
            items = new List<inventoryitem>();
            items.Add(new health_potion(4000, 1));
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
        public void removeitems(inventoryitem ite)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].getitemtype() == ite.getitemtype())
                {
                    items.RemoveAt(i);
                }
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
        public int getattackpower()
        {
            return weapons.Peek().getattackstrength();
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
    public class Warrior
    {
        protected int current_health, max_health;
        protected string name;
        protected int attackdamage;
        private enemy me;
        public Warrior(string myname,int attackpower,int x , int y)
        {
            name = myname;
            max_health = 100;
            current_health = max_health;
            attackdamage = attackpower;
            me = new enemy(x,y);
        }
        public int getHealth()
        {
            return current_health;
        }
        public string getName()
        {
            return name;
        }
        public bool isalive()
        {
            if (current_health > 0) return true;
            return false;
        }
        public virtual void attack(Warrior enemy, int diceroll)
        {
            
            enemy.attacked(diceroll, attackdamage);
        }
        public void attacked(int diceroll, int attackdamage)
        {
            current_health -= (diceroll * attackdamage);
        }
        public enemy getlocation()
        {
            return me;
        }
    }
    public class dice
    {
        private int sides;
        Random rnd;

        public dice()
        {
            sides = 6;
            rnd = new Random();
        }
        public dice(int insides)
        {
            sides = insides;
            rnd = new Random();
        }
        public int GetSidesCount()
        {
            return sides;
        }
        public int roll()
        {
            return rnd.Next(1, (sides + 1));
        }
    }
}
