using System;
using System.Threading;
using System.Xml;


namespace Battle
{
    class Program
    {
        static void Main()
        {
            Hero[,] qp = new Hero[8, 7];
            Hero Weien = new Hero() { Name = "薇恩", ATN = 40, DEF = 25, HP = 500, MAXHP = 500, ASD = 0.75, Dead = 0 },
                Maokai = new Hero() { Name = "茂凯", ATN = 55, DEF = 35, HP = 650, MAXHP = 650, ASD = 0.5, Dead = 0 },
              Leikedun = new Hero() { Name = "雷克顿", ATN = 60, DEF = 35, HP = 600, MAXHP = 600, ASD = 0.5, Dead = 0 },
                Wolike = new Hero() { Name = "沃里克", ATN = 50, DEF = 30, HP = 650, MAXHP = 650, ASD = 0.6, Dead = 0 };
            Thread t1 = new Thread(new ParameterizedThreadStart(Weien.Attack));
            t1.Start(Maokai);
            Thread t2 = new Thread(new ParameterizedThreadStart(Maokai.Attack));
            t2.Start(Weien);
            Thread t3 = new Thread(new ParameterizedThreadStart(Leikedun.Attack));
            t3.Start(Weien);
            Thread t4 = new Thread(new ParameterizedThreadStart(Wolike.Attack));
            t4.Start(Maokai);
            Thread t5 = new Thread(new ParameterizedThreadStart(Weien.Attack));

            Thread t6 = new Thread(new ParameterizedThreadStart(Maokai.Attack));

            Thread t7 = new Thread(new ParameterizedThreadStart(Leikedun.Attack));

            Thread t8 = new Thread(new ParameterizedThreadStart(Wolike.Attack));

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            t5.Start(Leikedun);
            t8.Start(Leikedun);

            t6.Start(Wolike);
            t7.Start(Wolike);


            if (Maokai.Dead == 1 && Leikedun.Dead == 1)
            {
                Console.WriteLine("蓝色方胜利！");
            }
            else if (Weien.Dead == 1 && Wolike.Dead == 1)
            {
                Console.WriteLine("红色方胜利！", Maokai.Name);
            }
        }
    }

    class Hero
    {
        public double ATN { get; set; }
        public double DEF { get; set; }
        public double MAXHP { get; set; }
        public double HP { get; set; }
        public string Name { get; set; }
        public double ASD { get; set; }
        public double Dead { get; set; }
        public void Attack(object targ)
        {
            Hero target = (Hero)targ;
            double damage;
            while (this.HP > 0)
            {
                Random rd = new Random();
                int baoji = rd.Next(1, 5);
                if (baoji == 1)
                {
                    damage = this.ATN * (target.DEF / 100) * 2;
                }
                else
                {
                    damage = this.ATN * (target.DEF / 100);
                }
                if (target.HP > 0)
                {
                    target.HP = target.HP - damage;
                }
                else
                {

                }
                Console.WriteLine("{0}向{1}发动攻击，造成{2}点伤害!", this.Name, target.Name, damage, target.HP);
                Thread.Sleep(TimeSpan.FromSeconds(1 / (this.ASD)));
                if (target.HP <= 0)
                {
                    Console.WriteLine("{0}已经死亡！", target.Name);
                    target.HP = 0;
                    target.Dead = 1;
                }
                Console.WriteLine("{0}生命值变为{1}", target.Name, target.HP);
            }
        }
    }


}
