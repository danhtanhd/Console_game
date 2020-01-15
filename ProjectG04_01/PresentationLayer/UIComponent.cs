using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project_1.BussinessLayer.Services;
using Project_1.PresentationLayer;
using System.Media;

namespace Project_1.PresentationLayer
{
    class Form
    {
        #region 1. Các thuộc tính
        SoundPlayer mSRound = new SoundPlayer(@"Sound/Vong.wav");
        SoundPlayer mSRun = new SoundPlayer(@"Sound/Nhac quay.wav");
        SoundPlayer mSchTrue = new SoundPlayer(@"Sound/Doan dung.wav");
        SoundPlayer mSchFalse = new SoundPlayer(@"Sound/Doan sai.wav");
        SoundPlayer mSlol1 = new SoundPlayer(@"Sound/Mat luot.wav");
        SoundPlayer mSlol2 = new SoundPlayer(@"Sound/Mat diem.wav");
        private PlayerServices plS = new PlayerServices();
        private CrosswordServices crS = new CrosswordServices();
        private SpinnerServices spS = new SpinnerServices();
        private bool confirmTopic = false;
        private string topic;
        #endregion


        #region 2. Các Giao diện game

        public void Welcome()
        {
            Console.Clear();
            Graphic.Frame();
            Graphic.WriteAt("Chao mung ban den voi chiec non ki dieu",10,8);
            Graphic.WriteAt("De bat dau choi chon menu tu 1 cho den 4 Cam on", 6, 10);
        }


        public void Regiter()
        {
            mSRound.Play();
            Console.Clear();
            Graphic.Frame();
            Graphic.WriteAt("CHAO MUNG BAN DA DEN VOI CHUONG TRINH", 11, 2);
            Graphic.WriteAt("CHIEC NON KI DIEU", 19, 3);
            Graphic.WriteAt("Ban vui long dang ki choi tai day", 13, 5);
        L1: Graphic.WriteAt("Ten cua ban : ", 19, 9);
            plS.InPlayer(Console.ReadLine());
            if (plS.Getname() == "")
            {
                Graphic.WriteAt("Ban chua dien ten . Xin vui long dien lai !", 10, 10);
                goto L1;
            }
            Graphic.WriteAt("Ban dang ki ten thanh cong.Moi ban chon chu de.", 7, 15);
            Graphic.WriteAt("Nhan enter de tiep tuc!", 17, 19);
            Console.ReadKey();
        }


        public void ChoosePoint()
        {
            mSRun.Play();
            spS.GetRandomP();
            string ketqua = spS.Getpoint().ToString();
            if (spS.Getpoint() == 1) { ketqua = "May man"; }
            if (spS.Getpoint() == 3) { ketqua = "Them luot"; }
            if (spS.Getpoint() == 2) { ketqua = "Mat luot"; }
            if (spS.Getpoint() == 0) { ketqua = "Mat diem"; }
            Graphic.WriteAt(ketqua, 22, 19);
        }


