using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext 
{
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Produto> Produto { get; set; }

    public DbContrext () {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // String de conexão com o SQL Server
        optionsBuilder.UseSqlServer("Server=localhost;Database=MeuBanco;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
