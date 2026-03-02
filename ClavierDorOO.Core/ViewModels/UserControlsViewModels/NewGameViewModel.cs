using ViewModels.Service;
using ViewModels.UserControls;
namespace ViewModels.UserControls;
public class NewGameViewModel: BasicViewModel
{
    public NewGameViewModel()
    {
        NavigationManager.VueCourante = new ThemeMenuViewModel();
    }
}
