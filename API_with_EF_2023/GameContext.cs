using API_with_EF_2023.Models;
using Microsoft.EntityFrameworkCore;

namespace API_with_EF_2023
{
    public class GameContext : DbContext
    {
        // Two constructors, first one is empty
        public GameContext()
        {

        }

        // Second one injects the context options
        public GameContext(DbContextOptions options) : base(options)
        {

        }

        // Create the table based off the model
        public DbSet<BoardGame> BoardGames { get; set; }

        private static IConfigurationRoot _configuration;

        // Set the configuration to use the JSON file for the connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("GameDb");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}
