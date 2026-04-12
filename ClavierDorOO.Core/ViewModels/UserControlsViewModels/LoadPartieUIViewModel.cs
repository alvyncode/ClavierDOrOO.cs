using System.Windows.Input;
using Command;
using ViewModels.Service;
using ViewModels.UserControls;
namespace ViewModels.UserControls;

public class LoadPartieUIViewModel:BasicViewModel
{
    public ICommand BoutonNewGame { get;}
    public ICommand BoutonLoadGame { get;}
    public ICommand BoutonHistory { get;}

    public LoadPartieUIViewModel()
    {
        BoutonNewGame = new RelayCommand(ExecuterNavigationNewGame);
    }
    private void ExecuterNavigationNewGame()
    {
        
    }
    private void ExecuterNavigationLoad()
    {
        
    }    
    private void ExecuterNavigationHistory()
    {
        
    }
}
