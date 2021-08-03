using System;
using System.Net.Http;
using Xunit;

namespace AluraFlix.Test.Integration
{
    public class VideosControllerVideos
    {
        [Fact]
        public void Dado_Chamada_Sem_Paramentros_Deve_Retornar_Todos_Videos_E_StatusCode_200()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:5001/Videos/");
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.io)");

            var response =  client.Send(request);
            var result =  response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
