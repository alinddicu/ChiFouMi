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

        private int _playerChoice;
        private int _computerChoice;

        private bool _roxorMode;

        private readonly IExternalDependencies _dependencies;
        private readonly DisplayChoixCoup _displayChoixCoup;

        public ChiFouMi(IExternalDependencies dependencies, DisplayChoixCoup displayChoixCoup)
        {
            _dependencies = dependencies;
            _displayChoixCoup = displayChoixCoup;
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
            while (!Initialize())
            {
                _dependencies.WriteLine(ChoisirCoupText);
                DisplayChoixCoup();

                _playerChoice = (char)(_dependencies.ReadLine()[0] - 48);

                _computerChoice = (char)(_dependencies.GetNextRandomBetween1And3().ToString()[0] - 48);

                if (_roxorMode && _computerChoice == 1)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_roxorMode && _computerChoice == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_roxorMode && _computerChoice == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_playerChoice - 1 == _computerChoice % 2)
                {
                    _dependencies.WriteLine("Pierre contre Feuille!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_playerChoice == 1 && _computerChoice == 3)
                {
                    _dependencies.WriteLine("Pierre contre Ciseaux!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_playerChoice == 3 && _computerChoice == 1)
                {
                    _dependencies.WriteLine("Ciseaux contre Pierre!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_playerChoice == 3 && _computerChoice == 2)
                {
                    _dependencies.WriteLine("Ciseaux contre Feuille!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_playerChoice == 1 && _computerChoice == 1)
                {
                    _dependencies.WriteLine("Pierre contre Pierre!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_playerChoice == 2 && _computerChoice == 2)
                {
                    _dependencies.WriteLine("Feuille contre Feuille!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_playerChoice == 3 && _computerChoice == 3)
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

        private bool Initialize()
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