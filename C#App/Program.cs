using System;
using System.Threading;

namespace ConsoleApp1
{
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
            double damage ;
            while (target.HP > 0&&this.HP>0)
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
                target.HP = target.HP - damage;
                Console.WriteLine("{0}向{1}发动攻击，造成{2}点伤害!", this.Name, target.Name, damage, target.HP);
                Thread.Sleep(TimeSpan.FromSeconds(this.ASD));
                if (target.HP <= 0)
                {
                    Console.WriteLine("{0}已经死亡！", target.Name);
                    target.HP = 0;
                    target.Dead = 1;
                }
                Console.WriteLine("{0}生命值变为{1}", target.Name, target.HP);
            }
        }

        static void Main()
        {
            Hero Weien = new Hero() { Name = "薇恩", ATN = 40, DEF = 25, HP = 500, MAXHP = 500, ASD = 0.25, Dead = 0 },
                Maokai = new Hero() { HP = 650, Name = "茂凯", ATN = 55, DEF = 35, MAXHP = 650, ASD = 0.5, Dead = 0 };
            Thread t1 = new Thread(new ParameterizedThreadStart(Weien.Attack));
            t1.Start(Maokai);
            Thread t2 = new Thread(new ParameterizedThreadStart(Maokai.Attack));
            t2.Start(Weien);
            t1.Join();
            t2.Join();
            if (Maokai.Dead == 1 )
            { 
                Console.WriteLine("{0}胜利！", Weien.Name);
            }
            else if (Weien.Dead == 1)
            {
                Console.WriteLine("{0}胜利！", Maokai.Name);
            }
        }
    }
}
