using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.DataLayer.DataAccesLogic;
using Project_1.BussinessLayer.Entities;

namespace Project_1.BussinessLayer.Services
{
    class CrosswordServices
    {
        #region 1.khai báo đối tượng thuộc lớp cần sử dụng
        private DataCrosswordDAL crDAL = new DataCrosswordDAL();
        private Crossword cr=new Crossword();
        // Thuộc tính của lớp CrosswordServices
        private string[] tpm;
        #endregion




        #region 2.các phương thức cho ô chữ
        //lấy ra gợi ý ô chữ
        public string GetSuggests()
        {
            return cr.InforCross;
        }
        //lấy ra số lượng chữ có trong ô chữ
        public int GetLength()
        {
            return cr.CrossLenght;
        }
        //lấy ra ô chữ
        public string GetWord()
        {
            return cr.Word;
        }
        //Chọn chữ
        public void Choose(char c)
        {
            cr.Characters = c;
        }
        //kiểm tra chữ đoán có tồn tại không nếu có đưa ra số ô chữ
        public int Check()
        {
            char[] tmp = new char[cr.CrossLenght];
            int checkcr = 0;
            cr.Check = 0;
            tmp = cr.Tmp;
            int ch = 0;
            char[] st = GetWord().ToCharArray();
            for (int j = 0; j < tmp.Length; j++)
            {
                if (cr.Characters == tmp[j] && ch == 0)
                {
                    ch++;
                    checkcr = -1;
                }
                return checkcr;

            }
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == cr.Characters)
                {
                    checkcr++;
                    tmp[i] = cr.Characters;
                    return checkcr;
                }
                return checkcr;
            }
            return ;
        }
        public bool Checkwin()
        {
            return (cr.Check == cr.CrossLenght);
        }
        public void ChooseTopic(int n)
        {
            cr.IndexTopic = n;
            crDAL.ChangePart(n);
            tpm = crDAL.GetRDLine();
            cr = new Crossword(tpm[0], tpm[1], tpm[0].Length);
        }
        public void ChangeQuestion()
        {
            tpm = crDAL.GetRDLine();
            cr = new Crossword(tpm[0], tpm[1], tpm[0].Length);
        }
        public string[] GetAllTopics()
        {
            return crDAL.GetAllFileName();
        }
        public string GetTopic()
        {
            return cr.Toppic[cr.IndexTopic];
        }
        #endregion

    }
}