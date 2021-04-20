using Proto_API_Yugi.Models.Interfaces;

namespace Proto_API_Yugi.Models.Implementation
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}