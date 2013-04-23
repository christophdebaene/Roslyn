namespace ScriptingSample
{
    public class ScriptContext
    {
        public int Result { get; set; }
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}