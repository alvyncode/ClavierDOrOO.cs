using System.Windows.Controls;
using ViewModels.UserControls;
namespace Views.UserControls;
public partial class RulesView: UserControl
{
    public RulesView()
    {
        InitializeComponent();
        this.DataContext = new RulesViewModel();
    }
}