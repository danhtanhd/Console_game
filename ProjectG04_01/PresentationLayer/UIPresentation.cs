using System;
using System.Collections.Generic;
using System.Text;
using Project_1.BussinessLayer.Services;

namespace Project_1.PresentationLayer
{
    public static class Graphic
    {
        private static PlayerServices pls = new PlayerServices();
        private static CrosswordServices crS = new CrosswordServices();
        //private static 
        public static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        public static void FramePlay()
        {
            WriteAt("Nguoi choi la : ", 15, 5);
            WriteAt(pls.Getname(), 35, 5);
            WriteAt("Chu de : ", 15, 6);
            WriteAt(crS.GetTopic(), 25, 6);
            WriteAt("Goi y : ", 5, 10);
            WriteAt("Thong bao : ", 5, 16);
            WriteAt("Ket qua : ", 5, 19);
            WriteAt("▲", 23, 20);
            WriteAt("Tong Diem:", 63, 17);
        }

        public static void Frame()
        {
          
            string ten = "CHIEC NON KI DIEU";

            WriteAt(ten, 19, 3);
            WriteAt("╔", 0, 1);
            WriteAt("╚", 0, 25);
            WriteAt("╗", 79, 1);
            WriteAt("╝", 79, 25);

            for (int i = 0; i < 78; i++)
            {
                WriteAt("═", i + 1, 1);
                WriteAt("═", i + 1, 25);
            }
            for (int i = 0; i < 23; i++)
            {
                WriteAt("║", 0, i + 2);
                WriteAt("║", 60, i + 2);
                WriteAt("║", 79, i + 2);
            }
            WriteAt("╦", 60, 1);
            WriteAt("╩", 60, 25);
            for (int i = 0; i < 18; i++)
            {
                WriteAt("─", 61 + i, 3);
                WriteAt("─", 61 + i, 11);
                WriteAt("─", 61 + i, 13);
            }
            WriteAt("MAIN MENU", 65, 2);
            WriteAt("1. Dang ki choi", 62, 5);
            WriteAt("2. Chon chu de", 62, 6);
            WriteAt("3. Huong dan", 62, 7);
            WriteAt("4. PLAY", 62, 8);
            WriteAt("5. Thoat", 62, 9);            
            WriteAt("Chon : ", 66, 12);                    
        }

    }
    
}
