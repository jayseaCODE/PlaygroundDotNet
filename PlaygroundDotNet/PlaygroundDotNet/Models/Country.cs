using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundDotNet.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }

        public override string ToString()
        {
            return $"{Name}, Capital: {Capital}, Region: {Region}";
        }
    }
}
