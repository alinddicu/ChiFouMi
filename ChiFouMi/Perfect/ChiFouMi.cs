namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using System.Linq;
    using Variants;
    using Variants.Common;

    public class ChiFouMi : IChiFouMi
    {
        private const string ExitPhrase = "exit";
        private const string ChoisirCoupText = "Veuillez choisir un signe:";
        private const string BienvenueText = "Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!";
        private const string EntreeOuExitText = "Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.";

        private readonly ISystemDependencies _systemDependencies;
        private readonly DisplayChoixCoupGenerator _displayChoixCoup;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;
        private readonly VariantTypeConverter _variantTypeConverter;
        private readonly IChiFouMiVariant[] _allVariants;

        public ChiFouMi(
            ISystemDependencies systemDependencies,
            DisplayChoixCoupGenerator displayChoixCoup,
            InputToCoupTypeConverter inputToCoupTypeConverter,
            VariantTypeConverter variantTypeConverter,
            ChiFouMiVariantsFactory chiFouMiVariantsFactory)
        {
            _systemDependencies = systemDependencies;
            _displayChoixCoup = displayChoixCoup;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
            _variantTypeConverter = variantTypeConverter;
            _allVariants = chiFouMiVariantsFactory.Create().ToArray();
        }

        public void Play(string[] userInputArguments)
        {
            SetMessageAccueil();

            var chosenVariant = GetChosenVariant(userInputArguments);
            while (!ShouldExit())
            {
                _systemDependencies.WriteLine(ChoisirCoupText);
                DisplayChoixCoup();

                var playerChoice = _inputToCoupTypeConverter.Convert(_systemDependencies.ReadLine());
                if (chosenVariant.PlayTurn(playerChoice) == TurnNextAction.Exit)
                {
                    break;
                }
            }
        }

        private IChiFouMiVariant GetChosenVariant(IList<string> userInputArguments)
        {
            var variantType = ConvertToVariantType(userInputArguments);
            return _allVariants.First(v => v.CanPlay(variantType));
        }

        private void SetMessageAccueil()
        {
            _systemDependencies.WriteLine(BienvenueText);
            _systemDependencies.WriteLine(EntreeOuExitText);
        }

        private bool ShouldExit()
        {
            return _systemDependencies.ReadLine().StartsWith(ExitPhrase);
        }

        private void DisplayChoixCoup()
        {
            foreach (var choixCoup in _displayChoixCoup.Generate(VariantMode.Simple))
            {
                _systemDependencies.WriteLine(choixCoup);
            }
        }

        private VariantType ConvertToVariantType(IList<string> userInputArguments)
        {
            return !userInputArguments.Any() ? VariantType.Common : _variantTypeConverter.Convert(userInputArguments[0]);
        }
    }
}