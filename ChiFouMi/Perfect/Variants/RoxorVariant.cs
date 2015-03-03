namespace ChiFouMi.Perfect.Variants
{
    public class RoxorVariant : IChiFouMiVariant
    {
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

        public TurnResult PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_systemDependencies.GetNextRandomBetween1And3());
            switch (computerChoice)
            {
                case CoupType.Pierre:
                    _systemDependencies.WriteLine("Tu es un roxor contre Pierre");
                    _systemDependencies.WriteLine("Gagne!");
                    break;
                case CoupType.Feuille:
                    _systemDependencies.WriteLine("Tu es un roxor contre Feuille");
                    _systemDependencies.WriteLine("Gagne!");
                    break;
                case CoupType.Ciseaux:
                    _systemDependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _systemDependencies.WriteLine("Gagne!");
                    break;
            }

            return TurnResult.Continue;
        }
    }
}
