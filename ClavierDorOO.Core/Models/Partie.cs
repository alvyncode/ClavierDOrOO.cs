using Models.Factories;

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
    
    public Partie ()
    {
        // Scores = ScoresFactory.CreateScores();
    }
}
