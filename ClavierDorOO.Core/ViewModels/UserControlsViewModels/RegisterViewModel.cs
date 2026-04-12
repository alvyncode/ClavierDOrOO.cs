using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Command;
using Data.Repositories;
using Models;
using Models.Factories;
using Models.Roles;
using ViewModels.Service;
using ViewModels.UserControlsViewModels;
namespace ViewModels.UserControls
{
    public class RegisterViewModel : BasicViewModel
    {
        public JoueurRepository JoueurRepository { get; set; } = new JoueurRepository();
        public ICommand ConfirmerPseudoRole { get;}
        private string _pseudo = "";
        private string _roleSelectionne = "Développeur Front";
        public List<string> ListeDesRoles { get; } = new List<string> 
        { 
            "Développeur Front", 
            "Développeur Back", 
            "Développeur Mobile" 
        };
        public string Pseudo
        {
            get => _pseudo;
            set
            {
                _pseudo = value;
                OnPropertyChanged();
            }
        }
        public string RoleSelectionne
        {
            get => _roleSelectionne;
            set
            {
                _roleSelectionne = value;
                OnPropertyChanged();
            }
        }
        private void EnregistrerJoueur()
        {
            Joueur joueur = new Joueur 
            { 
                Pseudo = this.Pseudo
            };
            var j = JoueurRepository.EnregistrerEtRecupererJoueur(joueur);
            NavigationManager.VueCourante = new MainMenuViewModel(j);
        }
        public RegisterViewModel()
        {
            ConfirmerPseudoRole = new RelayCommand(EnregistrerJoueur);
        }
    }
}
