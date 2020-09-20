namespace Creatio.WebClient.Test
{
    using Creatio.WebClient.Configuration;
    using Xunit;
    public class ParameterCollectionTest
    {
        [Fact]
        public void ParameterCollectionAddTest()
        {
            ParameterCollection parameters = new ParameterCollection();
            Parameter parameter1 = new Parameter
            {
                Name = "Arg",
                Value = 15
            };
            Parameter parameter2 = new Parameter
            {
                Name = "Arg",
                Value = 15
            };
            parameters.Add(parameter1);
            parameters.Add(parameter2);
            Assert.Equal(1, parameters.Count);
        }
        [Fact]
        public void ParameterCollectionRemoveTest()
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
            Assert.Equal(2, parameters.Count);
            parameters.Remove(parameter2);
            Assert.Equal(1, parameters.Count);
        }
    }
}
