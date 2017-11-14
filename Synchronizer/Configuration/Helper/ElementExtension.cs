using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Synchronizer.Configuration.Helper
{
    static class ElementExtension
    {

        public static TElementType ReadElementByType<TElementType>(this JobElement baseElement,
    XmlReader reader, Type elementType, DeserializableConfigurationElementCollectionBase<TElementType> elementCollection)
    where TElementType : DeserializableConfigurationElement
        {
            var element = (TElementType)Activator.CreateInstance(elementType);
            element.Deserialize(reader);
            elementCollection.Add(element);
            return element;
        }
    }
}
