namespace ChiFouMi.Test.Perfect.Variants
{
    using ChiFouMi.Perfect.Variants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class VariantTypeConverterTest
    {
        private VariantTypeConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new VariantTypeConverter();
        }

        [TestMethod]
        public void WhenNullThenReturnNone()
        {
            Check.That(_converter.Convert(null)).IsEqualTo(VariantType.Common);
        }

        [TestMethod]
        public void WhenRoxorThenReturnRoxor()
        {
            Check.That(_converter.Convert("roxor")).IsEqualTo(VariantType.Roxor);
        }
    }
}
