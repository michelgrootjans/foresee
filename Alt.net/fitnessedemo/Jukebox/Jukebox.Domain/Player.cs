namespace Jukebox.Domain
{
    public class Player
    {
        private readonly Account account;

        public Player(Account account)
        {
            this.account = account;
        }

        public void Play(string song)
        {
            account.ConsumeCredit(1);
        }
    }
}