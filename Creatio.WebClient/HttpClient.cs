namespace Creatio.WebClient
{
    using Creatio.WebClient.Requests;
    using Creatio.WebClient.Responses;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;

    internal class HttpClient
    {
        private readonly Uri _uri;
        private static readonly CookieContainer _cookieContainer = new CookieContainer();
        private static string _bpmCsrf;
        public HttpClient(Uri uri)
        {
            _uri = uri;
        }

        /// <summary>
        /// Login under the current user
        /// </summary>
        /// <param name="login">Authorization request object</param>
        public Result Login(Login login)
        {
            string json = JsonConvert.SerializeObject(login);
            Result result = Post(json);
            if (result.Success)
            {
                HttpWebResponse response = result.HttpWebResponse;
                foreach (Cookie cookie in response.Cookies)
                    if (cookie.Name == "BPMCSRF")
                        _bpmCsrf = cookie.Value;
            }
            return result;
        }
        /// <summary>
        /// Make GET request
        /// </summary>
        /// <returns>Return object "Result"</returns>
        public Result Get()
        {
            Result result = new Result();
            HttpWebRequest request = CreateHttpWebRequest("GET");
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                result.HttpWebResponse = response;
            }
            catch (WebException ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.HttpWebResponse = ex.Response as HttpWebResponse;
            }
            return result;
        }

        /// <summary>
        /// Make POST request
        /// </summary>
        /// <param name="json">Body serialized to JSON (May be empty)</param>
        /// <returns>Return object "Result"</returns>
        public Result Post(string json)
        {
            Result result = new Result();
            HttpWebRequest request = CreateHttpWebRequest("POST");
            if (!string.IsNullOrEmpty(json))
                using(Stream stream = request.GetRequestStream())
                {
                    using(StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(json);
                    }
                }
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                result.HttpWebResponse = response;
            }
            catch(WebException ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.HttpWebResponse = ex.Response as HttpWebResponse;
            }
            return result;
        }

        #region Private methods
        private HttpWebRequest CreateHttpWebRequest(string method)
        {
            HttpWebRequest request = WebRequest.CreateHttp(_uri);
            request.CookieContainer = _cookieContainer;
            request.ContentType = "application/json";
            request.Method = method;
            if (!string.IsNullOrEmpty(_bpmCsrf))
                request.Headers.Add("BPMCSRF", _bpmCsrf);
            return request;
        }
        #endregion
    }
}
