namespace ChiFouMi.Test.Perfect.Variants
{
    using System.Linq;
    using ChiFouMi.Perfect.Variants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;
    using TestHelpers;

    [TestClass]
    public class ChiFouMiVariantsFactoryTest
    {
        private ChiFouMiVariantsFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new ChiFouMiVariantsFactory();
        }

        [TestMethod]
        public void WhenCreateThenReturnAllDerivedTypesOfIChiFouMiVariant()
        {
            var creations = _factory.Create(new TestExternalDependencies(Enumerable.Empty<string>(), 1));
            var types = creations.Select(c => c.GetType()).ToArray();

            Check.That(types).HasSize(2);
            Check.That(types).Contains(typeof(CommonVariant), typeof(RoxorVariant));
        }
    }
}
