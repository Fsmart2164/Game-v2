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
                Console.CursorTop = c.gety();
                Console.CursorLeft = c.getx();
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
        public virtual bool isedge()
        {
            return false;
        }
    }
    public class edge : Coord
    {
         public edge(int inx, int iny) : base(inx, iny)
        {
        }
    }

    public class Gateway:edge 
    {
        public Gateway(int inx, int iny) : base(inx, iny)
        {

        }
    }
}

