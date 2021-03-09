using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Hero
    {
        public Hero(string Name, Game game)
        {
            this.Name = Name;
            this.Game = game;
            this.Strength = 100;
            this.Defense = 50;
            this.OriginalHealth = 500;
            this.CurrentHealth = 500;
            this.points = 100;
            this.Armors = DefaultArmors();
            this.Weapons = DefaultWeapons();
        }

        public string Name { get; set; }
        public Game Game { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int points { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }

        public List<Weapon> DefaultWeapons()
        {
            return new List<Weapon>()
            {
                   new Weapon("Rifle", "w1", 30),
                   new Weapon("Snipper", "w2", 10),
                   new Weapon("Super Shortgun- Doom", "w3", 40),
                   new Weapon("AK47", "w4", 100),
                   new Weapon("Handcannon- Resoident Evil 4", "w5", 50),
                   new Weapon("SpreadGun- Contra", "w6", 80),
                   new Weapon("Gold Gun- Goldeneye", "w7", 50),
                   new Weapon("Fat man- Fallout", "w8", 90),
            };
        }

        public List<Armor> DefaultArmors()
        {
            return new List<Armor>()
           {
               new Armor("Brotherhood of Steel Power", "A1", 20),
               new Armor("Scorpion Suit", "A2", 30),
               new Armor("Nano suit", "A3", 40),
               new Armor("Armor of Altair", "A4", 50),
               new Armor("Flaming Recon Armor", "A5", 60),
           };
        }

        public void ShowStats()
        {
            Console.WriteLine("\nStatistics:\n"
                + $"Name: {Name}\n"
                + $"Strength: {Strength}\n"
                + $"Defense: {Defense}\n"
                + $"Current-Health: {CurrentHealth}\n"
                + $"Points: {points}"
                + $"Number of fights: {Game.NumberOfFights}\n"
                + $"Number of fights won: {Game.NumberOfWins}\n"
                + $"Number of fights Lost: {Game.NumberOfFights - Game.NumberOfWins}"
                );
        }

        public void ShowInventory()
        {
            Console.WriteLine($"Your Inventory");
            ShowWeapons();
            ShowArmors();
           
        }

        public void ShowWeapons()
        {
            Console.WriteLine($"\nWeapons:\n");
            if (Weapons.Count > 0)
                foreach (var weapon in Weapons)
                    Console.Write($"{weapon.Name}({weapon.Code}): {weapon.Power}\n");
        }

        public void ShowArmors()
        {
            Console.WriteLine($"\nArmours:\n");
            if (Armors.Count > 0)
                foreach (var armor in Armors)
                    Console.WriteLine($"{armor.Name}({armor.Code}): {armor.Power}");
        }

        public void ChooseWeapon()
        {
            ShowWeapons();
            Console.WriteLine("\nEnter a code for choosing a weapon.");
            GetResponseForWeapon();
        }

        public void GetResponseForWeapon()
        {
            string code = "";
            int count = 0;

            do
            {
                if(count > 0)
                    Console.WriteLine("Invalid response. Please try again.");

                code = Console.ReadLine();
                foreach(var weapon in Weapons)
                {
                    if (code.Equals(weapon.Code, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"You choose {weapon.Name} with {weapon.Power} power.");
                        Weapon = weapon;
                        return;
                    }
                }
                code = "";
                count++;
            } while (code == "");
        }

        public void ChooseArmor()
        {
            ShowArmors();
            Console.WriteLine("\nEnter a code for choosing an Armor.");
            GetResponseForArmors();
        }

        public void GetResponseForArmors()
        {
            string code = "";
            int count = 0;

            do
            {
                if (count > 0)
                    Console.WriteLine("Invalid response. Please try again.");

                code = Console.ReadLine();
                foreach (var armor in Armors)
                    if (code.Equals(armor.Code, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"You choose {armor.Name} with {armor.Power} power.");
                        Armor = armor;
                        return;
                    }

                code = "";
                count++;
            } while (code == "");
        }

        public void BuyHealth()
        {
            Console.WriteLine($"Oops! getting out of health? You have {points} points. You get 2x health with your points.\n"
                + "Please write how many points you want to buy health for and press enter.");
            int response = getResponseForBuyingHealth();
            points -= response;
            CurrentHealth += response * 2;
            Console.WriteLine($"Your new health is {CurrentHealth}.");
        }

        public int getResponseForBuyingHealth()
        {
            int result = 0;
            string response = "";
            while (result > points || result <= 0)
            {
                response = Console.ReadLine();
                int.TryParse(response, out result);
            }
            return result;
        }
    }
}
