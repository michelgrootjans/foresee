using System;
using System.Linq;
using fit;
using Foo;

namespace FooTests
{
    public class Registrations : RowFixture
    {

        public override object[] Query()
        {
            return Reference.Registrations.Members.ToArray();
        }

        public override Type GetTargetClass()
        {
            return typeof(AltDotNetter);
        }
    }
}