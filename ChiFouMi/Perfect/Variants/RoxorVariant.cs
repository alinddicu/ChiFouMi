namespace ChiFouMi.Perfect.Variants
{
    using System.Globalization;

    public class RoxorVariant : IChiFouMiVariant
    {
        private const string RoxorContreCoupText = "Tu es un roxor contre {0}";

        private readonly IExternalDependencies _dependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;

        public RoxorVariant(
            IExternalDependencies dependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _dependencies = dependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Roxor;
        }

        public TurnNextAction PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_dependencies.GetNextRandomBetween1And3());
            if (computerChoice.IsCoupElligible())
            {
                WriteLinesOnGagne(computerChoice);
            }

            return TurnNextAction.Continue;
        }

        private void WriteLinesOnGagne(CoupType computerChoice)
        {
            var roxorLine = string.Format(CultureInfo.InvariantCulture, RoxorContreCoupText, computerChoice);
            _dependencies.WriteLine(roxorLine);
            _dependencies.WriteLine(PlayerTurnResult.Gagne.Announce());
        }
    }
}