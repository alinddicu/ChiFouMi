namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using System.Linq;
    using Variants;

    public class ChiFouMi : IChiFouMi
    {
        private const string ExitPhrase = "exit";
        private const string ChoisirCoupText = "Veuillez choisir un signe:";
        private const string BienvenueText = "Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!";
        private const string EntreeOuExitText = "Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.";
        
        private readonly IExternalDependencies _dependencies;
        private readonly DisplayChoixCoupGenerator _displayChoixCoup;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;
        private readonly VariantTypeConverter _variantTypeConverter;
        private readonly IChiFouMiVariant[] _variants;

        public ChiFouMi(
            IExternalDependencies dependencies,
            DisplayChoixCoupGenerator displayChoixCoup,
            InputToCoupTypeConverter inputToCoupTypeConverter,
            VariantTypeConverter variantTypeConverter,
            ChiFouMiVariantsFactory chiFouMiVariantsFactory)
        {
            _dependencies = dependencies;
            _displayChoixCoup = displayChoixCoup;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
            _variantTypeConverter = variantTypeConverter;
            _variants = chiFouMiVariantsFactory.Create(_dependencies).ToArray();
        }

        public void Play(string[] userInputArguments)
        {
            var variantType = ConvertToVariantType(userInputArguments);
            var variant = _variants.First(v => v.CanPlay(variantType));

            _dependencies.WriteLine(BienvenueText);
            _dependencies.WriteLine(EntreeOuExitText);
            while (!ShouldExit())
            {
                _dependencies.WriteLine(ChoisirCoupText);
                DisplayChoixCoup();

                var playerChoice = _inputToCoupTypeConverter.Convert(_dependencies.ReadLine());
                var turnResult = variant.PlayTurn(playerChoice);

                if (turnResult == TurnResult.Exit)
                {
                    break;
                }
            }
        }

        private bool ShouldExit()
        {
            return _dependencies.ReadLine().StartsWith(ExitPhrase);
        }

        private void DisplayChoixCoup()
        {
            foreach (var choixCoup in _displayChoixCoup.Get())
            {
                _dependencies.WriteLine(choixCoup);
            }
        }

        private VariantType ConvertToVariantType(IList<string> userInputArguments)
        {
            if (!userInputArguments.Any())
            {
                return VariantType.Common;
            }

            return _variantTypeConverter.Convert(userInputArguments[0]);
        }
    }
}