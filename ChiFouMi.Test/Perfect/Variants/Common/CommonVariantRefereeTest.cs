namespace ChiFouMi.Test.Perfect.Variants.Common
{
    using System.Collections.Generic;
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CommonVariantRefereeTest
    {
        private CommonVariantRulesFactoryFake _rulesFactory;
        private CommonVariantReferee _referee;

        [TestInitialize]
        public void Initialize()
        {
            _rulesFactory = new CommonVariantRulesFactoryFake();
            _referee = new CommonVariantReferee(_rulesFactory);
        }

        [TestMethod]
        public void GivenExistingRuleWhenDecideThenReturnDecision()
        {
            var turnDecision = _referee.Decide(CoupType.Pierre, CoupType.Feuille);

            Check.That(turnDecision).Not.IsNull();
        }

        [TestMethod]
        public void GivenExistingRuleWhenDecideThenReturnNull()
        {
            var turnDecision = _referee.Decide(CoupType.None, CoupType.Feuille);

            Check.That(turnDecision).IsNull();
        }

        private class CommonVariantRulesFactoryFake : ICommonVariantRulesFactory
        {
            public IEnumerable<CommonVariantRule> Create()
            {
                return new[] { new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu) };
            }
        }
    }
}