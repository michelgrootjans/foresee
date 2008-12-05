using System;

namespace Jukebox.Domain
{
    public class Account
    {
        public Account(int startingCredits)
        {
            Credits = startingCredits;
        }

        public void Deposit(double amount)
        {
            Credits += Convert.ToInt32(amount*4);
            
            if (amount >= 10)
                Credits += 10;
            else if (amount >= 5) 
                Credits += 5;
        }

        public int Credits { get; private set; }

        public void ConsumeCredit(int creditsToConsume)
        {
            if (Credits < creditsToConsume)
                throw new InvalidOperationException("You don't have enough credits.");
            
            Credits -= creditsToConsume;
        }

        public bool CanPlay(string song)
        {
            return Credits > 0;
        }
    }
}