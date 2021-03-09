using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine( "Welcome to the Game\n" );
            //Game game = new Game();
            //game.Start();


            //make a hero
            Game newgame = new Game();
            Hero hero = new Hero("hero", newgame);

            //make a monter
            Monster monster = new Monster("monster", 100, 100);

            // show stats
            hero.ShowStats();

            //show inventory
            hero.ShowInventory();

            //fight
            Fight fight = new Fight(hero, monster, newgame);

            //win 
            monster.CurrentHealth = 0;
            fight.Win();

            //lose
            hero.CurrentHealth = 0;
            fight.Lose();

        }
    }
}
