using System.Windows.Input;

namespace Command;

public class RelayCommand : ICommand
{
    private readonly Action _executeSansParametre;
    private readonly Action<object> _executeAvecParametre;
    public RelayCommand(Action execute)
    {
        _executeSansParametre = execute;
    }
    public RelayCommand(Action<object> execute)
    {
        _executeAvecParametre = execute;
    }

    public event EventHandler CanExecuteChanged;
    
    public bool CanExecute(object parameter) => true;
    public void Execute(object parameter)
    {
        if (_executeSansParametre != null)
        {
            _executeSansParametre();
        }
        else if (_executeAvecParametre != null)
        {
            _executeAvecParametre(parameter);
        }
    }
}