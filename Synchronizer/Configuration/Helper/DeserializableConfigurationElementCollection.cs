using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration.Helper
{
	public abstract class DeserializableConfigurationElementCollection<TElement> :
		DeserializableConfigurationElementCollectionBase<TElement>
		where TElement : DeserializableConfigurationElement, new()
	{
		/// <summary>
		/// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </summary>
		/// <returns>
		/// A new <see cref="T:System.Configuration.ConfigurationElement"/>.
		/// </returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return new TElement();
		}
	}
}
