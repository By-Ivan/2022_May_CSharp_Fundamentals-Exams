using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            FillHeroes(heroes, n);

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmd = input.Split(" - ");
                string heroName = cmd[1];

                switch (cmd[0])
                {
                    case "CastSpell":
                        heroes.First(x => x.Name == heroName).CastSpell(int.Parse(cmd[2]), cmd[3]);
                        break;

                    case "TakeDamage":
                        heroes.First(x => x.Name == heroName).TakeDamage(int.Parse(cmd[2]), cmd[3]);
                        break;

                    case "Recharge":
                        heroes.First(x => x.Name == heroName).Recharge(int.Parse(cmd[2]));
                        break;

                    case "Heal":
                        heroes.First(x => x.Name == heroName).Heal(int.Parse(cmd[2]));
                        break;
                }

                int index = heroes.IndexOf(heroes.FirstOrDefault(x => x.HP <= 0));

                if (index != -1)
                {
                    heroes.RemoveAt(index);
                }

                input = Console.ReadLine();
            }

            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero);
            }
        }

        private static void FillHeroes(List<Hero> heroes, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroInfo[0];
                int hp = int.Parse(heroInfo[1]);
                int mp = int.Parse(heroInfo[2]);

                if (!heroes.Select(x => x.Name).Contains(heroName))
                {
                    heroes.Add(new Hero(heroName, hp, mp));
                }
            }
        }
    }

    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }
        public string Name { get; set; }

        private int _hp;
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value > 100)
                {
                    value = 100;
                }
                _hp = value;
            }
        }

        private int _mp;
        public int MP
        {
            get
            {
                return _mp;
            }
            set
            {
                if (value > 200)
                {
                    value = 200;
                }
                _mp = value;
            }
        }

        public void CastSpell(int mp, string spell)
        {
            if (this.MP >= mp)
            {
                this.MP -= mp;
                Console.WriteLine($"{this.Name} has successfully cast {spell} and now has {this.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have enough MP to cast {spell}!");
            }
        }

        public void TakeDamage(int damage, string attacker)
        {
            this.HP -= damage;

            if (this.HP > 0)
            {
                Console.WriteLine($"{this.Name} was hit for {damage} HP by {attacker} and now has {this.HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{this.Name} has been killed by {attacker}!");
            }
        }

        public void Recharge(int amount)
        {
            int beforeCharge = this.MP;
            this.MP += amount;
            Console.WriteLine($"{this.Name} recharged for {this.MP - beforeCharge} MP!");
        }

        public void Heal(int amount)
        {
            int beforeHeal = this.HP;
            this.HP += amount;
            Console.WriteLine($"{this.Name} healed for {this.HP - beforeHeal} HP!");
        }

        public override string ToString() => this.Name + "\n HP: " + this.HP + "\n MP: " + this.MP;
    }
}