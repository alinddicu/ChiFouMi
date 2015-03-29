namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Linq;

    public class CommonVariantReferee
    {
        private readonly CommonVariantRule[] _rules;

        public CommonVariantReferee(ICommonVariantRulesFactory commonVariantRulesFactory)
        {
            _rules = commonVariantRulesFactory.Create().ToArray();
        }

        public TurnDecision Decide(CoupType playerCoup, CoupType computerCoup)
        {
            var appliedRule = _rules.SingleOrDefault(rule => rule.PlayerCoup == playerCoup && rule.ComputerCoup == computerCoup);
            if (appliedRule == null)
            {
                return new TurnDecision(TurnNextAction.Exit);
            }

            return new TurnDecision(
                appliedRule.PlayerTurnResult, 
                TurnNextAction.Play,
                appliedRule.ToAnnouncement());
        }
    }
}