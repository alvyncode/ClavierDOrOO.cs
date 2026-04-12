using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public Joueur EnregistrerEtRecupererJoueur(Joueur joueur)
    {
        var joueurExistant = _context.Joueurs
            .FirstOrDefault(j => j.Pseudo.ToLower() == joueur.Pseudo.ToLower());

        if (joueurExistant != null)
        {
            _context.Joueurs.Update(joueurExistant);
            joueur = joueurExistant; 
        }
        else
        {
            _context.Joueurs.Add(joueur);
        }
        _context.SaveChanges();
        return joueur;
    }
    public Joueur TrouverJoueurId(int id)
    {
        return _context.Joueurs.FirstOrDefault(j => j.Id == id);
    }
}