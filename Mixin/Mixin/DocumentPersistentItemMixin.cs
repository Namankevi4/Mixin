using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mixin
{
    static class DocumentPersistentItemMixin  // привязка обработчиков к оригинальным классам
    {
        private static Dictionary<Type, Func<IDocumentPersistentStorage>> _factories;

        private static Exception _initException;

        static DocumentPersistentItemMixin()
        {
            try
            {
                var pFacts = Assembly.GetExecutingAssembly()
                                     .GetTypes()
                                     .Select(t => new { Type = t, Attribute = (DocumentPersistentTargetTypeAttribute)t.GetCustomAttributes(typeof(DocumentPersistentTargetTypeAttribute), false).SingleOrDefault() })
                                     .Where(obj => obj.Attribute != null).ToArray();

                foreach (var type in pFacts.Select(obj => obj.Attribute.BoundClass).Distinct())
                    if (pFacts.Count(obj => obj.Attribute.BoundClass == type) > 1)
                        throw new ApplicationException(string.Format("{0} have more then one binding", type.FullName));

                _factories = pFacts.ToDictionary(obj => obj.Attribute.BoundClass, obj => new Func<IDocumentPersistentStorage>(() => (IDocumentPersistentStorage)Activator.CreateInstance(obj.Type)));
            }
            catch (Exception ex)
            {
                _initException = ex;
            }
        }

        public static void Store(this Document doc)
        {
            GetPersistentItemFor(doc.GetType()).Store(doc);
        }

        private static IDocumentPersistentStorage GetPersistentItemFor(Type docType)
        {
            if (_initException != null)
                throw new ApplicationException(string.Format("DocumentPersistentItemMixin exception: {0}", _initException.Message), _initException);

            if (!_factories.ContainsKey(docType))
                throw new ApplicationException(string.Format("DocumentPersistentItemMixin exception: {0} have no binding", docType.FullName));
            return _factories[docType]();
        }
    }
}
