namespace ScriptingSample
{
    using Xunit;

    public class Tests
    {
        [Fact]
        public void Test01()
        {
            var context = new ScriptContext
            {
                Customer = new Customer
                {
                    FirstName = "Clark"
                }
            };
            
            var engine = new RuleEngine<ScriptContext>(context);
            engine.ExecuteFile("Scripts/Rule01.csx");

            Assert.Equal(1, context.Result);
        }

        [Fact]
        public void Test02()
        {
            var context = new ScriptContext
            {
                Customer = new Customer
                {
                    FirstName = "Bruce"
                }
            };

            var engine = new RuleEngine<ScriptContext>(context);
            engine.ExecuteFile("Scripts/Rule01.csx");

            Assert.Equal(0, context.Result);
        }        
    }
}
