using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.BussinessLayer.Entities;
using Project_1.DataLayer.DataAccesLogic;

namespace Project_1.BussinessLayer.Services
{
    class SpinnerServices
    {
        //thuộc tính
        private Spinner spi = new Spinner();
        //phương thức
        public void GetRandomP()
        {
            int[] tpm = spi.ArrayPoint;
            int p;
            Random k = new Random();
            p=k.Next(0,tpm.Length);
            spi.Point= tpm[p];
        }
        public int Getpoint()
        {
            return spi.Point;
        }
        public void SetPoint()
        {
            spi.Point = 0;
        }
    }
}
