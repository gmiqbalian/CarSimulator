using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Services
{
    public interface IDrivingServices
    {
        public void Drive(string currentDirection, string driveTo);
    }
}
