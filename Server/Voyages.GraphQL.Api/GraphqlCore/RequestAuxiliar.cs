using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Voyages.Domain;

namespace Voyages.GraphQL.Api.GraphqlCore
{
    public class RequestAuxiliar
    {
        public static T RequestToApiRest<T>(string URL) where T : class
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var dataObject = response.Content.ReadAsAsync<T>().Result;
                        return dataObject;
                    }
                    else
                    {
                        return null as T;
                    }
                }
            }catch (Exception e)
            {
                //throw new Exception("URL: " + URL + e.ToString());
                Client client = new Client();
                client.Name = "URL: " + URL + e.ToString();
                return client as T;
            }
        }
    }
}
