using System.Windows.Controls;
using ViewModels.UserControls;
namespace Views.UserControls
{
    public partial class RegisterUserControl : UserControl
    {
        public RegisterUserControl()
        {
            InitializeComponent();
            this.DataContext = new RegisterViewModel();   
        }
    }
}

