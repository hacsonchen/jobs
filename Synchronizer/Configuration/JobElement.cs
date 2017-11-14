using Microsoft.Practices.Unity;
using Synchronizer.Configuration.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Synchronizer.Configuration
{
	public class JobElement : DeserializableConfigurationElement
	{
        private static readonly UnknownElementHandlerMap<JobElement> UnknownElementHandlerMap =
            new UnknownElementHandlerMap<JobElement>
                {
                    { "request", (ce, xr) => ce.Deserialize(xr) }
                };

        private readonly RequestElementCollection requestElements = new RequestElementCollection();

        public RequestElementCollection RequestElements
        {
            get { return this.requestElements; }
        }

        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)base["name"]; }
			set { }
		}

		[ConfigurationProperty("expression", IsRequired = false, DefaultValue = "")]
		public string Expression
		{
			get { return (string)base["expression"]; }
			set { }
		}

        [ConfigurationProperty("request", IsRequired = false)]
        public RequestElementCollection RequestJobs
        {
            get { return (RequestElementCollection)base["request"]; }
        }

        internal void ConfigureContainer(IUnityContainer container)
        {
            this.RequestElements.Cast<RequestElement>()
                .ForEach(element => element.ConfigureContainerInternal(container));
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            return UnknownElementHandlerMap.ProcessElement(this, elementName, reader) ||
                this.DeserializeRequestElement(elementName, reader) ||
                base.OnDeserializeUnrecognizedElement(elementName, reader);
        }

        public override void SerializeContent(XmlWriter writer)
        {

            this.RequestJobs.SerializeElementContents(writer, "request");
            this.SerializeRequestElements(writer);
        }

        private bool DeserializeRequestElement(string elementName, XmlReader reader)
        {
            Type elementType = ExtensionElementMap.GetContainerConfiguringElementType(elementName);
            if (elementType != null)
            {
                this.ReadElementByType(reader, elementType, this.RequestElements);
                return true;
            }
            return false;
        }

        private void SerializeRequestElements(XmlWriter writer)
        {
            foreach (var element in this.RequestJobs)
            {
                string tag = ExtensionElementMap.GetTagForExtensionElement(element);
                writer.WriteElement(tag, element.SerializeContent);
            }
        }
    }
}
