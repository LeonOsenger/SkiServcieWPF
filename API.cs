using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        private static RestClient clientLogin = new RestClient("https://localhost:7020/api/Token/login");

        public static string GetToken(string User, string Passwort)
        {
            var payload = new JObject();
            payload.Add("Benutzer_Name", User);
            payload.Add("Benutzer_Passwort", Passwort);

            request.AddStringBody(payload.ToString(), DataFormat.Json);

            //var response = clientLogin.Execute(request, Method.Post).Content;

            return clientLogin.Execute(request, Method.Post).Content;
        }
    }
}
