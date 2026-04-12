using System.Windows;
using Command;
using Data.Repositories;
using Models;
using Models.Enums;

namespace ViewModels.UserControls
{
    public class QuestionLayoutViewModel :BasicViewModel
    {
        private bool _verificationEnCours = false;
        private List<Question> ? ToutesLesQuestions { get; set; }
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
        private string _intituleColor = "yellow";
        public string IntituleColor
        {
            get { return _intituleColor; }
            set { _intituleColor = value; OnPropertyChanged();}
        }
        private string _messageFeedbackCOlor;
        public string MessageFeedbackColor
        {
            get { return _messageFeedbackCOlor; }
            set { _messageFeedbackCOlor = value; OnPropertyChanged();}
        }

        private bool _isMessageVisible;
        public bool IsMessageVisible
        {
            get { return _isMessageVisible; }
            set { _isMessageVisible = value; OnPropertyChanged(); }
        }
        private PartieRepository AccessPartie = new();
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
        public RelayCommand BoutonSave {get;}
        public Joueur NewJoueur { get; set; }
        public QuestionLayoutViewModel(Theme themeChoisi)
        {
            ThemeQuestion = themeChoisi;
            ChargerQuestionBDD();
            AfficherLesQuestions();
        }
        public QuestionLayoutViewModel(Theme themeChoisi, Partie partie,Joueur j)
        {
            BoutonSave = new RelayCommand(_=>Save(partie));
            NewJoueur = j;
            ThemeQuestion = themeChoisi;
            ChargerQuestionBDD();
            AfficherLesQuestions(partie);
        }
        public void ChargerQuestionBDD()
        {
            var RepoQuestion = new QuestionRepository();
            ToutesLesQuestions = RepoQuestion.RecupererQuestionTheme(ThemeQuestion).ToList();
        }
        public void AfficherLesQuestions()
        {
            if(_indexActuel==19) {IntituleColor ="Red";}
            else{IntituleColor ="yellow";}

            IntituleDelaQuestion = ToutesLesQuestions[_indexActuel].Intitule;
            if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
            {
                VueQCMouOption = new OptionQuestionLayoutViewModel(ToutesLesQuestions[_indexActuel].OptionsProposees, VerifierReponse);
            }
            else if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
            {
                VueQCMouOption = new OpenQuestionLayoutViewModel(VerifierReponse);
            }
        }
        public void AfficherLesQuestions(Partie p)
        {
            if(_indexActuel==19) {IntituleColor ="Red";}
            else{IntituleColor ="yellow";}

            IntituleDelaQuestion = ToutesLesQuestions[_indexActuel].Intitule;
            if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
            {
                VueQCMouOption = new OptionQuestionLayoutViewModel(ToutesLesQuestions[_indexActuel].OptionsProposees, (texteDuBouton) => { VerifierReponse(texteDuBouton,p); });
            }
            else if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
            {
                VueQCMouOption = new OpenQuestionLayoutViewModel((text) => { VerifierReponse(text,p); });
            }
        }
        public async void VerifierReponse(string reponseUtilisateur)
        {
            if (_verificationEnCours) return;
            _verificationEnCours = true;
            string repUser = reponseUtilisateur?.ToLower().Trim() ?? "".Replace(" ", "");
            string repAttendue = ToutesLesQuestions[_indexActuel].Reponse?.ToLower().Trim() ?? "".Replace(" ", "");
            BonneReponse = ToutesLesQuestions[_indexActuel].Reponse;
            if(repUser.Contains(repAttendue) && repAttendue != "")
            {
                if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
                {
                Score+=3;
                }
                else if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
                {
                    Score+=1;
                }
                else if (_indexActuel == 20) {Score+=5;}
                MessageFeedback = $"Bonne Réponse !";
                MessageFeedbackColor = "#4CAF50";
            }
            else
            {
                MessageFeedback = "Mauvaise Réponse ! Dommage";
                MessageFeedbackColor = "red";
            }
            IsMessageVisible = true;

            await Task.Delay(1700);
            IsMessageVisible = false;
            _indexActuel++;   
            if (_indexActuel < 20)
            {
            AfficherLesQuestions(); 
            }
            else
            {
            MessageBox.Show("Fin du Quiz !");
            }
            _verificationEnCours = false;
        }
        public async void VerifierReponse(string reponseUtilisateur, Partie partie)
        {
            if (_verificationEnCours) return;
            _verificationEnCours = true;
            string repUser = reponseUtilisateur?.ToLower().Trim() ?? "".Replace(" ", "");
            string repAttendue = ToutesLesQuestions[_indexActuel].Reponse?.ToLower().Trim() ?? "".Replace(" ", "");
            BonneReponse = ToutesLesQuestions[_indexActuel].Reponse;
            if(repUser.Contains(repAttendue) && repAttendue != "")
            {
                if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
                {
                Score+=3;
                }
                else if(ToutesLesQuestions[_indexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
                {
                    Score+=1;
                }
                else if (_indexActuel == 20) {Score+=5;}
                MessageFeedback = $"Bonne Réponse !";
                MessageFeedbackColor = "#4CAF50";
            }
            else
            {
                MessageFeedback = "Mauvaise Réponse ! Dommage";
                MessageFeedbackColor = "red";
            }
            IsMessageVisible = true;

            await Task.Delay(1700);
            IsMessageVisible = false;
            _indexActuel++;

            if (_indexActuel < 20)
            {
            AfficherLesQuestions(); 
            }
            else
            {
            MessageBox.Show("Fin du Quiz !");
            }
            _verificationEnCours = false;
        }
        public void Save(Partie partie)
        {
            AccessPartie.EnregistrerUnScore(partie,_score,ThemeQuestion);
            AccessPartie.EnregisterUneProgression(partie, ThemeQuestion,_indexActuel);
        }
    }
}