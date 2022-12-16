using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkiServcieWPF.Model
{
    public class Auftragsdaten
    {
        public string Auftrag_Dienstleistung { get; set; }

        public Priorität Auftrag_Priorität { get; set; }

        public string Auftrag_KundenName { get; set; }

        public string Auftrag_KundenEmail { get; set; }

        public int Auftrag_KundenTelefon { get; set; }

        public Status Auftrag_status { get; set; }

        public DateTime Auftrag_CreateDate { get; set; }

        public DateTime Auftrag_PickUpDate { get; set; }
    }

    public enum Priorität
    {
        Niedrig, Mittel, Hoch
    }

    public enum Status
    {
        Offen, InArbeit, Abgeschlossen
    }
}
