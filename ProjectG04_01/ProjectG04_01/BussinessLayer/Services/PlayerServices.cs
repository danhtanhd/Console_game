using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.BussinessLayer.Entities;
using Project_1.DataLayer.DataAccesLogic;

namespace Project_1.BussinessLayer.Services
{
    class PlayerServices
    {
        #region 1.khai báo các đối tượng để sử dụng
        //khai báo đối tượng thuộc lớp người chơi
        private Player A = new Player();
        
        #endregion



        #region 2.Các phương thức cho người chơi
        //Phương thức nhập tên người chơi
        public void InPlayer(string Plname)
        {
            A.Name = Plname;
        }
        public void Score(int p)
        {
            A.Point = A.Point + p;
        }
        public int Getpoint()
        {
            return A.Point;
        }
        public string Getname()
        {
            return A.Name;
        }
        public void SetPoint(int n)
        {
            if (n == 0)
                A.Point = 0;
            else A.Point = A.Point + 6000;
        }
        public void SetPointRound(int index, int point)
        {
            int[] pointarr = new int[3];
            pointarr = A.Pointarray;
            pointarr[index] = point;
        }
        public int GetSumPoint()
        {
            int[] pointarr = new int[3];
            pointarr = A.Pointarray;
            int sum = 0;
            for (int i = 0; i < pointarr.Length; i++)
            {
                sum = sum + pointarr[i];
            }
            return sum;
        }
        #endregion
    }
}
