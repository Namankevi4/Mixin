using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixin
{
    [DocumentPersistentTargetType(typeof(SpecialDocument))]
    class SpecialDocumentPersistentStorage : IDocumentPersistentStorage //объекты-обработчики для каждого члена оригинальной иерархии.
    {
        public void Store(Document doc)
        {
            Console.WriteLine("SpecialDocumentPersistentStorage store {0}", doc.ID);
        }
    }
}
