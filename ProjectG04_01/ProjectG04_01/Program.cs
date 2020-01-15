using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.BussinessLayer.Services;
using Project_1.PresentationLayer;
using System.Media;
namespace Project_1
{
    class Program
    {
        public static int Menu()
        {
            
            int k;

        L:
            Graphic.Frame();
            try
            {
                k = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                goto L;
            }
            return k;
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Form f = new Form();
            f.Welcome();
            Console.Title = "Tro choi Chiec non ki dieu";
            int kt = 1;
            char tl;
            do
            {
                switch (Menu())
                {
                    case 1: Console.Clear(); f.Regiter(); break;
                    case 2: f.ChooseTopics(); break;
                    case 3: f.Help(); Console.ReadLine(); break;
                    case 4: f.Play(); Console.ReadLine(); break;
                    case 5: //f.Welcome();
                        {
                            Graphic.WriteAt("Ban that su muon thoat ?(C/K)",12,19);
                            tl = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                            if (tl == 'C')
                                kt = -1;
                        }break;
                    default: break;
                }
                Console.Clear();
            } while (kt>0);    
        }
    }
}
