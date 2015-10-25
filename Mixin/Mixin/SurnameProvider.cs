using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace Mixin
{
    public static class SurnameProvider
    {
        static ConditionalWeakTable<MSurnameProvider, Fields> table;
        static SurnameProvider()
        {
            table = new ConditionalWeakTable<MSurnameProvider, Fields>();
        }
        private sealed class Fields
        {
            internal string surname;
        }
        public static string GetSurname(this MSurnameProvider map)
        {

            return table.GetOrCreateValue(map).surname;
        }
        public static void SetSurname(this MSurnameProvider map, string surname)
        {
            table.GetOrCreateValue(map).surname = surname;
        }
    }
}
