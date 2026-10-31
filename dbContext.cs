using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext 
{
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // String de conexão com o SQL Server
        optionsBuilder.UseSqlServer("Server=localhost;Database=MeuBanco;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
