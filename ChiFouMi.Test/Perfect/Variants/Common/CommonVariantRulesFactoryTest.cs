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
        [TestMethod]
        public void GivenSimpleModeWhenCreateThenReturnExpectedRules()
        {
            var rules = new CommonVariantRulesFactory(VariantMode.Simple).Create().ToList();

            Check.That(rules).HasSize(9);
            Check.That(rules.Where(r => !string.IsNullOrEmpty(r.OverridenAnnouncement))).HasSize(2);

            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles(VariantMode.Simple))
            {
                Check.That(rules.Count(rule => rule.PlayerCoup == coup)).IsEqualTo(3);
                Check.That(rules.Count(rule => rule.ComputerCoup == coup)).IsEqualTo(3);
            }
        }

        [TestMethod]
        public void GivenExtendedModeWhenCreateThenReturnExpectedRules()
        {
            var rules = new CommonVariantRulesFactory(VariantMode.Extended).Create().ToList();

            Check.That(rules).HasSize(25);
            Check.That(rules.Where(r => !string.IsNullOrEmpty(r.OverridenAnnouncement))).HasSize(2);

            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles(VariantMode.Extended))
            {
                Check.That(rules.Count(rule => rule.PlayerCoup == coup)).IsEqualTo(5);
                Check.That(rules.Count(rule => rule.ComputerCoup == coup)).IsEqualTo(5);
            }
        }
    }
}