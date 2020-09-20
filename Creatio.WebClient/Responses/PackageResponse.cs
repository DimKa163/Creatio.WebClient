namespace Creatio.WebClient.Responses
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    /// <summary>
    /// Package install operation response
    /// </summary>
    public class PackageResponse
    {
        /// <summary>
        /// Error object
        /// </summary>
        [JsonProperty("errorInfo")]
        public ErrorInfo ErrorInfo { get; set; }
        /// <summary>
        /// Operation result
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// Changes
        /// </summary>
        [JsonProperty("changes")]
        public List<object> Changes { get; set; }
        /// <summary>
        /// Operations error
        /// </summary>
        [JsonProperty("errors")]
        public List<object> Errors { get; set; }
    }
}
