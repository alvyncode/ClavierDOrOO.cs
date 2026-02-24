using Microsoft.EntityFrameworkCore;
using Models;
namespace Data.Repositories;
public class JoueurRepository
{
    private ClavierDorDbContext _context;
    public JoueurRepository()
    {
        var ConnexionString = "server=localhost;user=root;password=;database=clavier_dor_oo_db";
        var optionsBuilder = new DbContextOptionsBuilder<ClavierDorDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
        optionsBuilder.UseMySql(ConnexionString, serverVersion);
        
        _context = new ClavierDorDbContext(optionsBuilder.Options);
    }
    public void AjouterJoueur(Joueur joueur)
{
    if (joueur.Id == 0)
    {
        bool joueurExisteDeja = _context.Joueurs.Any(j => j.Pseudo.ToLower() == joueur.Pseudo.ToLower());
        if (joueurExisteDeja)
        {
            throw new InvalidOperationException("Un joueur avec ce pseudo existe déjà !");
        }

        _context.Joueurs.Add(joueur);
    }
    else
    {
        _context.Joueurs.Update(joueur);
    }
    
    _context.SaveChanges();
}
}