namespace Creatio.WebClient.Test
{
    using Creatio.WebClient.Configuration;
    using Xunit;
    public class CallConfigurationServiceTest
    {
        [Fact]
        public void CallCompileService()
        {
            CreatioWebClient client = new CreatioWebClient("http://localhost:2012", "Supervisor", "Supervisor");
            var response = client.Login();
            ParameterCollection parameters = new ParameterCollection();
            parameters.Add(new Parameter
            {
                Name = "compileAll",
                Value = false
            });
            var serviceResponse = client.CallConfigurationService<object>("ToolService", "CompileWorkspace", parameters: parameters );
            Assert.NotNull(serviceResponse);
        }
    }
}
