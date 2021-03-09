using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Monster
    {
        public Monster(string name, int strength, int defense)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHealth = 500;
            this.CurrentHealth = 500;
        }

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}
