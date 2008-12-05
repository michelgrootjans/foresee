using fit;
using Jukebox.Domain;

namespace MyBlogPosts.FitNesse
{
    public class DepositScript : Fixture
    {
        public double Amount { get; set; }
        private readonly Account account;

        public DepositScript()
        {
            account = new Account(0);
        }

        public int Credits()
        {
            return account.Credits;
        }

        public void Deposit()
        {
            account.Deposit(Amount);
        }
    }
}