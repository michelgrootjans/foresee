using fit;
using Foo;

namespace FooTests
{
    public class Calculate : ColumnFixture
    {
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }

        public int Sum()
        {
            return new Calculator(Arg1, Arg2).Sum();
        }

        public int Diff()
        {
            return new Calculator(Arg1, Arg2).Diff();
        }

        public int Product()
        {
            return new Calculator(Arg1, Arg2).Product();
        }
    }
}