using fit;

namespace FooTests
{
    public class RegistrationScript : Fixture
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsRegistered
        {
            get { return Reference.Registrations.Contains(FirstName, LastName); }
        }

        public void Register()
        {
            Reference.Registrations.Add(FirstName, LastName);
        }

        public int NumberOfRegisteredUsers
        {
            get { return Reference.Registrations.Count; }
        }
    }
}