using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_v2
{
    public class item : Coord
    {
        protected string name;
        
        public item(int inx, int iny) : base(inx, iny)
        {

        }
        public override string getedgetype()
        {
            return "item";
        }

        public virtual void interact()
        {
            RightScreen.print("generic item");
        }
    }
    public class chest : item
    {
        private List<inventoryitem> items;
        public chest(int inx, int iny, List<inventoryitem> inventory) : base(inx, iny)
        {
            items = inventory;
        }
        public override string icon()
        {
            return "M";
        }
        public override string getedgetype()
        {
            return "chest";
        }
        public override void interact()
        {
            RightScreen.print(items);
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
        public health_potion(int health, int amount)
        {
            strength = health;
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

}
