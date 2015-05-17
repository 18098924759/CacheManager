using System.Configuration;
using INGA.Framework.Helpers.Configuration.ConfigurationCollections;

namespace INGA.Framework.Helpers.Configuration.ConfigurationSections
{
    public class NoSqlProvidersSection : ConfigurationSection
    {

        [System.Configuration.ConfigurationProperty("NoSqlProviders")]
        [ConfigurationCollection(typeof(NoSqlProviderCollection))]
        public NoSqlProviderCollection NoSqlProviderCollection
        {
            get
            {
                object o = this["NoSqlProviders"];
                return o as NoSqlProviderCollection;
            }
        }
    }
}
