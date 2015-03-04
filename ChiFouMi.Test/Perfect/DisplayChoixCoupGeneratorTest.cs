namespace ChiFouMi.Test.Perfect
{
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class DisplayChoixCoupGeneratorTest
    {
        private DisplayChoixCoupGenerator _displayer;

        [TestInitialize]
        public void Initialize()
        {
            _displayer = new DisplayChoixCoupGenerator();
        }

        [TestMethod]
        public void GivenSimpleModeWhenGetThenReturnLabelsForPierreFeuilleCiseaux()
        {
            var result = _displayer.Get(VariantMode.Simple);

            Check.That(result).ContainsExactly("1- Pierre", "2- Feuille", "3- Ciseaux");
        }

        [TestMethod]
        public void GivenExtendedModeWhenGetThenReturnLabelsForAllEnumMembersExceptNone()
        {
            var result = _displayer.Get(VariantMode.Extended);

            Check.That(result).ContainsExactly(
                "1- Pierre", "2- Feuille", "3- Ciseaux", "4- Lezard", "5- Spock");
        }
    }
}