using System;
using System.Windows.Input;
using Command;
using Data.Repositories;
using Models;
using ViewModels.Service;

namespace ViewModels.UserControls
{
    public class MainMenuViewModel :BasicViewModel
    {
        public string PseudoDernierJoueur { get; set; }
        public ICommand BoutonNewGame { get;} 
        public ICommand BoutonLoad { get;} 
        public ICommand BoutonHistory { get;}
        public MainMenuViewModel(Joueur j)
        {
            BoutonNewGame = new RelayCommand(_=>ExecuterNavigationNewGame(j));
            BoutonLoad = new RelayCommand(_=>ExecuterNavigationLoad(j));
            BoutonHistory = new RelayCommand(_=>ExecuterNavigationHistory(j));
            PseudoDernierJoueur = j.Pseudo;
        }
        private void ExecuterNavigationNewGame(Joueur j)
        {
            NavigationManager.VueCourante = new NouvellePartieRoleUserControlViewModel(j);
        }
        private void ExecuterNavigationLoad(Joueur j)
        {
            NavigationManager.VueCourante = new LoadPartieUIViewModel(j);
        }
        private void ExecuterNavigationHistory(Joueur j)
        {
            NavigationManager.VueCourante = new HistoryViewModel(j);
        }
    }
}