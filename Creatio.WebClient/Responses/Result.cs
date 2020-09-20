using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Creatio.WebClient.Responses
{
    internal class Result
    {
        public bool Success { get; set; } = true;

        public HttpWebResponse HttpWebResponse { get; set; }

        public string ErrorMessage { get; set; } 
    }
}
