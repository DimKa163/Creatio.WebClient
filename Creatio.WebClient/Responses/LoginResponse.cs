namespace Creatio.WebClient.Responses
{
    using Newtonsoft.Json;
    using System;
    /// <summary>
    /// Authorization object response
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Result code
        /// </summary>
        [JsonProperty("Code")]
        public int Code { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        [JsonProperty("Message")]
        public string Message { get; set; }
        /// <summary>
        /// Exception
        /// </summary>
        [JsonProperty("Exception")]
        public Exception Exception { get; set; }
        /// <summary>
        /// Url for change password
        /// </summary>
        [JsonProperty("PasswordChangeUrl")]
        public string PasswordChangeUrl { get; set; }
        /// <summary>
        /// Redirect url
        /// </summary>
        [JsonProperty("RedirectUrl")]
        public string RedirectUrl { get; set; }
    }
}
