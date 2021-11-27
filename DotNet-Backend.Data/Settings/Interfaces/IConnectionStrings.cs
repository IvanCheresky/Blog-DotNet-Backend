namespace DotNet_Backend.Data.Settings.Interfaces
{
    public interface IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string BlogDbContext { get; set; }
        public string DefaultSchema { get; set; }
    }
}