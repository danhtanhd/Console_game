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
        private Player pl = new Player();
        
        #endregion



        #region 2.Các phương thức cho người chơi
        //Phương thức nhập tên người chơi
        public void InPlayer(string Plname)
        {
            pl.Name = Plname;
        }
        public void Score(int p)
        {
            pl.Point = pl.Point + p;
        }
        public int Getpoint()
        {
            return pl.Point;
        }
        public string Getname()
        {
            return pl.Name;
        }
        public void SetPoint(int n)
        {
            if (n == 0)
                pl.Point = 0;
            else pl.Point = pl.Point + 1000;
        }
        public void SetPointRound(int index, int point)
        {
            int[] pointarr = new int[3];
            pointarr = pl.Pointarray;
            pointarr[index] = point;
        }
        public int GetSumPoint()
        {
            int[] pointarr = new int[3];
            pointarr = pl.Pointarray;
            int sum = 0;
            for (int i = 0; i < pointarr.Length; i++)
            {
                sum = sum + pointarr[i];
            }
            return sum;
        }
        public void NewGame()
        {
            pl.Point = 0;
            pl.Pointarray = new int[3];
        }
        #endregion
    }
}
