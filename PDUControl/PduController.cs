using System.Net;
using System.Xml.Serialization;

namespace PDUControl
{
    public class PduController
    {
        private HttpClient _httpClient;
        private string _url;

        public void Connect(string address, string user, string password)
        {
            HttpClientHandler httpClientHandler = new () {Credentials = new NetworkCredential(user, password)};
            _httpClient = new HttpClient(httpClientHandler);
            _url = $"http://{address}/";
        }

        public void Switch(int port, bool on = true) => Get($"control_outlet.htm?outlet{port}=1&op={(@on ? 0 : 1)}");

        public PduStatus Status()
        {
            XmlSerializer serializer = new (typeof(PduStatus));
            using StringReader reader = new (Get("status.xml"));
            return (PduStatus)serializer.Deserialize(reader);
        }

        public string[] GetOutletNames()
        {
            string res = Get("config_PDU.htm");
            string[] names = new string[8];
            for (int i = 0; i < 8; i++)
            {
                string s = res.Substring(res.IndexOf("value=\"", res.IndexOf($"id=\"otlt{i}")) + 7);
                names[i] = s.Substring(0, s.IndexOf('"'));
            }
            return names;
        }

        private string Get(string cmd) => _httpClient.GetAsync($"{_url}{cmd}").Result.Content.ReadAsStringAsync().Result;
    }
}