        public void Play()
        {
            
            int round = 1;
            string da;
            ConsoleKeyInfo kt;
            Graphic.Frame();
            if (confirmTopic == true)
            #region Đã chọn chủ đề
            {
            L:
                #region Khung ô chữ
                mSRound.Play();
                Console.Clear();
                Graphic.Frame();
                Graphic.FramePlay();
                Graphic.WriteAt(topic.ToString(), 24, 6);
                da = crS.GetWord();
                int trueChar = 0;
                string sochu = "Gom " + crS.GetLength() + " chu cai.";
                if(round!=3) 
                    Graphic.WriteAt("Vong "+round.ToString(),25,8);
                else Graphic.WriteAt("Vong dac biet",25,8);
                Graphic.WriteAt("Diem vong"+ round.ToString()+":", 63, 20);
                Graphic.WriteAt(plS.GetSumPoint().ToString(), 74, 17);
                Graphic.WriteAt("O chu Gom " +crS.GetLength() +" Chu Cai "+  crS.GetSuggests(), 13, 10);
                for (int t = 0; t < da.Length - 1; t++)
                {

                    Graphic.WriteAt("══╦═", (30 - 2 * da.Length) + 2 + 4 * t, 12);
                    Graphic.WriteAt("║", (30 - 2 * da.Length) + 4 + 4 * t, 13);
                    Graphic.WriteAt("══╩═", (30 - 2 * da.Length) + 2 + 4 * t, 14);
                }
                Graphic.WriteAt("╔═", (30 - 2 * da.Length), 12);
                Graphic.WriteAt("║", (30 - 2 * da.Length), 13);
                Graphic.WriteAt("╚═", (30 - 2 * da.Length), 14);
                Graphic.WriteAt("══╗", (30 + 2 * da.Length) - 2, 12);
                Graphic.WriteAt("║", (30 + 2 * da.Length), 13);
                Graphic.WriteAt("══╝", (30 + 2 * da.Length) - 2, 14);
                int countfalse = 0;
                #endregion

            Q:
                Graphic.WriteAt("=> Nhan ENTER de quay", 15, 23);
                kt = Console.ReadKey();
                for (int cot = 17; cot < 60; cot++)
                {
                    Graphic.WriteAt(" ", cot, 16);
                    Graphic.WriteAt(" ", cot, 17);
                    Graphic.WriteAt(" ", cot, 19);
                    Graphic.WriteAt(" ", cot, 21);
                }
                ChoosePoint();// chọn điểm

                #region Các trường hợp điểm đặc biệt

                if (spS.Getpoint() == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    mSlol1.Play();
                    countfalse ++;
                    string ml = "Ha ha! Ban da bi mat 1 luot quay.";
                    Graphic.WriteAt(ml, 17, 16);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (countfalse < 4)
                        goto Q;
                    else
                    {
                        if (countfalse == 4 && round < 4)
                        {
                            Console.Clear();
                            Graphic.Frame();
                            Graphic.WriteAt("Ban da khong thanh cong o vong " + round.ToString(), 10, 9);
                            plS.SetPointRound(round - 1, plS.Getpoint());
                            plS.SetPoint(0);
                            crS.ChangeQuestion();
                            round++;
                            countfalse = 0;
                            Graphic.WriteAt("Moi ban nhan ENTER de choi tiep vong sau ", 10, 11);
                            Console.ReadKey();
                            goto L;
                        }

                        else
                        {
                            if (countfalse == 3 && round == 4)
                            {
                                Graphic.WriteAt("Ban hoan thanh xong ca ba vong", 10, 11);
                                Graphic.WriteAt("Tong so diem ban dat duoc la: " + plS.GetSumPoint().ToString(), 10, 13);
                                Graphic.WriteAt("Ban co muon choi lai chu de nay (C/K)", 10, 11);
                                char k = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                if (k == 'C')
                                {
                                    crS.ChangeQuestion();
                                    round = 0;
                                    plS.NewGame();
                                }
                                else
                                    return;
                            }
                        }
                    }
                }
                if (spS.Getpoint() == 3)
                {
                    //f.Play();
                    Console.ForegroundColor = ConsoleColor.Red;
                    countfalse--;
                    string ml = "Chuc mung! Ban da them 1 lan quay.";
                    Graphic.WriteAt(ml, 17, 16);
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto Q;
                }
                if (spS.Getpoint() == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    plS.SetPoint(1);
                    string md = "Chuc mung Ban. Ban da duoc them 1000 diem";
                    Graphic.WriteAt(md, 17, 16);
                    Graphic.WriteAt(plS.Getpoint().ToString() , 74, 20);
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto Q;
                }
                if (spS.Getpoint() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    mSlol2.Play();
                    plS.SetPoint(0);
                    string md = "Rat tiec! Ban da khong con diem nao.";
                    Graphic.WriteAt(md, 17, 16);
                    Graphic.WriteAt(plS.Getpoint().ToString() + "     ", 73, 20);
                    Console.ForegroundColor = ConsoleColor.Green;
                    goto Q;
                }
                #endregion
                Graphic.WriteAt("=> Ban chon chu : ", 15, 21);
                char c;
            K:
                Console.SetCursorPosition(33, 21);
                try
                {
                    c = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Graphic.WriteAt("Hay nhap vao mot ki tu", 17, 16);
                    Graphic.WriteAt("                 ", 33, 16);
                    goto K;
                }
                crS.Choose(c);
                crS.Check();// kiểm tra kí tự vừa đoán
                if (crS.GetCheck() > 0)
                #region Đoán đúng
                {
                    for (int k = 0; k < da.Length; k++)
                    {
                        if (c == da[k])
                        {
                            Graphic.WriteAt(c.ToString(), (30 - 2 * da.Length) + 2 + 4 * k, 13);
                        }
                    }
                    mSchTrue.Play();
                    trueChar = trueChar + crS.GetCheck();
                    string tb = "Chu " + c + ". Vang thua cac ban ! Co " + crS.GetCheck().ToString() + " chu " + c;
                    plS.Score(spS.Getpoint() * crS.GetCheck());
                    Graphic.WriteAt(tb, 17, 16);
                    Graphic.WriteAt(plS.Getpoint().ToString(), 74, 20);
                    if (trueChar==crS.GetLength())
                    {
                        Console.Clear();
                        Graphic.Frame();
                        Graphic.WriteAt("Xin chuc mung ban da chien thang vong "+round.ToString() +"!! " , 10, 9);
                        plS.SetPointRound(round - 1, plS.Getpoint());
                        Graphic.WriteAt("Tong diem:" + plS.GetSumPoint().ToString() + "d", 62, 13 + round);
                        plS.SetPoint(0);
                        round ++;
                        countfalse = 0;
                        if (round == 4)
                        {
                            Graphic.WriteAt("Ban hoan thanh xuat sac ca ba vong", 10, 11);
                            Graphic.WriteAt("Tong so diem ban dat duoc la: " + plS.GetSumPoint().ToString(), 10, 13);
                            Graphic.WriteAt("Ban có muon choi lai chu de nay (C/K)", 10, 11);
                            char k = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                            if (k == 'C')
                            {
                                try
                                {
                                    crS.ChangeQuestion();
                                }
                                catch (Exception)
                                {
                                    Graphic.WriteAt("Da het cau hoi cua chu de " + crS.GetTopic(), 10, 9);
                                    Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                                    Console.ReadKey();
                                    return;
                                }
                                round = 0;
                                plS.NewGame();
                            }else 
                            return;
                        }
                        try
                        {
                            crS.ChangeQuestion();
                        }
                        catch (Exception)
                        {
                            Graphic.WriteAt("Da het cau hoi cua chu de " + crS.GetTopic(), 10, 9);
                            Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                            Console.ReadKey();
                            return;
                        }
                        Graphic.WriteAt("Moi ban nhan ENTER de choi tiep vong sau ", 10, 11);
                        Console.ReadKey();
                        goto L;
                    }
                    else goto Q;
                }
                #endregion
                else
                    if (crS.GetCheck() == -1)
                    #region Đoán trùng
                    {
                        Graphic.WriteAt("Ban da doan chu nay", 17, 16);
                        countfalse++;
                        // Đoán sai 3 lần nhưng chưa phải vòng đặc biệt
                        if (countfalse == 4 && round < 4)
                        {
                            Console.Clear();
                            Graphic.Frame();
                            Graphic.WriteAt("Ban da khong thanh cong o vong " + round.ToString(), 10, 9);
                            plS.SetPointRound(round - 1, plS.Getpoint());
                            plS.SetPoint(0);
                            try
                            {
                                crS.ChangeQuestion();
                            }
                            catch (Exception)
                            {
                                Graphic.WriteAt("Da het cau hoi cua chu de " + crS.GetTopic(), 10, 9);
                                Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                                Console.ReadKey();
                                return;
                            }
                            round++;
                            countfalse = 0;
                            Graphic.WriteAt("Moi ban nhan ENTER de choi tiep vong sau ", 10, 11);
                            Console.ReadKey();
                            goto L;
                        }
                        // Đoán sai 3 lần và ở vòng đặc biệt
                        else if (countfalse == 3 && round == 4)
                        {
                            Graphic.WriteAt("Ban hoan thanh xong ca ba vong", 10, 11);
                            Graphic.WriteAt("Tong so diem ban dat duoc la: " + plS.GetSumPoint().ToString(), 10, 13);
                            Graphic.WriteAt("Ban co muon choi lai chu de nay (C/K)", 10, 11);
                            char k = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                            if (k == 'C')
                            {
                                try
                                {
                                    crS.ChangeQuestion();
                                }
                                catch (Exception)
                                {
                                    Graphic.WriteAt("Da het cau hoi cua chu de " + crS.GetTopic(), 10, 9);
                                    Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                                    Console.ReadKey();
                                    return;
                                }
                                round = 0;
                                plS.NewGame();
                            }
                            else
                                return;
                        }

                        goto Q;
                    }
                    #endregion
                    else
                    if (crS.GetCheck() == 0)
                        #region Đoán sai
                        {
                            mSchFalse.Play();
                            countfalse = countfalse + 1;
                            string tb = "Chu " + c + " .Vang rat tiec ! Khong co chu " + c + " nao !";
                            Graphic.WriteAt(tb, 17, 16);
                            Graphic.WriteAt("Co len nao ban oi", 17, 17);
                            #region Đoán sai 3 lần nhưng chưa phải vòng đặc biệt
                            if (countfalse == 4 && round<4)
                            {
                                Console.Clear();
                                Graphic.Frame();
                                Graphic.WriteAt("Ban da khong thanh cong o vong " + round.ToString(), 10, 9);
                                plS.SetPointRound(round - 1, plS.Getpoint());
                                plS.SetPoint(0);
                                try
                                {
                                    crS.ChangeQuestion();
                                }
                                catch (Exception)
                                {
                                    Graphic.WriteAt("Da het cau hoi cua chu de "+crS.GetTopic(), 10, 9);
                                    Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                                    Console.ReadKey();
                                    return;
                                }
                                round++;
                                countfalse = 0;
                                Graphic.WriteAt("Moi ban nhan ENTER de choi tiep vong sau ", 10, 11);
                                Console.ReadKey();
                                goto L;
                            }
                            #endregion
                            #region Đoán sai 3 lần và ở vòng đặc biệt
                            if (countfalse == 3 && round == 4)
                                {
                                    Graphic.WriteAt("Ban hoan thanh xong ca ba vong", 10, 11);
                                    Graphic.WriteAt("Tong so diem ban dat duoc la: " + plS.GetSumPoint().ToString(), 10, 13);
                                    Graphic.WriteAt("Ban có muon choi lai chu de nay (C/K)", 10, 11);
                                    char k = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                                    if (k == 'C')
                                    {
                                        try
                                        {
                                            crS.ChangeQuestion();
                                        }
                                        catch (Exception)
                                        {
                                            Graphic.WriteAt("Da het cau hoi cua chu de " + crS.GetTopic(), 10, 9);
                                            Graphic.WriteAt("Nhan enter de quay lai lua chon chu de ", 10, 12);
                                            Console.ReadKey();
                                            return;
                                        }
                                        round = 0;
                                        countfalse = 0;
                                        plS.NewGame();
                                        goto L;
                                    }
                                    else
                                        return;
                                }
                            #endregion
                            else goto Q;
                        }
                            
                        #endregion
            }
            #endregion
            else
            {
                Graphic.WriteAt("Ban chua chon chu de cua tro choi .", 11, 7);
                Graphic.WriteAt("Xin vui long nhan ENTER de quay lai", 10, 9);
                Graphic.WriteAt("Tiep theo chon 2 de Dang ki chu de choi ! ", 8, 11);
                Graphic.WriteAt("Thank you !", 38, 13);
            }
        }


