using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class DriverResponse
    {
        public IEnumerable<Driver> results { get; set; }
    }
}
