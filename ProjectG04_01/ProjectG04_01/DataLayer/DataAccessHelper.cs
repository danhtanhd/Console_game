using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Project_1.DataLayer
{
    class DataAccessHelper
    {
        #region 1. thuộc tính
        //khai báo tên file
        private static string filepath="Data/";
        private string fileName = "";
        public string FileName
        {
            get { return fileName; }
            set { if (value != "")fileName = value; }
        }
        private List<string[]> Data = new List<string[]>();
        #endregion


        #region 2. phương thức khởi tạo
        public DataAccessHelper()
        {
            fileName = filepath + fileName;
        }
        public DataAccessHelper(string fileName)
        {
            this.fileName = filepath+ fileName;
            Data = ReadAllData();
        }
        #endregion


        #region 3.Các phương thức thao tác với tệp
        /// <summary>
        /// phương thức đọc tất cả dữ liệu từ tệp
        /// </summary>
        /// <returns></returns>
        public List <string[]> ReadAllData()
        {
            List<string[]> Data = new List<string[]>();
            string[] obj;
            StreamReader sr = new StreamReader(fileName);
            while (sr.Peek() > 0)
            {
                obj = sr.ReadLine().Split('|');
                Data.Add(obj);
            }
            sr.Dispose();
            return Data;
        }
        public string[] ReadL(int x)
        {
            string[]s= Data[x];
            Data.Remove(Data[x]);
            return s;
        }
        //lấy ra số dòng của data
        public int Count()
        {
            List<string[]> t = ReadAllData();
            return (t.Count());
        }
        /// <summary>
        /// lấy ra một dòng bất kì
        /// </summary>
        /// <returns></returns>
        public string[] GetRandomLine()
        {
            int a;
            Random k = new Random();
            a = k.Next(0,Count());
            return ReadL(a);
        }
        /// <summary>
        /// Phương thức lấy ra danh sách file
        /// </summary>
        /// <returns></returns>
        public string[] GetListFile()
        {
            DirectoryInfo dr = new DirectoryInfo("Data");
            FileInfo[] s = dr.GetFiles();
            string[] k = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                k[i] = s[i].ToString();
            }
            return k;
        }
        #endregion

    }
}
