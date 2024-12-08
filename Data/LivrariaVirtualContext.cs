using LivrariaVirtualAPI.Models.Produtos;
using Microsoft.EntityFrameworkCore;

namespace LivrariaVirtualAPI.Data
{

    public class LivrariaVirtualContext : DbContext
    {
        // Construtor que recebe as opções de configuração do DbContext.
        public LivrariaVirtualContext(DbContextOptions<LivrariaVirtualContext> options)
           : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        // Método para configurar o mapeamento das entidades para o banco de dados.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama a implementação base para garantir que as configurações padrão sejam aplicadas.
            base.OnModelCreating(modelBuilder);


            // Define a propriedade "Id" como chave primária da tabela.
            modelBuilder.Entity<Produto>()
                .HasKey(x => x.Id);
        }
    }
}