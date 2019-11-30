using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkToClient linkToClient = new LinkToClient();
            Console.WriteLine("Hello World!");
        }
    }
    class Hero
    {
        public string heroName;
        public int heroSquareId;
        public int heroLevel;
    }
}