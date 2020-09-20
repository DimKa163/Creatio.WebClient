namespace Creatio.WebClient.Configuration
{
    using Newtonsoft.Json;
    using System.Text;
    /// <summary>
    /// Serialize ParameterCollection to JSON string
    /// </summary>
    public class BodyBuilder
    {
        private readonly ParameterCollection _parameterCollection;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters">Parameter collection</param>
        public BodyBuilder(ParameterCollection parameters)
        {
            _parameterCollection = parameters;
        }
        /// <summary>
        /// Serialize parameter to JSON-format
        /// </summary>
        /// <returns>JSON-string</returns>
        public string Serialize()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _parameterCollection.Count; i++)
            {
                if (i == (_parameterCollection.Count - 1))
                    stringBuilder.Append(CreateJsonProperty(_parameterCollection[i]));
                else
                    stringBuilder.Append($"{CreateJsonProperty(_parameterCollection[i])},");
            }
            string json = "{\n" + stringBuilder.ToString() + "\n}";
            return json;
        }

        #region Private methods
        private string CreateJsonProperty(Parameter parameter)
        {
            string property = $"\n\"{parameter.Name}\": {JsonConvert.SerializeObject(parameter.Value)}";
            return property;
        }
        #endregion
        /// <summary>
        /// Serialize parameter to JSON-format
        /// </summary>
        /// <param name="parameters">Parameter collection</param>
        /// <returns>JSON-string</returns>
        public static string Serialize(ParameterCollection parameters)
        {
            BodyBuilder bodyBuilder = new BodyBuilder(parameters);
            return bodyBuilder.Serialize();
        }
    }
}
