using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Document doc = new Document();
                Document spDoc = new SpecialDocument();

                doc.Store();
                spDoc.Store();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
