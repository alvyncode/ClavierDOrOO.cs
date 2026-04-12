using System.Windows.Input;
using Command;
using Models;
using ViewModels.Service;
namespace ViewModels.UserControls
{
    public class ThemeMenuViewModel :BasicViewModel
    {
        public ICommand BoutonAlgorithmie{get;}
        public ICommand BoutonAnglais{get;}
        public ICommand BoutonLogique{get;}
        public ICommand BoutonCultureG{get;}
        public ICommand BoutonMDI{get;}
        public ThemeMenuViewModel()
        {
            BoutonAlgorithmie = new RelayCommand(AllerAlgorithmie);
            BoutonAnglais = new RelayCommand(AllerAnglais);
            BoutonLogique = new RelayCommand(AllerLogique);
            BoutonCultureG = new RelayCommand(AllerCultureG);
            BoutonMDI = new RelayCommand(AllerMDI);

        }
        public ThemeMenuViewModel(Partie partie, Joueur j)
        {
            BoutonAlgorithmie = new RelayCommand(_ => AllerAlgorithmie(partie,j));
            BoutonAnglais = new RelayCommand(_ => AllerAnglais(partie,j));
            BoutonLogique = new RelayCommand(_ => AllerLogique(partie,j));
            BoutonCultureG = new RelayCommand(_ => AllerCultureG(partie,j));
            BoutonMDI = new RelayCommand(_ => AllerMDI(partie,j));
        }
        public void AllerAlgorithmie()
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Algorithmie);
        }
        public void AllerAnglais()
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Anglais);
        }
        public void AllerLogique()
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Logique);
        }
        public void AllerCultureG()
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.CultureGenerale);
        }
        public void AllerMDI()
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.MetierDeLinformatique);
        }
        public void AllerAlgorithmie(Partie partie,Joueur j)
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Algorithmie, partie,j);
        }
        public void AllerAnglais(Partie partie, Joueur j)
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Anglais, partie,j);
        }
        public void AllerLogique(Partie partie, Joueur j)
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.Logique, partie,j);
        }
        public void AllerCultureG(Partie partie, Joueur j)
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.CultureGenerale, partie,j);
        }
        public void AllerMDI(Partie partie, Joueur j)
        {
            NavigationManager.VueCourante = new QuestionLayoutViewModel(Models.Enums.Theme.MetierDeLinformatique, partie,j);
        }
    }
}
    

