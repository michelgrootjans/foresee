using NUnit.Framework;

namespace Support.Test.Test
{
    public static class BooleanExtensions
    {
        public static void ShouldBeFalse(this bool item)
        {
            Assert.IsFalse(item);
        }
        public static void ShouldBeTrue(this bool item)
        {
            Assert.IsTrue(item);
        }
    }
}