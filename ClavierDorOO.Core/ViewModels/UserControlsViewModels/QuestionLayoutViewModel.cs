using System.Windows;
using Command;
using Data.Repositories;
using Models;
using Models.Enums;
using Models.Roles;

namespace ViewModels.UserControls
{
    public class QuestionLayoutViewModel :BasicViewModel
    {
        private int _indiceCount = 0;
        public int IndiceCount
        {
            get { return _indiceCount; }
            set { _indiceCount = value;OnPropertyChanged(); }
        }
        
        private bool _devMobile;
        public bool DevMobile
        {
            get { return _devMobile; }
            set { _devMobile = value; OnPropertyChanged(); }
        }
        
        private bool _devFront;
        public bool DevFront
        {
            get { return _devFront; }
            set { _devFront = value; OnPropertyChanged(); }
        }
        
        private bool _devBack;
        public bool DevBack
        {
            get { return _devBack; }
            set { _devBack = value;OnPropertyChanged(); }
        }
        
        private bool _indiceVisible = false;
        public bool IndiceVisible
        {
            get { return _indiceVisible; }
            set { _indiceVisible = value; OnPropertyChanged();}
        }
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
        private int _indexActuel;
        public int IndexActuel
        {
            get { return _indexActuel; }
            set { _indexActuel = value;OnPropertyChanged(); }
        }
        
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
        private string _indice;
        public string Indice
        {
            get { return _indice; }
            set { _indice = value; OnPropertyChanged();}
        }
        private int _suivantCount;
        public int SuivantCount
        {
            get { return _suivantCount; }
            set { _suivantCount = value;OnPropertyChanged(); }
        }
        
        private int _reloadCount;
        public int ReloadCount
        {
            get { return _reloadCount; }
            set { _reloadCount = value; }
        }
        
        public RelayCommand BoutonSave {get;}
        public RelayCommand BoutonIndice { get;}
        public RelayCommand BoutonSuivant { get; }
        public RelayCommand BoutonReload { get;}
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
            var Role = partie.Role;
            if (Role is DeveloppeurMobile)
            {
                DevMobile = true;
            }
            else if(Role is DeveloppeurFront)
            {
                DevFront = true;
            }
            else if (Role is DeveloppeurBack)
            {
                DevBack = true;
            }
            BoutonIndice = new RelayCommand(AfficherIndice);
            BoutonSuivant = new RelayCommand(PasserSuivant);
            BoutonReload  = new RelayCommand(Reload);
            NewJoueur = j;
            ThemeQuestion = themeChoisi;
            ChargerQuestionBDD();
            AfficherLesQuestions(partie);
        }
        public QuestionLayoutViewModel(Theme themeChoisi, Partie partie,Joueur j,int progression)
        {
            IndexActuel = progression;
            BoutonSave = new RelayCommand(_=>Save(partie));
            var Role = partie.Role;
            if (Role is DeveloppeurMobile)
            {
                DevMobile = true;
            }
            else if(Role is DeveloppeurFront)
            {
                DevFront = true;
            }
            else if (Role is DeveloppeurBack)
            {
                DevBack = true;
            }
            BoutonIndice = new RelayCommand(AfficherIndice);
            BoutonSuivant = new RelayCommand(PasserSuivant);
            BoutonReload  = new RelayCommand(Reload);
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
            if(IndexActuel==19) {IntituleColor ="Red";}
            else{IntituleColor ="yellow";}

            Indice = ToutesLesQuestions[IndexActuel].Indice;
            IntituleDelaQuestion = ToutesLesQuestions[IndexActuel].Intitule;
            if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
            {
                VueQCMouOption = new OptionQuestionLayoutViewModel(ToutesLesQuestions[IndexActuel].OptionsProposees, VerifierReponse);
            }
            else if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
            {
                VueQCMouOption = new OpenQuestionLayoutViewModel(VerifierReponse);
            }
        }
        public void AfficherLesQuestions(Partie p)
        {
            if(IndexActuel==19) {IntituleColor ="Red";}
            else{IntituleColor ="yellow";}
            Indice = ToutesLesQuestions[IndexActuel].Indice;
            IntituleDelaQuestion = ToutesLesQuestions[IndexActuel].Intitule;
            if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
            {
                VueQCMouOption = new OptionQuestionLayoutViewModel(ToutesLesQuestions[IndexActuel].OptionsProposees, (texteDuBouton) => { VerifierReponse(texteDuBouton,p); });
            }
            else if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
            {
                VueQCMouOption = new OpenQuestionLayoutViewModel((text) => { VerifierReponse(text,p); });
            }
        }
        public async void VerifierReponse(string reponseUtilisateur)
        {
            IndiceVisible = false;
            if (_verificationEnCours) return;
            _verificationEnCours = true;
            string repUser = reponseUtilisateur?.ToLower().Trim() ?? "".Replace(" ", "");
            string repAttendue = ToutesLesQuestions[IndexActuel].Reponse?.ToLower().Trim() ?? "".Replace(" ", "");
            BonneReponse = ToutesLesQuestions[IndexActuel].Reponse;
            if(repUser.Contains(repAttendue) && repAttendue != "")
            {
                if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
                {
                Score+=3;
                }
                else if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
                {
                    Score+=1;
                }
                else if (IndexActuel == 20) {Score+=5;}
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
            IndexActuel++;   
            if (IndexActuel < 20)
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
            IndiceVisible = false;
            if (_verificationEnCours) return;
            _verificationEnCours = true;
            string repUser = reponseUtilisateur?.ToLower().Trim() ?? "".Replace(" ", "");
            string repAttendue = ToutesLesQuestions[IndexActuel].Reponse?.ToLower().Trim() ?? "".Replace(" ", "");
            BonneReponse = ToutesLesQuestions[IndexActuel].Reponse;
            if(repUser.Contains(repAttendue) && repAttendue != "")
            {
                if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OpenQuestion)
                {
                Score+=3;
                }
                else if(ToutesLesQuestions[IndexActuel].TypeDeQuestion == TypeDeQuestion.OptionQuestion)
                {
                    Score+=1;
                }
                else if (IndexActuel == 20) {Score+=5;}
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
            IndexActuel++;

            if (IndexActuel < 20)
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
            AccessPartie.EnregisterUneProgression(partie, ThemeQuestion,IndexActuel);
        }
        public void AfficherIndice()
        {
            IndiceCount++;
            if (IndiceCount <= 3)
            {
                IndiceVisible = true;
            }
            else
            {
                IndiceVisible = false;
                DevMobile = false;
            }
        }
        public void PasserSuivant()
        {
            SuivantCount++;
            if(SuivantCount<= 5)
            {
                IndexActuel++;
                AfficherLesQuestions();
            }
            else
            {
                DevFront = false;
            }
        }
        public void Reload()
        {
            ReloadCount++;
            if(ReloadCount<= 5 && IndexActuel != 0)
            {
                IndexActuel--;
                AfficherLesQuestions();
            }
            else if (IndexActuel == 0)
            {
                
            }
            else
            {
                DevBack = false;
            }
        }
    }
}