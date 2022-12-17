using SkiServcieWPF.Model;
using SkiServcieWPF.Utility;
using SkiServcieWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkiServcieWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<AuftragsDatenViewModel> _personList = new ObservableCollection<AuftragsDatenViewModel>();

        private List<Auftragsdaten> AuftragsdatenGesamt = API.AufträgeRequest();

        public RelayCommand cmdLoginPage { get; set; }

        public MainViewModel()
        {
            _personList = new ObservableCollection<AuftragsDatenViewModel>();

            foreach (var Zeile in AuftragsdatenGesamt)
            {
                _personList.Add(new AuftragsDatenViewModel(Zeile));
            }

            cmdLoginPage = new RelayCommand(param => Execute_LoginPage(), param => CanExecute_LoginPage());
        }

        private Auftragsdaten _SelectedPerson = new Auftragsdaten();
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

        public ObservableCollection<AuftragsDatenViewModel> PersonsList
        {
            get => _personList;
            set => _personList = value;
        }

        private void Execute_LoginPage()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private bool CanExecute_LoginPage()
        {
            return true;
        }
    }
}
