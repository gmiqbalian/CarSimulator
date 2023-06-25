using ServicesLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        public int HungerLevel { get; set; }
        public HungerStatus HungerStatus { get => CheckHunger();}
        public bool IsTired { get => FatigueLevel == MaxFatigue; }
        public bool IsFresh { get => FatigueLevel == 0; }
        public bool IsFatigueWarning { get => FatigueLevel >= 7; }
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
        public void IncreaseHunger()
        {
            HungerLevel += 2;
        }
        public void Eat()
        {
            HungerLevel = 0;
        }
        private HungerStatus CheckHunger()
        {
            HungerStatus status = new HungerStatus();

            if (HungerLevel <= 5)
                return status = HungerStatus.Full;
            if (HungerLevel >= 6 && HungerLevel <= 10)
                return status = HungerStatus.Hungry;
            if (HungerLevel >= 11)
                return status = HungerStatus.Starving;

            return status;
        }
    }
}
