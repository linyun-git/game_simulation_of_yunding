using System;

namespace Test
{
    class Hero
    {
        public int ATN { get; set; }
        public int DEF { get; set; }
        public int HP { get; set; }
        public string Name { get; set; }

        public bool Attack(Hero target)
        {
            bool hasDead = false;
            int damage = this.ATN - target.DEF;
            target.HP -= damage;
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
            Hero A = new Hero() { Name = "薇恩", ATN = 78, DEF = 30, HP = 200 },
                B = new Hero() { HP = 300, Name = "卡萨丁", ATN = 100, DEF = 45 };
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