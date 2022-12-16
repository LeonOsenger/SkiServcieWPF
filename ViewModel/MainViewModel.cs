using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<AuftragsDatenViewModel> _personList = new ObservableCollection<AuftragsDatenViewModel>();

        private List<Auftragsdaten> AuftragsdatenGesamt = API.AufträgeRequest();

        public MainViewModel()
        {
            _personList = new ObservableCollection<AuftragsDatenViewModel>();

            foreach (var Zeile in AuftragsdatenGesamt)
            {
                _personList.Add(new AuftragsDatenViewModel(Zeile));
            }

            //CmdInsert = new RelayCommand(param => Execute_Insert(), param => CanExecute_Insert());
        }

        private AuftragsDatenViewModel _SelectedPerson = new AuftragsDatenViewModel(new Auftragsdaten());
        public AuftragsDatenViewModel SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                SetProperty<AuftragsDatenViewModel>(ref _SelectedPerson, value);
                OnPropertyChaged(nameof(SelectedPerson));
            }
        }

        public ObservableCollection<AuftragsDatenViewModel> PersonsList
        {
            get => _personList;
            set => _personList = value;
        }
    }
}
