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
            else if (amount >= 1) 
                Credits += 1;
        }

        public int Credits { get; private set; }

        public void ConsumeCredit(int creditsToConsume)
        {
            Credits -= creditsToConsume;
        }

    }
}