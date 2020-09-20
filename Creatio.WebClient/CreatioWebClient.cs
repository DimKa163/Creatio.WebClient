namespace Creatio.WebClient
{
    using System;
    using System.IO;
    using System.Net;
    using Creatio.WebClient.Configuration;
    using Creatio.WebClient.Requests;
    using Creatio.WebClient.Responses;
    using Newtonsoft.Json;

    /// <summary>
    /// Send request to Creatio
    /// </summary>
    public class CreatioWebClient
    {
        private const string AUTH_SERVICE = "ServiceModel/AuthService.svc/Login";
        private const string LOAD_PACKAGE_TO_DB = "0/ServiceModel/AppInstallerService.svc/LoadPackagesToDB";
        private const string LOAD_PACKAGE_TO_FILESYSTEM = "0/ServiceModel/AppInstallerService.svc/LoadPackagesToFileSystem";

        private readonly string _url;
        private readonly string _login;
        private readonly string _password;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Base url</param>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        public CreatioWebClient(string url, string login, string password)
        {
            _url = url;
            _login = login;
            _password = password;
        }
        /// <summary>
        /// Login under the current user
        /// </summary>
        /// <returns>Returns authorization operation response object</returns>
        public LoginResponse Login()
        {
            Uri uri = new Uri($"{_url}/{AUTH_SERVICE}");
            Login login = new Login
            {
                UserName = _login,
                UserPassword = _password
            };
            HttpClient client = new HttpClient(uri);
            Result result = client.Login(login);
            HttpWebResponse response = result.HttpWebResponse;
            LoginResponse loginResponse = GetEntity<LoginResponse>(response.GetResponseStream());
            return loginResponse;
        }
        /// <summary>
        /// Load packages to database
        /// </summary>
        /// <returns>Returns package operation response object</returns>
        public PackageResponse LoadPackageToDb()
        {
            Uri uri = new Uri($"{_url}/{LOAD_PACKAGE_TO_DB}");
            HttpClient client = new HttpClient(uri);
            Result result = client.Post(string.Empty);
            if (result.Success)
            {
                HttpWebResponse response = result.HttpWebResponse;
                PackageResponse packageResponse = GetEntity<PackageResponse>(response.GetResponseStream());
                return packageResponse;
            }
            throw new Exception(result.ErrorMessage);
        }
        /// <summary>
        /// Load packages to filesystem
        /// </summary>
        /// <returns>Returns package operation response object</returns>
        public PackageResponse LoadPackageToFileSystem()
        {
            Uri uri = new Uri($"{_url}/{LOAD_PACKAGE_TO_FILESYSTEM}");
            HttpClient client = new HttpClient(uri);
            Result result = client.Post(string.Empty);
            if (result.Success)
            {
                HttpWebResponse response = result.HttpWebResponse;
                PackageResponse packageResponse = GetEntity<PackageResponse>(response.GetResponseStream());
                return packageResponse;
            }
            throw new Exception(result.ErrorMessage);
        }
        /// <summary>
        /// Call a REST service, which require authorization
        /// </summary>
        /// <param name="serviceName">Service name</param>
        /// <param name="serviceMethodName">service method name</param>
        /// <param name="method">Request type</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>JSON string</returns>
        public TEntity CallConfigurationService<TEntity>(string serviceName, string serviceMethodName, 
            ServiceMethod method = ServiceMethod.Post, ParameterCollection parameters = null) where TEntity : class
        {
            Uri uri = new Uri($"{_url}/0/rest/{serviceName}/{serviceMethodName}");
            HttpClient client = null;
            Result result = null;
            switch (method)
            {
                case ServiceMethod.Get:
                    if (parameters != null)
                        uri = new Uri($"{_url}/0/rest/{serviceName}/{serviceMethodName}?{UrlParameterBuilder.Serialize(parameters)}");
                    client = new HttpClient(uri);
                    result = client.Get();
                    break;
                case ServiceMethod.Post:
                    client = new HttpClient(uri);
                    string json = string.Empty;
                    if (parameters != null)
                        json = BodyBuilder.Serialize(parameters);
                    result = client.Post(json);
                    break;
                default:
                    break;
            }
            if (result != null && result.Success)
            {
                HttpWebResponse response = result.HttpWebResponse;
                return GetEntity<TEntity>(response.GetResponseStream());
            }
            throw new Exception(result.ErrorMessage);
        }
        #region Private methods
        private TEntity GetEntity<TEntity>(Stream stream) where TEntity : class
        {
            TEntity entity = null;
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                entity = JsonConvert.DeserializeObject<TEntity>(json);
            }
            return entity;
        }
        #endregion
    }
}
