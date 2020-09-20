namespace Creatio.WebClient.Test
{
    using Creatio.WebClient.Configuration;
    using Xunit;
    public class ParameterEqualsTest
    {
        [Fact]
        public void ParameterEqualTest()
        {
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
            Assert.True(parameter1.Equals(parameter2));

            Assert.True(parameter2.Equals(parameter1));
        }
        [Fact]
        public void ParameterHashCodeEqualTest()
        {
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
            int hash1 = parameter1.GetHashCode();
            int hash2 = parameter2.GetHashCode();
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void ParameterHashCodeNotEqualTest()
        {
            Parameter parameter1 = new Parameter
            {
                Name = "Arg",
                Value = 15
            };
            Parameter parameter2 = new Parameter
            {
                Name = "Arg1",
                Value = 15
            };
            int hash1 = parameter1.GetHashCode();
            int hash2 = parameter2.GetHashCode();
            Assert.NotEqual(hash1, hash2);
        }
    }
}
