using Data.Repositories;
using Models;
using Models.Roles;
// Intégrité des questions et du repositoryquestion
var questionRepository = new QuestionRepository();
List<Question> Questions = questionRepository.RecupererQuestionTheme(Models.Enums.Theme.Algorithmie);
Question q = Questions[0];
Console.WriteLine($"{q.TypeDeQuestion} ....{q.OptionsProposees.QuatrièmeOption}");

// Tests RepositoryJoueur
var role = new DeveloppeurBack{Intitule = "Test"};
var Test = new Joueur{Id = 6, Pseudo = "Test1", Role = role};
var joueurRepositoryrepository = new JoueurRepository();
// joueurRepositoryrepository.AjouterJoueur(Test);

// Tests ReporityPartie
var ReposityPartie = new PartieRepository();
var partie = new Partie{Nom = "Test1",Joueur = Test};
// ReposityPartie.NewGame(partie);
var p = ReposityPartie.ListeDesParties(Test);

foreach(Partie pop in p)
{
    Console.WriteLine($"Partie {pop.Joueur}");
}