using Microsoft.EntityFrameworkCore;
using Models;
using Models.Roles;
namespace Data;

public class ClavierDorDbContext : DbContext
{
    // Constructeur 1 : Pour ton App WPF (Runtime)
    // C'est celui que tu utiliseras dans App.xaml.cs avec les vraies infos
    public ClavierDorDbContext(DbContextOptions<ClavierDorDbContext> options) : base(options)
    {
    }

    // Constructeur 2 : Vide (Pour que EF Core puisse l'instancier sans paramètres)
    public ClavierDorDbContext()
    {
    }

    // LA MÉTHODE MAGIQUE
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Si aucune option n'a été passée (cas des migrations EF Core), on configure ici
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "server=localhost;user=root;password=;database=clavier_dor_oo_db";
            
            // Attention : Remplace bien la version par la tienne (ex: 8.0.30)
            optionsBuilder.UseMySql(
                connectionString, 
                ServerVersion.AutoDetect(connectionString)
            );
        }
    }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Joueur> Joueurs{get;set;}
    public DbSet<Partie> Parties { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<DeveloppeurBack> DeveloppeurBacks { get; set; }
    public DbSet<DeveloppeurFront> DeveloppeurFronts { get; set; }
    public DbSet<DeveloppeurMobile> DeveloppeurMobiles { get; set; }
}
