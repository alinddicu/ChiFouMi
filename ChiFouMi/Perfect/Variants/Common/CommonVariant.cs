namespace ChiFouMi.Perfect.Variants.Common
{
    public class CommonVariant : IChiFouMiVariant
    {
        private readonly IExternalDependencies _dependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;
        private readonly CommonVariantReferee _referee;

        public CommonVariant(
            IExternalDependencies dependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter,
            CommonVariantReferee referee)
        {
            _dependencies = dependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
            _referee = referee;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Common;
        }

        public TurnNextAction PlayTurn(CoupType playerCoup)
        {
            var computerCoup = _inputToCoupTypeConverter.Convert(_dependencies.GetNextRandomBetween1And3());
            var turnDecision = _referee.Decide(playerCoup, computerCoup);

            if (turnDecision == null)
            {
                return TurnNextAction.Exit;
            }

            _dependencies.WriteLine(turnDecision.Announcement);
            _dependencies.WriteLine(turnDecision.PlayerTurnResult.Announce());

            return TurnNextAction.Continue;
        }
    }
}