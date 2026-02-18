namespace Models.Factories;

public class ScoresFactory
{
    public static List<Score> CreateScores()
    {
        return new List<Score>
        {
            new Score{Theme = Enums.Theme.Algorithmie, ValeurDuScore = 0},
            new Score{Theme = Enums.Theme.Anglais, ValeurDuScore = 0},
            new Score{Theme = Enums.Theme.Logique, ValeurDuScore = 0},
            new Score{Theme = Enums.Theme.CultureGenerale, ValeurDuScore = 0},
            new Score{Theme = Enums.Theme.MetierDeLinformatique, ValeurDuScore = 0}

        };
    }
}
