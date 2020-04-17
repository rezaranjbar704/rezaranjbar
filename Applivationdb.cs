using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    public class Applivationdb : DbContext
    {
        public DbSet<Student> Students { get; set ; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(configure: builder =>
                    builder.AddConsole()))
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: @"Server=(localdb)\MSSQLLocalDB;Database=EfCoredb;Integrated security = true;Trusted_Connection=True;ConnectRetryCount=0");
            base.OnConfiguring(optionsBuilder);
        }
    }
}