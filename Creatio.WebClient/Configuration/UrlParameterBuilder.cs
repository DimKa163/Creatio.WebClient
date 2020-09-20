namespace Creatio.WebClient.Configuration
{
    using System.Text;
    /// <summary>
    /// Serialize ParameterCollection to Url string
    /// </summary>
    public class UrlParameterBuilder : ArgumentBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">Parameter collection</param>
        public UrlParameterBuilder(ParameterCollection parameters) : base(parameters)
        {

        }
        /// <summary>
        /// Serialize parameter to URL-format
        /// </summary>
        /// <returns></returns>
        public sealed override string Serialize()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Parameters.Count; i++)
            {
                if (i == (Parameters.Count - 1))
                    stringBuilder.Append(CreateUrlParameter(Parameters[i]));
                else
                    stringBuilder.Append($",{CreateUrlParameter(Parameters[i])}");
            }
            return stringBuilder.ToString();
        }

        #region Private methods
        private string CreateUrlParameter(Parameter parameter)
        {
            return $"{parameter.Name}={parameter.Value}";
        }
        #endregion
        /// <summary>
        /// Serialize parameter to JSON-format
        /// </summary>
        /// <param name="parameters">Parameter collection</param>
        /// <returns>JSON-string</returns>
        public static string Serialize(ParameterCollection parameters)
        {
            UrlParameterBuilder urlBuilder = new UrlParameterBuilder(parameters);
            return urlBuilder.Serialize();
        }
    }
}
