using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.ViewModel
{
    public class AuftragsDatenViewModel : ViewModelBase
    {
        public Auftragsdaten _auftragsdaten;

        public string Auftrag_Dienstleistung => _auftragsdaten.Auftrag_Dienstleistung;

        public Priorität Auftrag_Priorität => _auftragsdaten.Auftrag_Priorität;

        public string Auftrag_KundenName => _auftragsdaten.Auftrag_KundenName;

        public string Auftrag_KundenEmail => _auftragsdaten.Auftrag_KundenEmail;

        public int Auftrag_KundenTelefon => _auftragsdaten.Auftrag_KundenTelefon;

        public Status Auftrag_status => _auftragsdaten.Auftrag_status;

        public DateTime Auftrag_CreateDate => _auftragsdaten.Auftrag_CreateDate;

        public DateTime Auftrag_PickUpDate => _auftragsdaten.Auftrag_PickUpDate;

        public AuftragsDatenViewModel(Auftragsdaten auftragsdaten)
        {
            _auftragsdaten = auftragsdaten;
        }
    }
}
