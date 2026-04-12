using Models;
using Microsoft.EntityFrameworkCore;
using Models.Factories;
using Models.Enums;
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
        if (partie.Joueur != null)
        {
            _context.Entry(partie.Joueur).State = EntityState.Unchanged;
        }

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
    public Partie DernierePartieEnregistré()
    {
        var Partie = _context.Parties
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
        if(Partie!=null)
            return  Partie;
        else
        {
            throw new NullReferenceException("C'est pas bon gamin");
        }
        ;
    }
    public void EnregisterUneProgression(Partie partie, Theme theme,int progression)
    {
        switch (theme)
        {
            case Theme.Algorithmie:
                partie.ProgessionAlgo = progression;

                break;
            case Theme.Logique:
                partie.ProgessionLogique = progression;

                break;
            case Theme.Anglais:
                partie.ProgessionAnglais = progression;

                break;
            case Theme.MetierDeLinformatique:
                partie.ProgessionMDI = progression;

                break;
            case Theme.CultureGenerale:
                partie.ProgessionCultureG = progression;

                break;
        }
        _context.Parties.Update(partie);
        _context.SaveChanges();
    }
    public void EnregistrerUnScore(Partie partie, int scoreCourant, Theme theme)
    {
        var score = partie.Scores.FirstOrDefault(s=>s.Theme == theme);
        score.ValeurDuScore = scoreCourant;
    }
}
