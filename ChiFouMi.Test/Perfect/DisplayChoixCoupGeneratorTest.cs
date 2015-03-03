namespace ChiFouMi.Test.Perfect
{
    using ChiFouMi.Perfect;
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
        public void WhenGetThenReturnLabelsForAllEnumMembers()
        {
            var result = _displayer.Get();

            Check.That(result).ContainsExactly("1- Pierre", "2- Feuille", "3- Ciseaux");
        }
    }
}