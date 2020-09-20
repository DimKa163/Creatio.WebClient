namespace Creatio.WebClient.Test
{
    using Creatio.WebClient.Configuration;
    using Xunit;
    public class BodyBuilderTest
    {
        [Fact]
        public void SerializeTest()
        {
            BodyBuilder bodyBuilder = new BodyBuilder(GetParameters());
            string json = bodyBuilder.Serialize();
            Assert.Equal(GetBodyJson(), json);
        }


        private ParameterCollection GetParameters()
        {
            ParameterCollection parameters = new ParameterCollection();
            Parameter parameter1 = new Parameter
            {
                Name = "Arg1",
                Value = 15
            };
            Parameter parameter2 = new Parameter
            {
                Name = "Arg",
                Value = 15
            };
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            return parameters;
        }

        private string GetBodyJson()
        {
            return "{\n\"Arg1\": 15,\n\"Arg\": 15\n}";
        }
    }
}
