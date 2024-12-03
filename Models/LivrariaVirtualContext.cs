using Microsoft.EntityFrameworkCore;

namespace LivrariaVirtualAPI.Models
{
    public class LivrariaVirtualContext : DbContext
    {
        public LivrariaVirtualContext(DbContextOptions<LivrariaVirtualContext> options)
           : base(options) { }

        public DbSet<Produto> Produtos { get; set; } 

    }
}
