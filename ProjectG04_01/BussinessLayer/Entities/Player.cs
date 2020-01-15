using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_1.BussinessLayer.Entities
{
    class Player
    {
        private static string name;
        private static int point;
        private static int[] pointarray = new int[3];

        public int[] Pointarray
        {
            get { return pointarray; }
            set { pointarray = value; }
        }
        public string Name
        {
            get { return name; }
            set { if (value != "") name = value; }
        }
        public int Point
        {
            get { return point; }
            set { point = value; }
        }
        public Player()
        {
            name = "";
            point = 0;
        }
    }
}
