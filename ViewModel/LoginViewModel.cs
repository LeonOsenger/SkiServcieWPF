using SkiServcieWPF.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public RelayCommand cmdTokenCreate { get; set; }

        public LoginViewModel()
        {
            cmdTokenCreate = new RelayCommand(param => Execute_LoginDataCheck(), param => true);
        }

        private string _user;
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

        private string Execute_LoginDataCheck()
        {
            return API.GetToken(User, Passwort);
        }
    }
}
