using Models.Factories;
using Models.Roles;

namespace Models;

public class Partie
{
    
    public int Id { get; set; }
    public string Nom { get; set; }
    public Joueur Joueur { get; set; }
    private List<Score> _scores;
    public List<Score> Scores
    {
        get { return _scores; }
        set { _scores = value; }
    }
    public Role Role {get;set;}

    public int ProgessionAlgo { get; set; } = 1;
    public int ProgessionLogique { get; set; } = 1;
    public int ProgessionCultureG { get; set; } = 1;
    public int ProgessionAnglais { get; set; } = 1;
    public int ProgessionMDI { get; set; } = 1;
    
    public Partie ()
    {
        
    }
}
