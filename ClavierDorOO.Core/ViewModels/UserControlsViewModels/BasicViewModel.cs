using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ViewModels.UserControls
{    
    public abstract class BasicViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
