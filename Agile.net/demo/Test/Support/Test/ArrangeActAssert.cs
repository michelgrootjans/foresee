//using Artilium.Arta.Utilities.Containers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Artilium.Arta.Test.AAA
{
    [TestFixture]
    public class ArrangeActAssert
    {
        [SetUp]
        public void SetUp()
        {            
            //Container.Initialize(new DictionaryContainer());
            Arrange();
            SetupSUT();
            Act();            
        }

        protected virtual void SetupSUT() { }

        public virtual void Arrange()
        {
        }

        public virtual void Act()
        {
        }

        [TearDown]
        public void TearDown()
        {
            //Container.Initialize(null);
            OnTearDown();
        }

        protected S RegisterStubInContainer<S>() where S : class
        {
            S s = MockRepository.GenerateStub<S>();
            //Container.Register(s);
            return s;
        }

        protected S IsAn<S>() where S : class
        {
            return MockRepository.GenerateStub<S>();
        }

        // TODO: Do we really need all these aliases? Eventually a developer will have to remember all of these are just stubs...
        protected S Dependency<S>() where S : class
        {
            return IsAn<S>();
        }

        protected S NotImportant<S>() where S : class
        {
            return IsAn<S>();
        }

        /// <summary>
        /// Called when [fixture tear down].
        /// </summary>
        public virtual void OnTearDown() { }
    }

    public class ArrangeActAssert<T> : ArrangeActAssert
    {
        protected T sut { get; private set; }

        protected override void SetupSUT()
        {
            sut = CreateSUT();
        }

        public virtual T CreateSUT()
        {
            return default(T);
        }
    }
}