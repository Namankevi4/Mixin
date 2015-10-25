using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixin
{
    public class Human : Nature, MSurnameProvider
    {
        string Name;

        public string GetName()
        {
            return Name;
        }
        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
