using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using RestSharp;
using SkiServcieWPF.Commands;
using SkiServcieWPF.Model;
using SkiServcieWPF.Stores;
using SkiServcieWPF.Utility;
using SkiServcieWPF.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RelayCommand = SkiServcieWPF.Utility.RelayCommand;

namespace SkiServcieWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase, ICloseWindow
    {
        private LoginStore _loginStore;
        
        public DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new DelegateCommand(Execute_LoginDataCheck));

        public UserTokenModel UserToken { get; set; }
        public int LogginTrys { get; set; } = 0;
        public bool IsLoggedIn { get; set; } = false;

        public RelayCommand cmdTokenCreate { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        public LoginViewModel(LoginStore loginStore)
        {
            _loginStore = loginStore;
            
            cmdTokenCreate = new RelayCommand(param => Execute_LoginDataCheck(), param => CanExecute_LoginDataCheck());
        }

        

        private string _user;
        /// <summary>
        /// Benutzername des Mitarbeiter
        /// </summary>
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                OnPropertyChaged(nameof(User));
            }
        }

        private string _passwort;
        /// <summary>
        /// Passwort des Mitarbeiters
        /// </summary>
        public string Passwort
        {
            get
            {
                return _passwort;
            }
            set
            {
                _passwort = value;
                OnPropertyChaged(nameof(Passwort));
            }
        }

        /// <summary>
        /// Login Daten werden in API abfrage überprüft und wenn Richtig dann werden Name und Token übergeben
        /// </summary>
        private void Execute_LoginDataCheck()
        {
            UserTokenModel CheckUserData = new UserTokenModel();

            try
            {
                CheckUserData = API.GetToken(User, Passwort);
            }
            catch (Exception)
            {
                MessageBox.Show("Name oder Paswort Flasch", "Falsche Daten", MessageBoxButton.OK, MessageBoxImage.Error);
                User = string.Empty;
                Passwort = string.Empty;
                LogginTrys++;

                //Wenn User mehr als drei falsche versüche hat wird sein Programm geschlossen. 
                if (LogginTrys > 3)
                {
                    App.Current.Shutdown();
                }
                return;
            }
            
            IsLoggedIn = true;
            UserToken = CheckUserData;

            CreateUserLoginDataCommand createUserLoginDataCommand = new CreateUserLoginDataCommand(this, _loginStore);
            createUserLoginDataCommand.Execute(null);

            Close?.Invoke();
        }

        /// <summary>
        /// Kann man versuchen sich einzuloggen oder nicht
        /// </summary>
        /// <returns>True wenn Username und Passwort Feld augefühllt ist sonst false</returns>
        private bool CanExecute_LoginDataCheck()
        {
            if (!string.IsNullOrEmpty(Passwort) || !string.IsNullOrEmpty(User))
                return true;
            return false;
        }

        public Action Close { get; set; }
    }

    interface ICloseWindow
    {
        Action Close { get; set; }
    }
    
}
