using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace Capture.Client.API 
{
    public class CaptureClientException : Exception 
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public CaptureClientException(HttpStatusCode statusCode, string message) : base(statusCode + " " + message) 
        {
            StatusCode = statusCode;
            ErrorMessage = message;
        }
    }

    public static class CaptureClient 
    {
        private static string GetUrl(int port, string endpoint) 
        {
            return "http://localhost:" + port + endpoint;
        }

        public static async Task<CaptureUser> GetUser(int clientPort) 
        {
            var resp = await new HttpClient().GetAsync(GetUrl(clientPort, "/user"));
            string respBody = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode >= HttpStatusCode.BadRequest) {
                var err = JsonConvert.DeserializeObject<ErrorResponse>(respBody);
                throw new CaptureClientException(resp.StatusCode, err.Message);
            }

            return JsonConvert.DeserializeObject<CaptureUser>(respBody);
        }

        public static async Task<string> SolveCaptcha(int clientPort, SolveOptions options) 
        {
            var client = new HttpClient();
            string serializedBody = JsonConvert.SerializeObject(options);

            var resp = await client.PostAsync(GetUrl(clientPort, "/solve"), new StringContent(serializedBody, Encoding.UTF8, "application/json"));
            string respBody = await resp.Content.ReadAsStringAsync();

            if (resp.StatusCode >= HttpStatusCode.BadRequest) {
                var err = JsonConvert.DeserializeObject<ErrorResponse>(respBody);
                throw new CaptureClientException(resp.StatusCode, err.Message);
            }
            
            return JsonConvert.DeserializeObject<SolutionResponse>(respBody).Solution;
        }
    }
}