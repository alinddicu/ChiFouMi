namespace ChiFouMi.Test.Perfect.Variants
{
    using System.Linq;
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants;
    using ChiFouMi.Perfect.Variants.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;
    using TestHelpers;

    [TestClass]
    public class ChiFouMiVariantsFactoryTest
    {
        [TestMethod]
        public void GivenSimpleVariantWhenCreateThenReturnAllDerivedTypesOfIChiFouMiVariant()
        {
            var systemDependencies = new TestExternalDependencies(Enumerable.Empty<string>(), 1);
            var creations = new ChiFouMiVariantsFactory(ChiFuMiMode.Base, systemDependencies).Create();
            var types = creations.Select(c => c.GetType()).ToArray();

            Check.That(types).HasSize(2);
            Check.That(types).Contains(typeof(CommonVariant), typeof(RoxorVariant));
        }
    }
}