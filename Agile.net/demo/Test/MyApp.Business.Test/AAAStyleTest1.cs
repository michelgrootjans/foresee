using Artilium.Arta.Test.AAA;
using NUnit.Framework;

namespace MyApp.Business.Test
{
    public class When_priceController_creates_a_price : ArrangeActAssert<IPriceController>
    {
        public override void Arrange()
        {
        }

        public override IPriceController CreateSUT()
        {
            return new PriceController();
        }

        public override void Act()
        {
        }

        [Test]
        public void observation()
        {
            
        }
    }

    public interface IPriceController
    {
    }

    internal class PriceController : IPriceController    
    {
    }
}