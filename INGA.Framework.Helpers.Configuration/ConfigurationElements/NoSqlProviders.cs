using System.Configuration;

namespace INGA.Framework.Helpers.Configuration.ConfigurationElements
{
    public class NoSqlProviders: ConfigurationElement
    {
        public NoSqlProviders() { }

        public NoSqlProviders(string name, string host = "", int port = 8080, string username = "", string password = "",
            bool isActive = false, string bucketname = "",
            bool useSsl = false, int poolMaxSize = 0, int poolMinSize = 0, string extraField = "",string databaseName="")
        {
            Name = name;
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            IsActive = isActive;
            BucketName = bucketname;
            UseSsl = useSsl;
            PoolMaxSize = poolMaxSize;
            PoolMinSize = poolMinSize;
            ExtraField = extraField;
            DatabaseName = databaseName;
        }

      

        [ConfigurationProperty("Name", DefaultValue = "*", IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this["Name"]; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("Host", DefaultValue = "*", IsRequired = true, IsKey = false)]
        public string Host
        {
            get { return (string)this["Host"]; }
            set { this["Host"] = value; }
        }

        [ConfigurationProperty("Port", DefaultValue = 0, IsRequired = true, IsKey = false)]
        public int Port
        {
            get { return (int)this["Port"]; }
            set { this["Port"] = value; }
        }


        [ConfigurationProperty("Username", DefaultValue = "*", IsRequired = false, IsKey = false)]
        public string Username
        {
            get { return (string)this["Username"]; }
            set { this["Username"] = value; }
        }


        [ConfigurationProperty("Password", DefaultValue = "*", IsRequired = false, IsKey = false)]
        public string Password
        {
            get { return (string)this["Password"]; }
            set { this["Password"] = value; }
        }

        [ConfigurationProperty("IsActive", DefaultValue = false, IsRequired = true, IsKey = false)]
        public bool IsActive
        {
            get { return (bool)this["IsActive"]; }
            set { this["IsActive"] = value; }
        }

        [ConfigurationProperty("BucketName", DefaultValue = "*", IsRequired = true, IsKey = false)]
        public string BucketName
        {
            get { return (string)this["BucketName"]; }
            set { this["BucketName"] = value; }
        }

        [ConfigurationProperty("UseSsl", DefaultValue = false, IsRequired = false, IsKey = false)]
        public bool UseSsl
        {
            get { return (bool)this["UseSsl"]; }
            set { this["UseSsl"] = value; }
        }

        [ConfigurationProperty("PoolMaxSize", DefaultValue = 10, IsRequired = false, IsKey = false)]
        public int PoolMaxSize
        {
            get { return (int)this["PoolMaxSize"]; }
            set { this["PoolMaxSize"] = value; }
        }

        [ConfigurationProperty("PoolMinSize", DefaultValue = 5, IsRequired = false, IsKey = false)]
        public int PoolMinSize
        {
            get { return (int)this["PoolMinSize"]; }
            set { this["PoolMinSize"] = value; }
        }

        [ConfigurationProperty("ExtraField", DefaultValue = "*", IsRequired = true, IsKey = false)]
        public string ExtraField
        {
            get { return (string)this["ExtraField"]; }
            set { this["ExtraField"] = value; }
        }

        [ConfigurationProperty("DatabaseName", DefaultValue = "*", IsRequired = true, IsKey = false)]
        public string DatabaseName
        {
            get { return (string)this["DatabaseName"]; }
            set { this["DatabaseName"] = value; }
        }
    }
}
