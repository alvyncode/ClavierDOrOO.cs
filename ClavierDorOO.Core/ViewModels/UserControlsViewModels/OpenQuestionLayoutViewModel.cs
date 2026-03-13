using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Command;
using ViewModels.UserControls;

namespace ViewModels.UserControls;

public class OpenQuestionLayoutViewModel:BasicViewModel
{
    private Action<String> _actionVerificationDuParent;
    private string _reponse;
    public string Reponse
    {
        get { return _reponse; }
        set { _reponse = value; OnPropertyChanged();}
    }
    public RelayCommand ValidationDesReponses { get; set; }
    public OpenQuestionLayoutViewModel(Action<String> actionDeValidation)
    {
        _actionVerificationDuParent = actionDeValidation;
        ValidationDesReponses = new RelayCommand(parametreXAML=>{
            if (parametreXAML is string texteDuBouton)
            {
                _actionVerificationDuParent(texteDuBouton);
            }
        });
    }
}
