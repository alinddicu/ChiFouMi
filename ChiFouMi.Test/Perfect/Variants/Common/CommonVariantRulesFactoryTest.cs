namespace ChiFouMi.Test.Perfect.Variants.Common
{
    using System.Linq;
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CommonVariantRulesFactoryTest
    {
        private CommonVariantRulesFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new CommonVariantRulesFactory();
        }

        [TestMethod]
        public void WhenCreateThenReturnExpectedRules()
        {
            var rules = _factory.Create().ToList();

            Check.That(rules).HasSize(9);
            Check.That(rules.Where(r => !string.IsNullOrEmpty(r.OverridenAnnouncement))).HasSize(2);

            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles())
            {
                Check.That(rules.Count(rule => rule.PlayerCoup == coup)).IsEqualTo(3);
                Check.That(rules.Count(rule => rule.ComputerCoup == coup)).IsEqualTo(3);
            }
        }
    }
}