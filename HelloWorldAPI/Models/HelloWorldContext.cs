using Microsoft.EntityFrameworkCore;

namespace HelloWorldAPI.Models
{
    public class HelloWorldContext : DbContext
    {
        public HelloWorldContext(DbContextOptions<HelloWorldContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorldModel> HelloWorldModel { get; set; }
    }
}