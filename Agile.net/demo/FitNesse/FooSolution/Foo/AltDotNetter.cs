namespace Foo
{
    public class AltDotNetter
    {
        public AltDotNetter(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}