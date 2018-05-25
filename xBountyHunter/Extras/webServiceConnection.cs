using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;

namespace xBountyHunter.Extras
{
    public class webServiceConnection
    {
        private const string URL_WS1 = @"http://201.168.207.210/services/droidBHServices.svc/fugitivos";
        private const string URL_WS2 = @"http://201.168.207.210/services/droidBHServices.svc/atrapados";
        private HttpClient client;
        private Page mainPage;

        public webServiceConnection(Page page)
        {
            mainPage = page;
        }

        public void connectGET()
        {
            List<Models.mFugitivos> fugitivos = new List<Models.mFugitivos>();
            client = new HttpClient();

            try
            {
                HttpResponseMessage response = client.GetAsync(URL_WS1).Result;
                if(response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    List<Models.mFugitivos> items = JsonConvert.DeserializeObject<List<Models.mFugitivos>> (content);
                    verifyFugitivosOnDB(items);
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                    connectGET();
                else
                    mainPage.DisplayAlert("Error", "No se pudo conectar con los servicios web", "Aceptar");
            }
        }

        public string connectPOST(string udid)
        {
            string result = "";
            string postBody = "{\"UDIDString\":\"" + udid + "\"}";
            client = new HttpClient();
            try
            {
                HttpContent bodyContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(URL_WS2, bodyContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    Dictionary<string, string> jsondata = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
                    result = jsondata["mensaje"];
                }
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message == "Error: NameResolutionFailure")
                    connectGET();
                else
                    mainPage.DisplayAlert("Error", "No se pudo conectar con los servicios web", "Aceptar");
            }
            return result;
        }

        private void verifyFugitivosOnDB(List<Models.mFugitivos> fugitivos)
        {
            List<Models.mFugitivos> dbFugitivos = new List<Models.mFugitivos>();
            Extras.databaseManager db = new Extras.databaseManager();
            dbFugitivos = db.selectAll();
            foreach(Models.mFugitivos fugitivo in fugitivos)
            {
                if(!dbFugitivos.Exists(xBountyApp => xBountyApp.Name == fugitivo.Name))
                {
                    fugitivo.Capturado = false;
                    db.insertItem(fugitivo);
                }
            }
            db.closeConnection();
        }
    }
}
