namespace GrupoCiencias.Intranet.CrossCutting.Common
{
    public class AppSetting
    {
        public ConnectionString ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public int HoursOfExpires { get; set; } 
        public CacheSetting CacheSettings { get; set; } 
    }
    public class ConnectionString
    {
        public string BDGrupoCiencias { get; set; }
    }

    public class CacheSetting
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
    } 
}
