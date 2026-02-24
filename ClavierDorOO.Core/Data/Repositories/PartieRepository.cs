using Models;
using Microsoft.EntityFrameworkCore;
using Models.Factories;
namespace Data.Repositories;
public class PartieRepository
{
    private ClavierDorDbContext _context;
    public PartieRepository()
    {
        var ConnexionString = "server=localhost;user=root;password=;database=clavier_dor_oo_db";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));
        var optionsBuilder = new DbContextOptionsBuilder<ClavierDorDbContext>();
        optionsBuilder.UseMySql(ConnexionString,serverVersion);
        _context = new ClavierDorDbContext(optionsBuilder.Options);
    }
    public void NewGame(Partie partie)
    {
        var Scores = ScoresFactory.CreateScores();
        partie.Scores = Scores;
        _context.Parties.Add(partie);
        _context.SaveChanges();   
    }
    public List<Partie> ListeDesParties(Joueur joueur)
{
    if (joueur == null)
    {
        return new List<Partie>(); 
    }
    return _context.Parties
                   .AsNoTracking()
                   .Where(p => EF.Property<int>(p, "JoueurId") == joueur.Id) 
                   .ToList();
}
    public Partie LoadGame(Joueur joueur, int id)
    {
        return _context.Parties.FirstOrDefault(p => p.Id == id && p.Joueur.Id == joueur.Id);

    }
}
