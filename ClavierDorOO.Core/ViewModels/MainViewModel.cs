using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViewModels.UserControls;
using System.Windows.Input;
using Command;
using ViewModels.Service;
using Microsoft.VisualBasic;
namespace ViewModels
{
    public class MainViewModel : BasicViewModel
    {
        public ICommand AllerHomeCommand { get;}
        public ICommand AllerReglesCommand { get; }
        private RulesViewModel _rulesViewModel = new RulesViewModel();
        private object _vuePrecedente;
        public object VueCourante => NavigationManager.VueCourante;
        public MainViewModel()
        {
            NavigationManager.VueAChangee += () => OnPropertyChanged(nameof(VueCourante));
            NavigationManager.VueCourante = new ConnexionRegisterViewModel();
            AllerReglesCommand = new RelayCommand(AllerRegle);
            AllerHomeCommand = new RelayCommand(AllerHome);
        }

        public void AllerRegle()
        {
            if (VueCourante == _rulesViewModel)
            {
                NavigationManager.VueCourante = _vuePrecedente;
            }
            else
            {
                _vuePrecedente = VueCourante;
                NavigationManager.VueCourante = _rulesViewModel;
            }
        }
        public void AllerHome()
        {
            NavigationManager.VueCourante = new ConnexionRegisterViewModel();
        }
    }
};