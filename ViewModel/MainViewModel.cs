using Prism.Commands;
using SkiServcieWPF.Model;
using SkiServcieWPF.Stores;
using SkiServcieWPF.Utility;
using SkiServcieWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace SkiServcieWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly LoginStore _loginStore;
        private bool _isLoggedIn;

        private ObservableCollection<AuftragsDatenViewModel> _personList = new ObservableCollection<AuftragsDatenViewModel>();
        private List<Auftragsdaten> AuftragsdatenGesamt = new List<Auftragsdaten>();

        private UserLoginData UserLoginData;

        public RelayCommand cmdLoginPage { get; set; }
        public RelayCommand cmdSearch { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public MainViewModel(LoginStore loginStore)
        {
            _loginStore = loginStore;

            _personList = new ObservableCollection<AuftragsDatenViewModel>();

            _personList = PersonListZuweisen();

            cmdLoginPage = new RelayCommand(param => Execute_LoginPage(), param => true);
            cmdSearch = new RelayCommand(param => Execute_Search(Search));

            _loginStore.UserTokenCreated += OnUserTokenCreated;
        }

        private string _token;
        public string Token 
        { 
            get { return _token; } 
            set { _token = value; } 
        }

        private string _loginText = "Login";
        /// <summary>
        /// Text der auf dem Login Konpf angezeigt wird
        /// </summary>
        public string LoginText
        {
            get 
            { 
                return _loginText; 
            }
            set
            {
                _loginText = value;
                OnPropertyChaged(nameof(LoginText));
            }
        }

        public bool IsLoggedIn
        {
            get 
            { 
                return _isLoggedIn; 
            }
            set 
            {
                _isLoggedIn = value;
                OnPropertyChaged(nameof(IsLoggedIn));
            }
        }
        
        private Auftragsdaten _SelectedPerson = new Auftragsdaten();
        /// <summary>
        /// ausgewählter Datensatzt von ListView
        /// </summary>
        public Auftragsdaten SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if(value != _SelectedPerson)
                {
                    SetProperty<Auftragsdaten>(ref _SelectedPerson, value);
                    AuftragsDatenPerson = _SelectedPerson;
                }
            }
        }


        private Auftragsdaten _AuftragsDatenPerson = new Auftragsdaten();
        /// <summary>
        /// Die Daten die dann in den Textboxen stehen
        /// </summary>
        public Auftragsdaten AuftragsDatenPerson
        {
            get
            {
                return _AuftragsDatenPerson;
            }
            set
            {
                if (value != _AuftragsDatenPerson)
                {
                    SetProperty<Auftragsdaten>(ref _AuftragsDatenPerson, value);
                }
            }
        }

        private string _Search { get; set; } = String.Empty;
        /// <summary>
        /// Text in Such box
        /// </summary>
        public string Search 
        {
            get 
            { 
                return _Search; 
            } 
            set
            {
                _Search = value;
                OnPropertyChaged(nameof(Search));
            }
        }

        /// <summary>
        /// Liste der Aufträge für ListView
        /// </summary>
        public ObservableCollection<AuftragsDatenViewModel> PersonsList
        {
            get => _personList;
            set
            {
                _personList = value;
                OnPropertyChaged(nameof(PersonsList));
            }
            
        }

        public ObservableCollection<AuftragsDatenViewModel> PersonListZuweisen()
        {
            ObservableCollection<AuftragsDatenViewModel> ReturnList = new ObservableCollection<AuftragsDatenViewModel>();
            
            try
            {
                AuftragsdatenGesamt = API.AufträgeRequest();
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("API Verbindung ist Fehlgseschlage \n Fehlermeldung: " + ex, "API Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            foreach (var Zeile in AuftragsdatenGesamt)
            {
                ReturnList.Add(new AuftragsDatenViewModel(Zeile));
            }

            return ReturnList;
        }

        /// <summary>
        /// Aufträge suchen
        /// </summary>
        /// <returns>Liste der gesuchten aufträge</returns>
        private void Execute_Search(string search)
        {
            //ListView wird gelärt das nur die Daten die auch im ListView stehen sollen eingefügt werden können
            _personList.Clear();

            //Wenn in Suchleiste nix Steht werden wieder alle Daten angezeigt
            if (search == String.Empty)
            {
                _personList = PersonListZuweisen();
                OnPropertyChaged(nameof(PersonsList));
                return;
            }
            
            ObservableCollection<AuftragsDatenViewModel> zwischenSpeicher = new ObservableCollection<AuftragsDatenViewModel>();
            
            //Alle Datensätzte bei denen text aus Suchleiste enthalten werden wieder eigefügt
            foreach (var s in PersonListZuweisen())
            {
                if(s.Auftrag_KundenName.Contains(search))
                {
                    zwischenSpeicher.Add(s);
                }
            }
            foreach (var zw in zwischenSpeicher)
            {
                _personList.Add(zw);
            }
        }

        /// <summary>
        /// Login Fenster anzeigen
        /// </summary>
        private void Execute_LoginPage()
        {
            if(IsLoggedIn)
            {
                MessageBoxResult result = MessageBox.Show("Wollen sie sich Abbmelden?","Abmelden?",MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Token = String.Empty;
                        LoginText = "Login";
                        IsLoggedIn = false;
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        break;
                }
            }else
            {
                Login login = new Login(_loginStore);
                login.ShowDialog();
            }
        }

        /// <summary>
        /// Wenn UserLoginDaten erstellt werden werden die Values den etsprechenden Parametern übergegeben
        /// </summary>
        /// <param name="userLoginData"></param>
        private void OnUserTokenCreated(UserLoginData userLoginData)
        {
            Token = userLoginData.token;
            IsLoggedIn = userLoginData.IsLoggedIn;
            LoginText = userLoginData.userName;
        }
    }
}
