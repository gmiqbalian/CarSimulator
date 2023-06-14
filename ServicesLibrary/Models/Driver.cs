using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Models
{
    public class Driver
    {
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public string nat { get; set; }
        public Name name { get; set; }
        public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
        public DOB dob { get; set; }
        public class DOB
    {
        public string date { get; set; }
        public string age { get; set; }
    }
        public int FatigueLevel { get; }
        public int MaxFatigue { get; set; }
    }
}
