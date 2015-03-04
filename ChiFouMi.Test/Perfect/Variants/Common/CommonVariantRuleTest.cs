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
    }
}