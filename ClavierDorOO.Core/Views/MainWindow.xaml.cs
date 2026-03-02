using System.Windows;
using System.Windows.Controls;
using ViewModels;
using Views.UserControls;

namespace Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
    }
}