using System.Windows;
using System.Windows.Input;
using System.Drawing;
using Models;
using Command;
using System.Windows.Controls;
namespace ViewModels.UserControls;

public class OptionQuestionLayoutViewModel:BasicViewModel
{
    public string PreOption { get; set; }
    public string DeuOption { get; set; }
    private string _troiOption;
    public string TroiOption { 
        get{return _troiOption;} 
        set{_troiOption = value;OnPropertyChanged(nameof(TroiOption));OnPropertyChanged(nameof(VisibiliteBoutonQuatre));}
        }
    private string _quaOption;
    public string QuaOption { 
        get{return _quaOption;}
        set{_quaOption = value; OnPropertyChanged(nameof(TroiOption)) ; OnPropertyChanged(nameof(VisibiliteBoutonQuatre));} 
        }
    public RelayCommand ValidationDesReponses { get; set; }
    private Action<String> _actionVerificationDuParent;
    public Visibility VisibiliteBoutonTrois => string.IsNullOrWhiteSpace(TroiOption) ? Visibility.Collapsed : Visibility.Visible;
    public Visibility VisibiliteBoutonQuatre => string.IsNullOrWhiteSpace(QuaOption) ? Visibility.Collapsed : Visibility.Visible;
    
    public OptionQuestionLayoutViewModel(Options options, Action<String> actionDeValidation)
    {
        _actionVerificationDuParent = actionDeValidation;
        PreOption = options.PremiereOption;
        DeuOption = options.DeuxiemeOption;
        TroiOption = options.TroisiemeOption;
        QuaOption = options.QuatrièmeOption;
        ValidationDesReponses = new RelayCommand(parametreXAML => 
        {
            if (parametreXAML is string texteDuBouton)
            {
                _actionVerificationDuParent(texteDuBouton);
            }
        });
    }
}
