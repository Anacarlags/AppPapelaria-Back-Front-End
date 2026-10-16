using Microsoft.EntityFrameworkCore;
using minhaPrimeiraApi.Models;

namespace minhaPrimeiraApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Produto> Produtos { get; set; }
}