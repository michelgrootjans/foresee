using fit;
using Jukebox.Domain;

namespace Jukebox.IntegrationTests
{
    public class DepositScript : Fixture
    {
        private readonly Account account;

        public DepositScript()
        {
            account = new Account(0);
        }

        public double Amount { get; set; }
        public int Credits { get; private set; }

        public void Deposit()
        {
            account.Deposit(Amount);
            Credits = account.Credits;
        }
    }
}