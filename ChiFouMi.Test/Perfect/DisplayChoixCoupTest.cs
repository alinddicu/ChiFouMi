namespace ChiFouMi.Test.Perfect
{
    using ChiFouMi.Perfect;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class DisplayChoixCoupTest
    {
        private DisplayChoixCoup _displayer;

        [TestInitialize]
        public void Initialize()
        {
            _displayer = new DisplayChoixCoup();
        }

        [TestMethod]
        public void WhenGetThenReturnLabelsForAllEnumMembers()
        {
            var result = _displayer.Get();

            Check.That(result).ContainsExactly("1- Pierre", "2- Feuille", "3- Ciseaux");
        }
    }
}