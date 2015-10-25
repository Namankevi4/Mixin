using System;
using System.Runtime.CompilerServices;
namespace Mixin
{
    static class Test
    {
        static void Main()
        {
            Human h = new Human("Vasya", 15);
            h.SetSurname("Pupkin");
            Console.WriteLine("Name {0}, Surname {1}, Age {2}", h.GetName(), h.GetSurname(), h.GetAge());
            
            Human h2 = new Human("Alexandr", 19);
            h2.SetSurname("Namankevich");
            Console.WriteLine("Name {0}, Surname {1}, Age {2}", h2.GetName(), h2.GetSurname(), h2.GetAge());
        }
    }
}
