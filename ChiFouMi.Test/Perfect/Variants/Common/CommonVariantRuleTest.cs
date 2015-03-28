namespace ChiFouMi.Test.Perfect.Variants.Common
{
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CommonVariantRuleTest
    {
        [TestMethod]
        public void GivenOverridenAnnouncementWhenToAnnouncementThenReturnOverridenAnnouncement()
        {
            const string overridenAnnouncement = "Yo!";
            var rule = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu, overridenAnnouncement);

            Check.That(rule.ToAnnouncement()).IsEqualTo(overridenAnnouncement);
        }

        [TestMethod]
        public void GivenNoOverridenAnnouncementWhenToAnnouncementThenReturnOverridenAnnouncement()
        {
            var rule = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);

            Check.That(rule.ToAnnouncement()).IsEqualTo("Pierre contre Feuille!");
        }

        [TestMethod]
        public void Given2IdenticalRulesWhenEqualsThenReturnTrue()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);
            var rule2 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);

            Check.That(rule1.Equals(rule2)).IsTrue();
        }

        [TestMethod]
        public void Given2DifferentRulesWhenEqualsThenReturnFalse()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);
            var rule2 = new CommonVariantRule(CoupType.Pierre, CoupType.Ciseaux, PlayerTurnResult.Perdu);

            Check.That(rule1.Equals(rule2)).IsFalse();
        }

        [TestMethod]
        public void Given1RuleAndNullWhenEqualsThenReturnFalse()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);

            Check.That(rule1.Equals(null)).IsFalse();
            Check.That(Equals(rule1, null)).IsFalse();
        }

        [TestMethod]
        public void GivenRule1AndRule1WhenEqualsThenReturnTrue()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);

            Check.That(rule1.Equals(rule1)).IsTrue();
        }

        [TestMethod]
        public void WhenGetHashCodeThenDontThrowAny()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);

            Check.ThatCode(() => rule1.GetHashCode()).DoesNotThrow();
        }

        [TestMethod]
        public void WhenToStringThenReturnCorrectFormat()
        {
            var rule1 = new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu, "Yo");

            var format = rule1.ToString();

            Check.That(format).IsEqualTo("Pierre, Feuille, Perdu, Yo");
        }
    }
}