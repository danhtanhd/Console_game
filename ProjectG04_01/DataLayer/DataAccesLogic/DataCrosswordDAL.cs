using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Project_1.DataLayer.DataAccesLogic
{
    class DataCrosswordDAL
    {
        // Khai báo và khởi tạo lớp hỗ trợ truy cập dữ liệu Tệp text
        private DataAccessHelper dah =new DataAccessHelper();
        public string[] GetRDLine()
        {
            return dah.GetRandomLine();
        }
        //thay đổi đường dẫn tệp
        public void ChangePart(int n)
        {
            string[] s = dah.GetListFile();
            dah = new DataAccessHelper(s[n-1]);
        }
        public string[] GetAllFileName()
        {
            return dah.GetListFile();
        }
    }
}
