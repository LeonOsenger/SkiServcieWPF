using Newtonsoft.Json;
using RestSharp;
using SkiServcieWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServcieWPF
{
    public static class API
    {
        private static RestClient client = new RestClient("https://localhost:7020/api/ServiceAuftrag");

        private static RestRequest request = new RestRequest();

        public static List<Auftragsdaten> AufträgeRequest()
        {
            var GetAufträge = client.Get(request);

            List<Auftragsdaten> Auftragsliste = JsonConvert.DeserializeObject<List<Auftragsdaten>>(GetAufträge.Content);



            return Auftragsliste;
        }
    }
}
