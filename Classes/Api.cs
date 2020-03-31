using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioCodeNation.Classes;
using Newtonsoft.Json;
using System.IO;

namespace DesafioCodeNation.Classes
{
    class Api
    {
        private readonly string Token = "d269d6d8069eeb13487ad654a6c3c7026b8489cc";
        private string PathFolder = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public Answer getData()
        {

            try
            {
                RestClient client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=" + Token)
                {
                    Timeout = -1
                };

                RestRequest request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);

                Answer answer = JsonConvert.DeserializeObject<Answer>(response.Content);

                return answer;

            } catch(Exception e)
            {
                throw (e);

            }

        }

        public void postData()
        {
            var client = new RestClient("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=d269d6d8069eeb13487ad654a6c3c7026b8489cc")
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.POST);
            request.AddFile("answer", PathFolder+"//answer.json");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
