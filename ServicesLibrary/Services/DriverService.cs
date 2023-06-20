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
        public Driver GetDriver()
        {
            var driver = new Driver();

            using var client = new HttpClient();

            var json = client.GetStringAsync("https://randomuser.me/api/").Result;
            dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
            var result = data?.results[0];
            
            if(result != null)
            {
                driver.Gender = result.gender;
                driver.Name = result.name.first + " " + result.name.last;
                driver.Cell = result.cell;
                driver.Phone = result.phone;
                driver.Age = result.age;
            }

            return driver;
        }
        public void TakeRest(Driver driver)
        {
            if (!driver.IsTired())
            {
                Print.ErrorMessage("\nDriver is alredy fresh.");
                return;
            }

            driver.TakeRest();
            Print.SuccessMessage("\nDriver is now rested and ready to drive.");
        }
    }
}
