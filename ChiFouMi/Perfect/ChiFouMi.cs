namespace ChiFouMi.Perfect
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class ChiFouMi : IChiFouMi
    {
        private const string ExitPhrase = "exit";
        private const string ChoisirCoupText = "Veuillez choisir un signe:";
        private const string BienvenueText = "Bienvenue dans mon chifumi, ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!";
        private const string EntreeOuExitText = "Taper sur la touche entrée pour commencer une partie, ou 'exit' pour quitter.";

        private CoupType _playerChoice;
        private CoupType _computerChoice;

        private bool _roxorMode;

        private readonly IExternalDependencies _dependencies;
        private readonly DisplayChoixCoupGenerator _displayChoixCoup;
        private readonly InputToCoupTypeConverter _inputToCoupTypeConverter;

        public ChiFouMi(
            IExternalDependencies dependencies,
            DisplayChoixCoupGenerator displayChoixCoup,
            InputToCoupTypeConverter inputToCoupTypeConverter)
        {
            _dependencies = dependencies;
            _displayChoixCoup = displayChoixCoup;
            _inputToCoupTypeConverter = inputToCoupTypeConverter;
        }

        public void Play(string[] args)
        {
            if (args.Any())
            {
                if (args[0].Equals("roxor"))
                {
                    _roxorMode = true;
                }
            }

            _dependencies.WriteLine(BienvenueText);
            _dependencies.WriteLine(EntreeOuExitText);
            while (!ShouldExit())
            {
                _dependencies.WriteLine(ChoisirCoupText);
                DisplayChoixCoup();

                _playerChoice = _inputToCoupTypeConverter.Convert(_dependencies.ReadLine());
                _computerChoice = _inputToCoupTypeConverter.Convert(_dependencies.GetNextRandomBetween1And3().ToString());

                if (_roxorMode && _computerChoice == CoupType.Pierre)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_roxorMode && _computerChoice == CoupType.Feuille)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_roxorMode && _computerChoice == CoupType.Ciseaux)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if ((int)_playerChoice - 1 == (int)_computerChoice % 2)
                {
                    _dependencies.WriteLine("Pierre contre Feuille!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_playerChoice == CoupType.Pierre && _computerChoice == CoupType.Ciseaux)
                {
                    _dependencies.WriteLine("Pierre contre Ciseaux!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_playerChoice == CoupType.Ciseaux && _computerChoice == CoupType.Pierre)
                {
                    _dependencies.WriteLine("Ciseaux contre Pierre!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_playerChoice == CoupType.Ciseaux && _computerChoice == CoupType.Feuille)
                {
                    _dependencies.WriteLine("Ciseaux contre Feuille!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_playerChoice == CoupType.Pierre && _computerChoice == CoupType.Pierre)
                {
                    _dependencies.WriteLine("Pierre contre Pierre!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_playerChoice == CoupType.Feuille && _computerChoice == CoupType.Feuille)
                {
                    _dependencies.WriteLine("Feuille contre Feuille!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_playerChoice == CoupType.Ciseaux && _computerChoice == CoupType.Ciseaux)
                {
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else
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
    }
}