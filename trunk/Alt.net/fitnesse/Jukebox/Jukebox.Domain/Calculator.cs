namespace Jukebox.Domain
{
    public class Calculator
    {
        private readonly int arg1;
        private readonly int arg2;

        public Calculator(int arg1, int arg2)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
        }

        public int Sum()
        {
            return arg1 + arg2;
        }
    }
}