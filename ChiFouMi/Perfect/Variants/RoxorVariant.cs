namespace ChiFouMi.Perfect.Variants
{
    public class RoxorVariant : IChiFouMiVariant
    {
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

        public TurnResult PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_dependencies.GetNextRandomBetween1And3());
            switch (computerChoice)
            {
                case CoupType.Pierre:
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                    break;
                case CoupType.Feuille:
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                    break;
                case CoupType.Ciseaux:
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                    break;
            }

            return TurnResult.Continue;
        }
    }
}
