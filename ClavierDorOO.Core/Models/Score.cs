using Models.Enums;

namespace Models;

public class Score
{
    public int Id { get; set; }
    private Theme _theme;
    public Theme Theme
    {
        get { return _theme; }
        set { _theme = value; }
    }
    
    private int _valeurDuScore;
    public int ValeurDuScore
    {
        get { return _valeurDuScore; }
        set { _valeurDuScore = value; }
    }
    
}
