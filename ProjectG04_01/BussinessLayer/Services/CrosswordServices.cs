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
        public int GetCheck()
        {
            return cr.Check;
        }
        //kiểm tra chữ đoán có tồn tại không
        public void Check()
        {
            char[] tmp = cr.Tmp;
            cr.Check = 0;
            int ch = 0;
            char[] st = GetWord().ToCharArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (cr.Characters==tmp[i])
                {
                    cr.Check = -1;
                }
            }
            if (cr.Check != -1)
            {
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i] == cr.Characters)
                    {
                        cr.Check++;
                        if (ch == 0)
                        {
                            ch++;
                            tmp[i] = cr.Characters;
                        }
                    }
                }
            }
        }
        // chỉnh lại dữ liệu đã mã hóa
        public string Gdatacoding(string coding)
        {
            string s3 = "";
            char[] c1 = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string[] c2 = new string[26] { "*!", "&^", "#$", "#@", "!$", "&&", "%%", "@!", "!(", "(*", ")*", "@#", "$#", "%$", "!@", "_9", "$6", "&$", "!!", "**", ",.", "()", "@@", "^^", "$$", "!*" };
            int k = 0;
            for (int i = k; i < coding.Length; i = i + 2)
            {
                k = i + 1;
                string t = "";
                t = t + coding[i] + coding[k];
                for (int j = 0; j < c2.Length; j++)
                {
                    if (string.Compare(t, c2[j]) == 0)
                        s3 = s3 + c1[j];
                }
            }
            return s3;
        }
        public void ChooseTopic(int n)
        {
            cr.IndexTopic = n;
            crDAL.ChangePart(n);
            tpm = crDAL.GetRDLine();
            cr = new Crossword(Gdatacoding(tpm[0]), tpm[1], Gdatacoding(tpm[0]).Length);
        }
        public void ChangeQuestion()
        {
            tpm = crDAL.GetRDLine();
            cr = new Crossword(Gdatacoding(tpm[0]), tpm[1], Gdatacoding(tpm[0]).Length);
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