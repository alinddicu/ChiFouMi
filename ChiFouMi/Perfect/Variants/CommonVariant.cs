namespace ChiFouMi.Perfect.Variants
{
    public class CommonVariant : IChiFouMiVariant
    {
        private readonly ISystemDependencies _systemDependencies;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;

        public CommonVariant(
            ISystemDependencies systemDependencies,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _systemDependencies = systemDependencies;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public bool CanPlay(VariantType variantType)
        {
            return variantType == VariantType.Common;
        }

        public TurnResult PlayTurn(CoupType playerChoice)
        {
            var computerChoice = _inputToCoupTypeConverter.Convert(_systemDependencies.GetNextRandomBetween1And3());

            if ((int)playerChoice - 1 == (int)computerChoice % 2)
            {
                _systemDependencies.WriteLine("Pierre contre Feuille!");
                _systemDependencies.WriteLine("Perdu!");
            }
            else if (playerChoice == CoupType.Pierre && computerChoice == CoupType.Ciseaux)
            {
                _systemDependencies.WriteLine("Pierre contre Ciseaux!");
                _systemDependencies.WriteLine("Gagne!");
            }
            else if (playerChoice == CoupType.Ciseaux && computerChoice == CoupType.Pierre)
            {
                _systemDependencies.WriteLine("Ciseaux contre Pierre!");
                _systemDependencies.WriteLine("Perdu!");
            }
            else if (playerChoice == CoupType.Ciseaux && computerChoice == CoupType.Feuille)
            {
                _systemDependencies.WriteLine("Ciseaux contre Feuille!");
                _systemDependencies.WriteLine("Gagne!");
            }
            else if (playerChoice == CoupType.Pierre && computerChoice == CoupType.Pierre)
            {
                _systemDependencies.WriteLine("Pierre contre Pierre!");
                _systemDependencies.WriteLine("Egalite!");
            }
            else if (playerChoice == CoupType.Feuille && computerChoice == CoupType.Feuille)
            {
                _systemDependencies.WriteLine("Feuille contre Feuille!");
                _systemDependencies.WriteLine("Egalite!");
            }
            else if (playerChoice == CoupType.Ciseaux && computerChoice == CoupType.Ciseaux)
            {
                _systemDependencies.WriteLine("Ciseaux contre Ciseaux!");
                _systemDependencies.WriteLine("Egalite!");
            }
            else
            {
                return TurnResult.Exit;
            }

            return TurnResult.Continue;
        }
    }
}
