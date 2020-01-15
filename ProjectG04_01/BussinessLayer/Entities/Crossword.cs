using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_1.BussinessLayer.Entities
{
    class Crossword
    {
        public Crossword()
        { }
        // các thuộc tính của ô chữ
        private int indexTopic;

        public int IndexTopic
        {
            get { return indexTopic; }
            set { indexTopic = value; }
        }
        public void indextp(int n)
        {
            indexTopic = n;
        }
        private string[] toppic = new string[3];

        public string[] Toppic
        {
            get { return toppic; }
        }
        private int check;

        public int Check
        {
            get { return check; }
            set { check = value; }
        }
        private char[] tmp;

        public char[] Tmp
        {
            get { return tmp; }
            set { tmp = value; }
        }
        private int crossLenght;

        public int CrossLenght
        {
            get { return crossLenght; }
            set { crossLenght = value; }
        }
        private string word;

        public string Word
        {
            get { return word; }
            set { word = value; }
        }
        private string inforCross;

        public string InforCross
        {
            get { return inforCross; }
            set { inforCross = value; }
        }
        private char characters;

        public char Characters
        {
            get { return characters; }
            set { characters = value; }
        }
        public Crossword(string word, string infoCross, int crosslenght)
        {
            tmp = new char[crosslenght];
            this.word = word;
            this.inforCross = infoCross;
            this.crossLenght = crosslenght;
        }
    }
}
