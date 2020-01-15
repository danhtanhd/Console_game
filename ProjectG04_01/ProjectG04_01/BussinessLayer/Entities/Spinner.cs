using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_1.BussinessLayer.Entities
{
    class Spinner
    {

        private static int[] arraypoint = new int[] { 100, 200, 300, 400, 100, 500, 600, 700, 800, 900, 200, 100, 0,1,2,3 };

        public int[] ArrayPoint
        {
            get { return arraypoint; }
            set { arraypoint = value; }
        }
        private static int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }
    }
}
