using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Fight
    {
        public Fight(Hero hero, Monster monster, Game game)
        {
            this.Hero = hero;
            this.Monster = monster;
            this.Game = game;
            Start();
        }

        public Game Game { get; set; }
        public Hero Hero { get; set; }
        public Monster Monster { get; set; }

        public void Start()
        {
            Console.WriteLine($"welcome to your {Game.NumberOfFights} fight.\n"
                + $"You are going to fight {Monster.Name}.\n\n"
                + "Please Choose your Weapon and Armour");
            Hero.ChooseWeapon();
            Hero.ChooseArmor();

            int turnCount = 0;

            while (Hero.CurrentHealth > 0 && Monster.CurrentHealth > 0)
            {
                if (turnCount % 2 == 0)
                    HeroTurn();
                else
                    MonsterTurn();

                turnCount++;
            }
        }

        public int getResponseForAttack()
        {
            int result = 0, count = 0;
            bool success = false;
            while (result != 1 && result != 2)
            {
                success = int.TryParse(Console.ReadLine(), out result);

                if (count > 0 || !success)
                    Console.WriteLine("Invalid response. Please try again!");
                count++;
            }
            return result;
        }

        public void HeroTurn()
        {
            Console.WriteLine("\nYour Turn.\n"
                + $"Moster has {Monster.Strength} strength, {Monster.Defense} defense and {Monster.CurrentHealth} health."
                + "if you want to choose another weapon click 1 or click 2 to attack.");
            int response = getResponseForAttack();
            if (response == 1)
            {
                Hero.ChooseWeapon();
                HeroTurn();
            }
            else
            {
                int power = Hero.Weapon.Power + Hero.Strength;
                int powerLeft = power - Monster.Defense;
                if (powerLeft > 0)
                {
                    DecreaseHealthOfMonster(powerLeft);
                }
                else
                {
                    Console.WriteLine("Sorry! Monster is more stronger than your power. Better luck next time.");
                }

            }
        }

        public void DecreaseHealthOfMonster(int power)
        {
            Monster.CurrentHealth -= power;
            if (Win())
            {
                return;
            }
            Console.WriteLine($"You damaged {power} power of monster. He still has {Monster.CurrentHealth} health.");
        }

        public void MonsterTurn()
        {
            Console.WriteLine("\nMonster's turn.");
            int power = Monster.Strength;
            int defense = Hero.Defense + Hero.Armor.Power;
            int powerLeft = power - defense;
            if (powerLeft > 0)
            {
                DecreaseHealthOfHero(powerLeft);
            }
            else
            {
                Console.WriteLine("Wow! your defense power was so strong. Monster didn't hurt you at all.");
            }

        }

        public void DecreaseHealthOfHero(int power)
        {
            Hero.CurrentHealth -= power;
            Console.WriteLine($"You got {Hero.CurrentHealth} health left. if you want to purchase more health, click 1 and press enter or click 2 to continue.");
            int response = BuyHealthOrNot();
            if (response == 1)
                Hero.BuyHealth();
            else
            {
                if (Lose())
                    return;
                Console.WriteLine($"Monster damaged {power} of your power. You still have {Hero.CurrentHealth} health. Good Luck!");
            }
        }

        public int BuyHealthOrNot()
        {
            int result = 0, count = 0;
            while (result != 1 && result != 2)
            {

                int.TryParse(Console.ReadLine(), out result);

                if (count > 0)
                    Console.WriteLine("Invalid response! please try again, you can only enter 1 or 2.");
                count++;
            }
            return result;
        }

        public void DeleteMonster()
        {
            for(int i= 0; i < Game.Monsters.Count; i++)
            {
                if (Monster.Name.Equals(Game.Monsters[i].Name, StringComparison.OrdinalIgnoreCase)) 
                {
                   Game.Monsters.RemoveAt(i);
                };
            }
        }

        public bool Win()
        {
            if (Monster.CurrentHealth <= 0)
            {
                Console.WriteLine("Congratulations, you won the fight.\n"
                    + $"You got {Monster.Strength} points.");
                Hero.points += Monster.Strength;
                DeleteMonster();
                Game.NumberOfWins++;
                return true;
            }
            return false;
        }

        public bool Lose()
        {
            if (Hero.CurrentHealth <= 0)
            {
                Console.WriteLine("OOPs..... You lost the fight. Try again.");
                return true;
            }
            return false;
        }
    }
}
