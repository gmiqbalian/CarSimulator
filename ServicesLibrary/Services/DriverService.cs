using Newtonsoft.Json;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public class DriverService : IDriverService
    {
        public Driver GetDriver(int fatigueCapacity)
        {
            var driver = new Driver();

            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://randomuser.me/api/").Result;
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                var result = data?.results[0];

                driver.Gender = result.gender;
                driver.Name = result.name.first + " " + result.name.last;
                driver.Cell = result.cell;
                driver.Phone = result.phone;
                driver.Age = result.age;
            }

            driver.FatigueLevel = 0;
            driver.MaxFatigue = fatigueCapacity;

            return driver;
        }
        public FatigueStatus CheckFatigueLevel(Driver driver)
        {
            FatigueStatus status = new FatigueStatus();

            if (driver.FatigueLevel == driver.MaxFatigue)
                status = FatigueStatus.IsTired;
            if (driver.FatigueLevel > 3)
                status = FatigueStatus.Warning;
            if (driver.FatigueLevel == 0)
                status = FatigueStatus.Rested;

            return status;
        }
    }
}
