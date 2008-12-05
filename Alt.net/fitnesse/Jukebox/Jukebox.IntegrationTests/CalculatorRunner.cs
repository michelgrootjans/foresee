using fit;
using Jukebox.Domain;

namespace MyBlogPosts.FitNesse
{
    public class CalculatorRunner : ColumnFixture
    {
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }

        public int Sum()
        {
            return new Calculator(Arg1, Arg2).Sum();
        }
    }
}