        public void ChooseTopics()
        {
            string[] s = crS.GetAllTopics();
            Console.Clear();
            Graphic.Frame();
            Graphic.WriteAt("Chon chu de.", 19, 15);
            int ch = 0;
            if (plS.Getname() != "")
            {
                Graphic.WriteAt("DANH SACH CHU DE CHOI", 17, 5);
                for (int i = 0; i < s.Length; i++)
                {
                    Graphic.WriteAt((i+1).ToString()+". Chu de " + s[i].ToString(), 10, 8+i);
                }
                
            P:
                try
                {
                    Graphic.WriteAt("Moi ban chon chu de : ", 17, 20);
                    ch = Convert.ToInt16(Console.ReadLine());
                    crS.ChooseTopic(ch);
                }
                catch (Exception)
                {
                    goto P;
                }
                topic = s[ch - 1].ToString();
                confirmTopic = true;
            }
            else
            {
                Graphic.WriteAt("Ban chua dang ki lam nguoi choi .", 12, 7);
                Graphic.WriteAt("Xin vui long nhan ENTER de quay lai", 10, 9);
                Graphic.WriteAt("Tiep theo chon 1 de Dang ki lam nguoi choi ! ", 7, 11);
                Graphic.WriteAt("Thank you !", 40, 13);
            }
            Graphic.WriteAt("Ban vua chon chu de "+ s[ch-1].ToString() +". Nhan enter de tiep tuc!", 7, 21);
            Console.ReadKey();
        }


        public void Help()
        {
            Graphic.Frame();
            Graphic.WriteAt("WELCOME", 23, 5);
            Graphic.WriteAt("Chao mung ban da den voi tro choi", 11, 7);
            Graphic.WriteAt("       CHIEC NON KI DIEU", 11, 8);
            Graphic.WriteAt("De tham gia choi tro choi nay,ban", 11, 10);
            Graphic.WriteAt("phai Dang ki, Dang nhap ,Chon chu", 11, 11);
            Graphic.WriteAt("de,co the xem huong dan truoc khi", 11, 12);
            Graphic.WriteAt("nhan PLAY . Luat choi nhu sau : ", 11, 13);
            Graphic.WriteAt("Ban se trai qua 3 vong thi .Trong", 11, 14);
            Graphic.WriteAt("moi vong cac ban chi dc phep doan", 11, 15);
            Graphic.WriteAt("sai 3 lan. Neu qua ban se bi loai", 11, 16);
            Graphic.WriteAt("khoi cuoc choi !Chuc ban may man!", 11, 17);
            Graphic.WriteAt("HAY TU TIN BAN SE LA NGUOI CHIEN THANG ☺ ☺ ☺", 8, 20);
        }
        #endregion
    }
}
