using System.Collections.Generic;
using fitlibrary;
using Jukebox.Domain;

namespace Jukebox.IntegrationTests
{
    public class JukeboxRunner : DoFixture
    {
        private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void CreateAccountWithCredits(string owner, int startingCredits)
        {
            accounts.Add(owner, new Account(startingCredits));
        }

        public void DepositInAccount(double amount, string owner)
        {
            accounts[owner].Deposit(amount);
        }

        public void PlayFor(string song, string owner)
        {
            var jukebox = new Player(accounts[owner]);
            jukebox.Play(song);
        }

        public int CreditFor(string owner)
        {
            return accounts[owner].Credits;
        }
    }
}