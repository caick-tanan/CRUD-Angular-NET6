using FullStackAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Data
{
    public class StackDbContext : DbContext
    {
        public StackDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
