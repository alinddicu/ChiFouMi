namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Linq;

    public class CommonVariantReferee
    {
        private readonly CommonVariantRule[] _rules;

        public CommonVariantReferee(ICommonVariantRulesFactory commonVariantRulesFactory)
        {
            _rules = commonVariantRulesFactory.Create(CommonVariantMode.Simple).ToArray();
        }

        public TurnDecision Decide(CoupType playerCoup, CoupType computerCoup)
        {
            return _rules
                .Where(rule => rule.PlayerCoup == playerCoup && rule.ComputerCoup == computerCoup)
                .Select(rule => new TurnDecision(rule.PlayerTurnResult, rule.ToAnnouncement()))
                .SingleOrDefault();
        }
    }
}