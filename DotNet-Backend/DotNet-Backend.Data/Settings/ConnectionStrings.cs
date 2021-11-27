using DotNet_Backend.Data.Settings.Interfaces;

namespace DotNet_Backend.Data.Settings
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string BlogDbContext { get; set; }
        public string DefaultSchema { get; set; }
    }
}