using Microsoft.EntityFrameworkCore;

namespace rev_entity_framework.Models
{
    // Configuração para tabelas
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Associando a tabela do banco ao tipo de dados
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
