using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkiServcieWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ListView mit Daten befüllen
            List<Auftragsdaten> AuftragsdatenGesamt = API.AufträgeRequest();

            List<AuftragsdatenListe> AuftragsdatenEinzel = new List<AuftragsdatenListe>();

            foreach (var Gesamt in AuftragsdatenGesamt)
            {
                this.ListAufträge.Items.Add(new AuftragsdatenListe { Name = Gesamt.Auftrag_KundenName, Priorität = Gesamt.Auftrag_Priorität, Auftrag = Gesamt.Auftrag_Dienstleistung} );
            }

            

        }
    }
}
