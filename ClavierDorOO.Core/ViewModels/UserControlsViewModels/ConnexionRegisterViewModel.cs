using System.Windows.Controls;
using System.Windows.Input;
using Command;
using ViewModels.Service;
namespace ViewModels.UserControls
{    
    public class ConnexionRegisterViewModel :BasicViewModel
    {
        public ICommand BoutonRLCommand { get; }
        public ICommand BoutonInviteCommand { get; }

        public ConnexionRegisterViewModel()
        {
            BoutonRLCommand = new RelayCommand(ExecuterNavigationRL);
            BoutonInviteCommand = new RelayCommand(ExecuterNavigationInvite);
        }
        private void ExecuterNavigationRL()
        {
            NavigationManager.VueCourante = new RegisterViewModel();
        }
        private void ExecuterNavigationInvite()
        {
            NavigationManager.VueCourante = new NewGameViewModel();
        }
    }
}

