using System.Windows;
using System.Windows.Controls;
using Command;
using Data.Repositories;
using Models;
using Models.Enums;
using ViewModels.Service;
using ViewModels.UserControlsViewModels;
namespace ViewModels.UserControls
{
    public class QuestionLayoutViewModel :BasicViewModel
    {
        private bool _verificationEnCours = false;
        private List<Question> ? _toutesLesQuestions { get; set; }
        private int _score = 0 ;
        public int Score
        {
            get { return _score; }
            set { _score = value; OnPropertyChanged();}
        }
        private string _messageFeedback;
        public string MessageFeedback
        {
            get { return _messageFeedback; }
            set { _messageFeedback = value; OnPropertyChanged(); }
        }

        private bool _isMessageVisible;
        public bool IsMessageVisible
        {
            get { return _isMessageVisible; }
            set { _isMessageVisible = value; OnPropertyChanged(); }
        }
        private string _bonneReponse;
        public string BonneReponse
        {
            get { return _bonneReponse; }
            set { _bonneReponse = value;OnPropertyChanged(); }
        }
        
        public int _indexActuel = 0;
        public Theme ThemeQuestion { get; set; }
        private string _intituleDelaQuestion;
        public string ? IntituleDelaQuestion {
            get{return _intituleDelaQuestion;}
            set{_intituleDelaQuestion = value;
                OnPropertyChanged();} 
            }
        private object _vueQCMouOption;
        public object VueQCMouOption
        {
            get { return _vueQCMouOption; }
            set { _vueQCMouOption = value; OnPropertyChanged();}
        }
        public QuestionLayoutViewModel(Theme themeChoisi)
        {
            ThemeQuestion = themeChoisi;
            ChargerQuestionBDD();
            AfficherLesQuestions();
        }
        public void ChargerQuestionBDD()
        {
            var RepoQuestion = new QuestionRepository();
            _toutesLesQuestions = RepoQuestion.RecupererQuestionTheme(ThemeQuestion).ToList();
        }
        public void AfficherLesQuestions()
        {
            IntituleDelaQuestion = _toutesLesQuestions[_indexActuel].Intitule;
            if(_toutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
            {
                VueQCMouOption = new OptionQuestionLayoutViewModel(_toutesLesQuestions[_indexActuel].OptionsProposees, VerifierReponse);
            }
            else if(_toutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
            {
                VueQCMouOption = new OpenQuestionLayoutViewModel(VerifierReponse);
            }
            else if(_toutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.BossQuestion)
            {
                VueQCMouOption  = new BossQuestionLayoutViewModel();
            }
        }
        public async void VerifierReponse(String reponseUtilisateur)
        {
            if (_verificationEnCours) return;
            _verificationEnCours = true;
            string repUser = reponseUtilisateur?.ToLower().Trim() ?? "".Replace(" ", "");
            string repAttendue = _toutesLesQuestions[_indexActuel].Reponse?.ToLower().Trim() ?? "".Replace(" ", "");
            BonneReponse = _toutesLesQuestions[_indexActuel].Reponse;
            if(repUser.Contains(repAttendue) && repAttendue != "")
            {
                if(_toutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
                {
                Score+=3;
                }
                else if(_toutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
                {
                    Score+=1;
                }
                else{Score+=5;}
                MessageFeedback = "Bonne Réponse !";
            }
            else
            {
                MessageFeedback = "Mauvaise Réponse ! Dommage";
            }
            IsMessageVisible = true;

            await Task.Delay(3500);
            IsMessageVisible = false;
            _indexActuel++;   
            if (_indexActuel < _toutesLesQuestions.Count)
            {
            AfficherLesQuestions(); 
            }
            else
            {
            MessageBox.Show("Fin du Quiz !");
            }
            _verificationEnCours = false;
        }
    }
}