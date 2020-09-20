namespace Creatio.WebClient.Test
{
    using System;
    using Xunit;

    public class LoadPackageTest
    {
        [Fact]
        public void LoadPackageToDbTest()
        {
            CreatioWebClient client = new CreatioWebClient("http://localhost:2012", "Supervisor", "Supervisor");
            client.Login();
            var response = client.LoadPackageToDb();
            Assert.NotNull(response);
            Assert.True(response.Success);
        }
        [Fact]
        public void LoadPackageToFileSystemTest()
        {
            CreatioWebClient client = new CreatioWebClient("http://localhost:2012", "Supervisor", "Supervisor");
            client.Login();
            var response = client.LoadPackageToFileSystem();
            Assert.NotNull(response);
            Assert.True(response.Success);
        }
    }
}
