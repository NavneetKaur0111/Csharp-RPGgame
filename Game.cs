using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Game
    {
        public Game()
        {
            this.NumberOfFights = 0;
            this.NumberOfWins = 0;
            Monsters = DefaultMonsters();
        }

        public int NumberOfFights { get; set; }
        public int NumberOfWins { get; set; }
        public List<Monster> Monsters { get; set; }

        public List<Monster> DefaultMonsters()
        {
            return new List<Monster>()
            {
                new Monster("Freddy krueger", 100, 40),
                new Monster("Jason Voorhees", 100, 60),
                new Monster("DemoGorgon", 300, 80),
                new Monster("Twin Victim", 100, 60),
                new Monster("chupakabra", 200, 50),
                new Monster("cthulhu", 200, 50),
            };
        }

        public void Start()
        {
            Hero hero = MakeAHero();
            Console.WriteLine("Congratulations! you got a new Avatar.");
            int response = -1;
            while (response != 0)
            {
                ShowMainMenu();
                response = GetResponseForMainMenu();
                switch (response)
                {
                    case 1:
                        hero.ShowStats();
                        break;
                    case 2:
                        hero.ShowInventory();
                        break;
                    case 3:
                        Fight(hero, Monsters[0]);
                        break;
                }
            }
        }

        public Hero MakeAHero()
        {
            string name = "";
            int Count = 0, number = 0;
            bool success = true;

            do
            {
                if (Count > 0)
                    Console.Write($"\n'{name}' is not a valid Name. Try Again!");

                Console.Write("Please enter your Name and press enter\n");
                name = Console.ReadLine();
                success = int.TryParse(name, out number);
                Count++;
            } while (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name) || success);

            Hero hero = new Hero(name, this);
            return hero;
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\nMain Menu :"
                + "Enter the numbers to do the corresponding things:\n"
                + "Show Statistics: 1\n"
                + "Show Inventory: 2\n"
                + "Fight: 3\n\n"
                + "Exit: 0");
        }

        public int GetResponseForMainMenu()
        {
            int answer = -2, count = 0;
            bool success = false;
            do
            {
                success = int.TryParse(Console.ReadLine(), out answer);
                if (count > 0)
                    Console.WriteLine("Invalid response! Please try again later.");
                count++;
            } while (!success || answer > 4 || answer < 0);
            return answer;
        }

        public void Fight(Hero hero, Monster monster)
        {
            if (Monsters.Count > 0)
            {
                NumberOfFights++;
                Fight fight = new Fight(hero, monster, this);
            }
            else
            {
                Console.WriteLine("There are no more monsters to fight! You already killed all of them.");
            }
        }

    }
}
