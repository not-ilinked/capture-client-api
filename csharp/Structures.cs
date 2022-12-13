using Newtonsoft.Json;

namespace Capture.Client.API 
{
    public static class CaptchaTypes 
    {
        public static string ReCaptcha = "recaptcha";
        public static string HCaptcha = "hcaptcha";
        public static string FunCaptcha = "funcaptcha";
    }

    public class ProxyOptions 
    {
        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class SolveOptions 
    {
        [JsonProperty("type")]
        public string CaptchaType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("site_key")]
        public string SiteKey { get; set; }

        [JsonProperty("proxy")]
        public ProxyOptions Proxy { get; set; }
    }

    public class CaptureUser 
    {
        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("credit")]
        public float Credit { get; private set; } 
    }

    internal class ErrorResponse 
    {
        [JsonProperty("message")]
        public string Message { get; private set; }
    }

    internal class SolutionResponse 
    {
        [JsonProperty("solution")]
        public string Solution { get; private set; }
    }
}