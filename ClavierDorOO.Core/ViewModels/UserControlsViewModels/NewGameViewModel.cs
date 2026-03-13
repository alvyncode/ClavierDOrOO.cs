using ViewModels.Service;
namespace ViewModels.UserControls;
public class NewGameViewModel: BasicViewModel
{
    public NewGameViewModel()
    {
        NavigationManager.VueCourante = new ThemeMenuViewModel();
    }
}
