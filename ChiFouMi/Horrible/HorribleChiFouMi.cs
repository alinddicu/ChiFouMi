namespace ChiFouMi.Horrible
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HorribleChiFouMi : IChiFouMi
    {
        public static int _a0;
        private static char _intUs;
        private static Random r;
        public static int _intUv;
        public static int cnt = 0;
        private static Stack<string> t = new Stack<string>();
        private static bool rmdi = false;
        public static string str_end = "exit";

        private readonly ISystemDependencies _systemDependencies;

        public HorribleChiFouMi(ISystemDependencies systemDependencies)
        {
            _systemDependencies = systemDependencies;
        }

        public void Play(string[] userInputArguments)
        {
            _a0 = 0;
            #region
            if (userInputArguments.Any())
            {
                if (userInputArguments[_a0].Equals("roxor")) roxorMoMode = true;
            }
            #endregion

            #region intro
            _str = "exit";
            _strTextIntro = "Veuillez choisir un signe:";
            _systemDependencies.WriteLine("Bienvenue dans mon chifumi," +
                              " ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            _systemDependencies.WriteLine("Taper sur la touche entrée pour commencer une partie," +
                              " ou 'exit' pour quitter.");
            #endregion

            #region jeu
            while (!
                Initialize())
            {
                #region intro

                _systemDependencies.WriteLine(_strTextIntro);
                for (int i = 0, cnt = 0; i < t.Count; i++)
                {
                    Display(i);
                }
                _intUs = (char)(_systemDependencies.ReadLine()[0] - 48);
                #endregion

                #region
                // TODO Code à garder ? Evolution futur ?
                //var rand = new Random(DateTime.Now.Millisecond);
                //var int_uv = rand.Next(1, 6);

                //if (roxorMoMode != false && int_uv == 6)
                //{
                //    _systemDependencies.WriteLine("Tu es un roxor contre Spock");
                //    _systemDependencies.WriteLine("Gagne!");
                //}
                //else if (int_us == 1 && int_uv == 1)
                //{
                //    _systemDependencies.WriteLine("Pierre contre Pierre!");
                //    _systemDependencies.WriteLine("Egalite!");
                //}
                //else if (roxorMoMode != false && int_uv == 2)
                //{
                //    _systemDependencies.WriteLine("Tu es un roxor contre Feuille");
                //    _systemDependencies.WriteLine("Gagne!");
                //}
                //else if (int_us == 1 && int_uv == 2)
                //{
                //    _systemDependencies.WriteLine("Pierre contre Feuille!");
                //    _systemDependencies.WriteLine("Perdu!");
                //}
                #endregion

                #region business logic
                r = new Random(DateTime.Now.Millisecond);
                _intUv = (char)(_systemDependencies.GetRandomInt(4).ToString()[0] - 48);

                // TODO : A refactorer
                // si ciseau et roxor
                if (roxorMoMode != rmdi && _intUv == 1)
                {
                    _systemDependencies.WriteLine("Tu es un roxor contre Pierre");
                    _systemDependencies.WriteLine("Gagne!");
                }
                // si ciseau et ciseau
                else if (_intUs == 1 && _intUv == 1)
                {
                    //_systemDependencies.WriteLine("ciseau contre ciseau!");
                    //_systemDependencies.WriteLine("Egalite!");
                    _systemDependencies.WriteLine("Pierre contre Pierre!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != rmdi && _intUv == 2)
                {
                    _systemDependencies.WriteLine("Tu es un roxor contre Feuille");
                    _systemDependencies.WriteLine("Gagne!");
                }
                // TODO A simplifier
                else if (_intUs - 1 == _intUv % 2)
                {
                    _systemDependencies.WriteLine("Pierre contre Feuille!");
                    _systemDependencies.WriteLine("Perdu!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != rmdi && _intUv == 3)
                {
                    _systemDependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _systemDependencies.WriteLine("Gagne!");
                }

                    // TODO: better syntaxe, it's more compact. Right ? If ok vote on https://framadate.org/dsfsdfgnys7y7wxkiujpfi1z/admin
                // Link DEAD!
                // https://framadate.org/dsfsdfgnysfdf7wxkiujpfi1z/admin
                else if (_intUs == 1 && _intUv == 3)
                {
                    _systemDependencies.WriteLine("Pierre contre Ciseaux!"); _systemDependencies.WriteLine("Gagne!");
                }
                else if (roxorMoMode != rmdi
                            && _intUv
                            == 2)
                {
                    _systemDependencies.WriteLine("Tu es un roxor contre Feuille");
                    _systemDependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 1)
                {
                    _systemDependencies.WriteLine("Feuille contre Pierre!");
                    _systemDependencies.WriteLine("Gagne!");
                }
                // BUG 758996
                else if (_intUs == 2 && _intUv == 2)
                {
                    _systemDependencies.WriteLine("Feuille contre Feuille!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                // Evolution, 14522
                else if (_intUs == 2 && _intUv == 3)
                {
                    _systemDependencies.WriteLine("Feuille contre Ciseaux!");
                    _systemDependencies.WriteLine("Perdu!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != false && _intUv == 3)
                {
                    _systemDependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _systemDependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 3 && _intUv == 1)
                // BUG 985632
                {
                    _systemDependencies.WriteLine("Ciseaux contre Pierre!");
                    _systemDependencies.WriteLine("Perdu!");
                }
                // BUG 12563
                else if (_intUs == 3 && _intUv % 2 == 0)
                {
                    _systemDependencies.WriteLine("Ciseaux contre Feuille!");
                    _systemDependencies.WriteLine("Gagne!");
                }
                //if (roxorMoMode != false && int_uv == 6)
                //{
                //    _systemDependencies.WriteLine("Tu es un roxor contre Spock");
                //    _systemDependencies.WriteLine("Gagne!");
                //}
                else if (_intUs == _intUv)
                {
                    _systemDependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 4)
                {
                    // Evolution, 956322
                    _systemDependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 5)
                {
                    _systemDependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 4 && _intUv == 4)
                {
                    _systemDependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _systemDependencies.WriteLine("Egalite!");
                }
                else if ("exit".Equals(_str))
                {
                    break;
                }
                else if (true)
                {
                    _systemDependencies.WriteLine("Je sais pas");
                }
                else
                {
                    _systemDependencies.WriteLine("Perdu");
                }
            }
                #endregion
            #endregion
        }

        private static bool roxorMoMode;
        private static string _str;
        private static string _strTextIntro;

        private bool Initialize()
        {
            t = new Stack<string>();
            cnt = _intUv;
            t.Push("Ciseaux");
            t.Push("Feuille");
            t.Push("Pierre");
            return _systemDependencies.ReadLine().StartsWith(str_end);
        }

        private void Display(int idChoix)
        {
            _systemDependencies.WriteLine(++idChoix + "- " + t.ToArray()[idChoix - 1]);
        }
    }
}