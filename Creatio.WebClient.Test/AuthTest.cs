using System;
using Xunit;

namespace Creatio.WebClient.Test
{
    public class AuthTest
    {
        [Fact]
        public void LoginTest()
        {
            CreatioWebClient client = new CreatioWebClient("http://localhost:2012", "Supervisor", "Supervisor");
            var response = client.Login();
            Assert.NotNull(response);
            Assert.Equal(0, response.Code);
        }
    }
}
