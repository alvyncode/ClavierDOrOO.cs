using Command;
using Data.Repositories;
using Models;
using Models.Factories;
using ViewModels.Service;
using ViewModels.UserControls;

namespace ViewModels.UserControls;

public class NouvellePartieRoleUserControlViewModel : BasicViewModel
{
    public List<string> ListeDesRoles { get; } = new List<string> 
    { 
        "Développeur Front", 
        "Développeur Back", 
        "Développeur Mobile" 
    };
    private string _roleSelectionne;
    public string RoleSelectionne
        {
            get => _roleSelectionne;
            set
            {
                _roleSelectionne = value;
                OnPropertyChanged();
            }
        }
    public JoueurRepository JoueurAccess { get; set; } = new();
    public PartieRepository PartieAccess { get; set; } = new();
    public RelayCommand ConfirmerButton { get;}
    public string NomDeLaPartie { get; set; }
    public NouvellePartieRoleUserControlViewModel(Joueur j)
    {
        ConfirmerButton = new RelayCommand(() => ConfirmerPartieRole(j));
    }
    public void ConfirmerPartieRole(Joueur j)
    {   
        Partie NouvellePartie = new Partie{
            Nom = NomDeLaPartie,
            Joueur = j,
            Role = RolesFactory.ChoisirRole(RoleSelectionne) 
        };
        PartieAccess.NewGame(NouvellePartie);
        NavigationManager.VueCourante = new ThemeMenuViewModel(NouvellePartie, j);
    }
}
