using fit;

namespace Jukebox.IntegrationTests
{
    public class Calculator : ColumnFixture
    {
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }

        public int Sum()
        {
            return Arg1 + Arg2;
        }
    }
}