namespace Creatio.WebClient.Requests
{
    using Newtonsoft.Json;
    /// <summary>
    /// Authorization request object
    /// </summary>
    public class Login
    {
        /// <summary>
        /// User name
        /// </summary>
        [JsonProperty("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        [JsonProperty("UserPassword")]
        public string UserPassword { get; set; }

        public override string ToString()
        {
            return $"{UserName}:{UserPassword}";
        }
    }
}
