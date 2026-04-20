using Models;
using Microsoft.EntityFrameworkCore;
using Models.Factories;
using Models.Enums;
using System.Reflection.Metadata.Ecma335;
using Data.Service;
using Models.Roles;
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
    public List<PartieDto> ListeDesParties(Joueur joueur)
    {

        if (joueur == null) return new List<PartieDto>();

        return _context.Parties
            .AsNoTracking()
            .Where(p => EF.Property<int>(p, "JoueurId") == joueur.Id)
            .Select(p => new PartieDto
            {
                Id = p.Id,
                NomDeLaPartie = p.Nom,
                Score = p.Scores.Sum(s => s.ValeurDuScore),
                Progression = p.ProgessionAlgo + 
                            p.ProgessionAnglais + 
                            p.ProgessionLogique+ 
                            p.ProgessionCultureG+
                            p.ProgessionMDI
            })
            .ToList();
    }
    public Partie LoadGame(Joueur joueur, string nomDeLaPartie)
    {
        var Partie = _context.Parties
        .Include(p => p.Role)
        .Include(p => p.Scores)
        .FirstOrDefault(p => p.Nom == nomDeLaPartie && p.Joueur.Id == joueur.Id);
        if (Partie != null)
        {
            return Partie;
        }
        else
        {
            throw new NullReferenceException("Inexistant");
        }

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
    public async Task EnregisterUneProgression(Partie partie, Theme theme,int progression)
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
        await Task.Delay(1800);
    }
    public void EnregistrerUnScore(Partie partie, int scoreCourant, Theme theme)
    {
        var score = partie.Scores.FirstOrDefault(s=>s.Theme == theme);
        score.ValeurDuScore = scoreCourant;
    }
    public List<int> TrouverProgression(Partie p)
    {
        var progression = new List<int>
        {
            p.ProgessionAlgo,
            p.ProgessionAnglais,
            p.ProgessionLogique,
            p.ProgessionCultureG,
            p.ProgessionMDI
        };
        return progression;
    }
    public Role TrouverRole (Partie p)
    {
        return _context.Parties.FirstOrDefault(partie=>partie.Nom == p.Nom).Role;
    }
}
