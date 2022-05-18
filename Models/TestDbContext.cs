
using Microsoft.EntityFrameworkCore;

namespace efcoretest.Models;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}