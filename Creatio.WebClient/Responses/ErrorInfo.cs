namespace Creatio.WebClient.Responses
{
    using Newtonsoft.Json;
    /// <summary>
    /// Error object
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        /// <summary>
        /// Error description
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// Error stack trace
        /// </summary>
        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }
    }
}
