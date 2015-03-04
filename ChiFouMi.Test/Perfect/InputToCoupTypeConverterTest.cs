namespace ChiFouMi.Test.Perfect
{
    using System;
    using System.Globalization;
    using ChiFouMi.Perfect;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class InputToCoupTypeConverterTest
    {
        private InputToCoupTypeConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new InputToCoupTypeConverter();
        }

        [TestMethod]
        public void WhenNullThenReturnNone()
        {
            Check.That(_converter.Convert(null)).IsEqualTo(CoupType.None);
        }

        [TestMethod]
        public void WhenRandomThenReturnNone()
        {
            Check.That(_converter.Convert("random")).IsEqualTo(CoupType.None);
            Check.That(_converter.Convert(Environment.NewLine)).IsEqualTo(CoupType.None);
        }

        [TestMethod]
        public void When123CharThenReturnNotNone()
        {
            var char123 = new[] { '1', '2', '3', '4', '5' };
            foreach (var item in char123)
            {
                Check.That(_converter.Convert(item)).IsEqualTo((CoupType)Convert.ToInt32(item.ToString(CultureInfo.InvariantCulture)));
            }
        }
    }
}