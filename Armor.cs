using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Armor
    {
        public Armor(string name, string code, int power)
        {
            this.Name = name;
            this.Code = code;
            this.Power = power;
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Power { get; set; }
    }
}
