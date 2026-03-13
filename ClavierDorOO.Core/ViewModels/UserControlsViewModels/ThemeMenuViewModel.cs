using System.Windows.Input;
using Command;
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
    }
}
    

