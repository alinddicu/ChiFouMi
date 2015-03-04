namespace ChiFouMi.Perfect.Variants
{
    public class CommonVariant : IChiFouMiVariant
    {
        private readonly IExternalDependencies _dependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;

        public CommonVariant(
            IExternalDependencies dependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _dependencies = dependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Common;
        }

        public TurnNextAction PlayTurn(CoupType playerCoup)
        {
            var computerCoup = _inputToCoupTypeConverter.Convert(_dependencies.GetNextRandomBetween1And3());

            if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Ciseaux)
            {
                // emmerde
                _dependencies.WriteLine("Pierre contre Feuille!"); // faux
                _dependencies.WriteLine("Perdu!");
            }
            else if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Pierre)
            {
                // emmerde
                _dependencies.WriteLine("Pierre contre Feuille!"); // faux
                _dependencies.WriteLine("Perdu!"); // faux
            }
            else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Feuille)
            {
                _dependencies.WriteLine("Pierre contre Feuille!");
                _dependencies.WriteLine("Perdu!");
            }
            else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Ciseaux)
            {
                _dependencies.WriteLine("Pierre contre Ciseaux!");
                _dependencies.WriteLine("Gagne!");
            }
            else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Pierre)
            {
                _dependencies.WriteLine("Ciseaux contre Pierre!");
                _dependencies.WriteLine("Perdu!");
            }
            else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Feuille)
            {
                _dependencies.WriteLine("Ciseaux contre Feuille!");
                _dependencies.WriteLine("Gagne!");
            }
            else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Pierre)
            {
                _dependencies.WriteLine("Pierre contre Pierre!");
                _dependencies.WriteLine("Egalite!");
            }
            else if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Feuille)
            {
                _dependencies.WriteLine("Feuille contre Feuille!");
                _dependencies.WriteLine("Egalite!");
            }
            else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Ciseaux)
            {
                _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                _dependencies.WriteLine("Egalite!");
            }
            else
            {
                return TurnNextAction.Exit;
            }

            return TurnNextAction.Continue;
        }
    }
}