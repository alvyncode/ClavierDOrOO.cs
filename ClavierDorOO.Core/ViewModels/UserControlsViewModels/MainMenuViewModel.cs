using System;
using System.Windows.Input;
using Command;

namespace ViewModels.UserControls
{
    public class MainMenuViewModel :BasicViewModel
    {
        private Action _actionNaviguerVersNewGame;
        private Action _actionNaviguerVersLoad;
        private Action _actionNaviguerVersHistory;
        public ICommand BoutonNewGame { get;} 
        public ICommand BoutonLoad { get;} 
        public ICommand BoutonHistory { get;}
        public MainMenuViewModel(Action actionNaviguerNewGame, Action actionNaviguerLoad, Action actionNaviguerHistory)
        {
            _actionNaviguerVersHistory = actionNaviguerHistory;
            _actionNaviguerVersLoad = actionNaviguerLoad;
            _actionNaviguerVersNewGame = actionNaviguerNewGame;
            BoutonNewGame  = new RelayCommand(ExecuterNavigationNewGame);
            BoutonLoad  = new RelayCommand(ExecuterNavigationLoad);
            BoutonHistory  = new RelayCommand(ExecuterNavigationHistory);
        }
        private void ExecuterNavigationNewGame()
        {
            _actionNaviguerVersNewGame.Invoke();
        }
        private void ExecuterNavigationLoad()
        {
            _actionNaviguerVersHistory.Invoke();
        }
        private void ExecuterNavigationHistory()
        {
            _actionNaviguerVersHistory.Invoke();
        }
    }
}