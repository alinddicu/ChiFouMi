namespace ChiFouMi.Perfect.Variants
{
    using System.Globalization;

    public class RoxorVariant : IChiFouMiVariant
    {
        private const string RoxorContreCoupText = "Tu es un roxor contre {0}";
        private readonly ISystemDependencies _systemDependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;
        private readonly int _randomUpperLimit;

        public RoxorVariant(
            int randomUpperLimit,
            ISystemDependencies systemDependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _randomUpperLimit = randomUpperLimit;
            _systemDependencies = systemDependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Roxor;
        }

        public TurnNextAction PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_systemDependencies.GetRandomInt(_randomUpperLimit));
            if (computerChoice.IsCoupElligible())
            {
                WriteLinesOnGagne(computerChoice);
            }

            return TurnNextAction.Continue;
        }

        private void WriteLinesOnGagne(CoupType computerChoice)
        {
            var roxorLine = string.Format(CultureInfo.InvariantCulture, RoxorContreCoupText, computerChoice);
            _systemDependencies.WriteLine(roxorLine);
            _systemDependencies.WriteLine(PlayerTurnResult.Gagne.Announce());
        }
    }
}
