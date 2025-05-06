using System;
using System.Collections;
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

        public override bool interact()
        {
            RightScreen.print("generic item");
            return false;

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
        public override List<inventoryitem> interactchest()
        {
            return RightScreen.print(items);
            

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

    public class inventoryitem
    {
        public virtual string getname()
        {
            return "";
        }

        public virtual int use()
        {
            return 100000000;
        }

        public virtual string getdescription()
        {
            return "iamamawmiawimawm";
        }

        public virtual string getitemtype()
        {
            return "basic item";
        }

        public virtual int getattackstrength()
        {
            return 0;
        }
        public virtual bool usedup()
        {
            return false;
        }
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
            return (amount+" "+getname() + " with a potency of " + strength);
        }
        public override string getitemtype()
        {
            return "healthpotion";
        }
        public override int getattackstrength()
        {
            return 0;
        }
        public override bool usedup()
        {
            return used;
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
            return ("A type of " + weapontype + ": " + name + " which does " + attack + " " + damagetype + " damage");
        }

        public override string getname()
        {
            return name;
        }

        public override int use()
        {
            return attack;
        }
        public override string getitemtype()
        {
            return "weapon";
        }
        
        public override int getattackstrength()
        {
            return attack;
        }
    }

    public class note:inventoryitem
    {
        private string text;

        public note(string text)
        {
            this.text = text;
        }
        public override string getdescription()
        {
            return text;
        }
        public override string getitemtype()
        {
            return "note";
        }
        public override string getname()
        {
            return "a note";
        }
    }
}
