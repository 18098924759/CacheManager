using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using INGA.Framework.Helpers.Configuration.ConfigurationElements;

namespace INGA.Framework.Helpers.Configuration.ConfigurationCollections
{
    public class NoSqlProviderCollection : ConfigurationElementCollection, IEnumerable<NoSqlProviders>
    {
        public NoSqlProviderCollection()
        {
            Console.WriteLine("NoSqlProviderCollection Constructor");
        }

        public NoSqlProviders this[int index]
        {
            get { return (NoSqlProviders)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(NoSqlProviders providerCollection)
        {
            BaseAdd(providerCollection);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new NoSqlProviders();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NoSqlProviders)element).Name;
        }

        public void Remove(NoSqlProviders providerCollection)
        {
            BaseRemove(providerCollection.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        #region Implementation of IEnumerable<out NoSqlProviders>

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<NoSqlProviders> GetEnumerator()
        {
            return this.BaseGetAllKeys().Select(key => (NoSqlProviders)BaseGet(key)).GetEnumerator();
        }

        #endregion
    }
}
