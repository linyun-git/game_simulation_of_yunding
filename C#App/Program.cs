using System;

namespace Test
{
    class Hero
    {
        public double ATN { get; set; }
        public double DEF { get; set; }
        public double MAXHP { get; set; }
        public double HP { get; set; }
        public string Name { get; set; }
        public int count = 1;
        static int flag = 0;
        public bool Attack(Hero target)
        {
            bool hasDead = false;
            double damage = this.ATN * (target.DEF/100) ;
            if (this.Name == "薇恩")
            {
                damage = damage + (count / 3) * target.MAXHP * 0.08;
                count++;
                if (count == 4)
                {
                    Console.WriteLine("薇恩发动了技能：第三次攻击对目标造成最大生命值的额外百分比伤害");
                    count = 1;
                    flag = 1;
                }
            }
            if (this.Name == "茂凯")
            {
                if (flag == 1)
                {
                    Console.WriteLine("茂凯发动了技能：受到技能伤害后下一次攻击将回复自身血量");
                    this.HP = this.HP + 100;
                    flag = 0;
                }
            }
            target.HP = target.HP - damage;
            Console.WriteLine("{0}向{1}发动攻击，造成{2}点伤害!", this.Name, target.Name, damage, target.HP);
            if (target.HP <= 0)
            {
                Console.WriteLine("{0}已经死亡！", target.Name);
                target.HP = 0;
                hasDead = true;
            }
            Console.WriteLine("{0}生命值变为{1}", target.Name, target.HP);
            return hasDead;
        }

        static void Main()
        {
            Hero A = new Hero() { Name = "薇恩", ATN = 40, DEF = 25, HP = 500 ,MAXHP = 500},
                B = new Hero() { HP = 650, Name = "茂凯", ATN = 55, DEF = 35 , MAXHP = 650};
            while (A.HP >= 0 && B.HP >= 0)
            {
                if (B.Attack(A))
                {
                    Console.WriteLine("{0}获取胜利", B.Name);
                    break;
                }
                if (A.Attack(B))
                {
                    Console.WriteLine("{0}获取胜利", A.Name);
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
