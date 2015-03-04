namespace ChiFouMi.Perfect.Variants
{
    using System.Globalization;

    public class RoxorVariant : IChiFouMiVariant
    {
        private const string RoxorContreCoupText = "Tu es un roxor contre {0}";
        private readonly ISystemDependencies _systemDependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;

        public RoxorVariant(
            ISystemDependencies systemDependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _systemDependencies = systemDependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Roxor;
        }

        public TurnNextAction PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_systemDependencies.GetNextRandomBetween1And3());
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
