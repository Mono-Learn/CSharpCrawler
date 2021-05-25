using CSharpCrawler.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpCrawler.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MITNNV3\SQLSERVER2019;Database=CSharpCrawler;Trusted_Connection=True;");
        }

        public DbSet<Document> Documents { get; set; }
    }
}
