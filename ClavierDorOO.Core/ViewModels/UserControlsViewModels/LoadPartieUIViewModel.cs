using System.Windows.Input;
using Command;
using Data.Repositories;
using Models;
using ViewModels.Service;
using ViewModels.UserControls;
namespace ViewModels.UserControls;

public class LoadPartieUIViewModel:BasicViewModel
{
    public PartieRepository PartieAccess{get;} = new();
    public string NomDeLaPartie { get; set; }
    public RelayCommand BoutonConfirmer { get;}
    public LoadPartieUIViewModel(Joueur j)
    {
        BoutonConfirmer = new RelayCommand(_=> ExecuterConfirmation(j,NomDeLaPartie));
    }
    public void ExecuterConfirmation(Joueur j, string n)
    {
        var p = PartieAccess.LoadGame(j,n);
        var progression = PartieAccess.TrouverProgression(p);
        NavigationManager.VueCourante = new ThemeMenuViewModel(p,j,progression);
    }
}
