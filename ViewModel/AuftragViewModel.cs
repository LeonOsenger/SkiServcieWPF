using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF.ViewModel
{
    public class AuftragViewModel : ViewModelBase
    {
        private string _Auftrag_Dienstleistung;
        public string Auftrag_Dienstleistung
        {
            get
            {
                return _Auftrag_Dienstleistung;
            }
            set
            {
                _Auftrag_Dienstleistung = value;
                OnPropertyChaged(nameof(Auftrag_Dienstleistung));
            }
        }


        private Priorität _Auftrag_Priorität;
        public Priorität Auftrag_Priorität
        {
            get
            {
                return _Auftrag_Priorität;
            }
            set
            {
                _Auftrag_Priorität = value;
                OnPropertyChaged(nameof(Auftrag_Priorität));
            }
        }


        private string _Auftrag_KundenName;
        public string Auftrag_KundenName
        {
            get
            {
                return _Auftrag_KundenName;
            }
            set
            {
                _Auftrag_KundenName = value;
                OnPropertyChaged(nameof(Auftrag_KundenName));
            }
        }


        private string _Auftrag_KundenEmail;
        public string Auftrag_KundenEmail
        {
            get
            {
                return _Auftrag_KundenEmail;
            }
            set
            {
                _Auftrag_KundenEmail = value;
                OnPropertyChaged(nameof(Auftrag_KundenEmail));
            }
        }


        private int _Auftrag_KundenTelefon;
        public int Auftrag_KundenTelefon
        {
            get
            {
                return _Auftrag_KundenTelefon;
            }
            set
            {
                _Auftrag_KundenTelefon = value;
                OnPropertyChaged(nameof(Auftrag_KundenTelefon));
            }
        }


        private Status _Auftrag_status;
        public Status Auftrag_status
        {
            get
            {
                return _Auftrag_status;
            }
            set
            {
                _Auftrag_status = value;
                OnPropertyChaged(nameof(Auftrag_status));
            }
        }


        private DateTime _Auftrag_CreateDate;
        public DateTime Auftrag_CreateDate
        {
            get
            {
                return _Auftrag_CreateDate;
            }
            set
            {
                _Auftrag_CreateDate = value;
                OnPropertyChaged(nameof(Auftrag_CreateDate));
            }
        }


        private DateTime _Auftrag_PickUpDate;
        public DateTime Auftrag_PickUpDate
        {
            get
            {
                return _Auftrag_PickUpDate;
            }
            set
            {
                _Auftrag_PickUpDate = value;
                OnPropertyChaged(nameof(Auftrag_PickUpDate));
            }
        }
    }
}
