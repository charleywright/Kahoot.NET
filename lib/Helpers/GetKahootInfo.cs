using System;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Kahoot.NET.Structs;


namespace Kahoot.NET
{
    public static partial class Helpers
    {
        public static KahootInfo GetKahootInfo(int gamePin)
        {
            RestClient client = new RestClient("https://kahoot.it/reserve/session");
            RestRequest request = new RestRequest($"/{gamePin}/?{DateTime.Now}");
            IRestResponse response = client.Get(request);
            KahootInfoJson json = JsonConvert.DeserializeObject<KahootInfoJson>(response.Content);
            KahootInfo info = new KahootInfo();
            info.challenge = json.challenge;
            info.namerator = json.namerator;
            info.participantId = json.participantId;
            info.smartPractice = json.smartPractice;
            info.twoFactorAuth = json.twoFactorAuth;
            info.header = response.Headers.ToList().Find(x => x.Name == "x-kahoot-session-token").Value.ToString();
            return info;
        }
    }

}