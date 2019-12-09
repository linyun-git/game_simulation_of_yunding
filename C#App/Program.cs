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
            double damage = this.ATN * (target.DEF / 100);
            while (target.HP > 0&&this.HP>0)
            {
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
            Hero A = new Hero() { Name = "薇恩", ATN = 40, DEF = 25, HP = 500, MAXHP = 500, ASD = 0.25, Dead = 0 },
                B = new Hero() { HP = 650, Name = "茂凯", ATN = 55, DEF = 35, MAXHP = 650, ASD = 0.5, Dead = 0 };
            Thread t1 = new Thread(new ParameterizedThreadStart(A.Attack));
            t1.Start(B);
            Thread t2 = new Thread(new ParameterizedThreadStart(B.Attack));
            t2.Start(A);
            t1.Join();
            t2.Join();
            if (B.Dead == 1 )
            { 
                Console.WriteLine("{0}胜利！", A.Name);
            }
            else if (A.Dead == 1)
            {
                Console.WriteLine("{0}胜利！", B.Name);
            }
        }
    }
}
