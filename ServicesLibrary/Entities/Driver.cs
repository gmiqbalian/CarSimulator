using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class Driver
    {
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public string? Phone { get; set; }
        public string? Cell { get; set; }
        public int FatigueLevel { get; set; }
        public int MaxFatigue { get; set; } = 10;
        public bool IsTired { get => FatigueLevel == MaxFatigue; }
        public bool IsFresh { get => FatigueLevel == 0; }
        public Driver()
        {
            FatigueLevel = 0;
        }
        public void TakeRest()
        {
            FatigueLevel = 0;
        }
        public void IncreaseFatigue()
        {
            FatigueLevel++;
        }
    }
}
