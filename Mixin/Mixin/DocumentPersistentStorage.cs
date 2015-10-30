using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixin
{
    [DocumentPersistentTargetType(typeof(Document))]
    class DocumentPersistentStorage : IDocumentPersistentStorage
    {
        public void Store(Document doc)
        {
            Console.WriteLine("DocumentPersistentStorage store {0}", doc.ID);
        }
    }
}
