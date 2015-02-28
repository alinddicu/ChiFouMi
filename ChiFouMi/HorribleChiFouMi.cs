namespace ChiFouMi
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

        private readonly IExternalDependecies _dependencies;

        public HorribleChiFouMi(IExternalDependecies dependencies)
        {
            _dependencies = dependencies;
        }

        public void Play(string[] args)
        {
            _a0 = 0;
            #region
            if (args.Any())
            {
                if (args[_a0].Equals("roxor")) roxorMoMode = true;
            }
            #endregion










            #region intro
            _str = "exit";
            _strTextIntro = "Veuillez choisir un signe:";
            _dependencies.WriteLine("Bienvenue dans mon chifumi," +
                              " ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            _dependencies.WriteLine("Taper sur la touche entrée pour commencer une partie," +
                              " ou 'exit' pour quitter.");
            #endregion

            #region jeu
            while (!
                Initialize())
            {
                #region intro

                _dependencies.WriteLine(_strTextIntro);
                for (int i = 0, cnt = 0; i < t.Count; i++)
                {
                    Display(i);
                }
                _intUs = (char)(_dependencies.ReadLine()[0] - 48);
                #endregion

                #region
                // TODO Code à garder ? Evolution futur ?
                //var rand = new Random(DateTime.Now.Millisecond);
                //var int_uv = rand.Next(1, 6);

                //if (roxorMoMode != false && int_uv == 6)
                //{
                //    _dependencies.WriteLine("Tu es un roxor contre Spock");
                //    _dependencies.WriteLine("Gagne!");
                //}
                //else if (int_us == 1 && int_uv == 1)
                //{
                //    _dependencies.WriteLine("Pierre contre Pierre!");
                //    _dependencies.WriteLine("Egalite!");
                //}
                //else if (roxorMoMode != false && int_uv == 2)
                //{
                //    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                //    _dependencies.WriteLine("Gagne!");
                //}
                //else if (int_us == 1 && int_uv == 2)
                //{
                //    _dependencies.WriteLine("Pierre contre Feuille!");
                //    _dependencies.WriteLine("Perdu!");
                //}
                #endregion

                #region business logic
                r = new Random(DateTime.Now.Millisecond);
                _intUv = (char)(_dependencies.GetNextRandomBetween1And3().ToString()[0] - 48);

                // TODO : A refactorer
                // si ciseau et roxor
                if (roxorMoMode != rmdi && _intUv == 1)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                }
                // si ciseau et ciseau
                else if (_intUs == 1 && _intUv == 1)
                {
                    //_dependencies.WriteLine("ciseau contre ciseau!");
                    //_dependencies.WriteLine("Egalite!");
                    _dependencies.WriteLine("Pierre contre Pierre!");
                    _dependencies.WriteLine("Egalite!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != rmdi && _intUv == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                // TODO A simplifier
                else if (_intUs - 1 == _intUv % 2)
                {
                    _dependencies.WriteLine("Pierre contre Feuille!");
                    _dependencies.WriteLine("Perdu!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != rmdi && _intUv == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }









                    // TODO: better syntaxe, it's more compact. Right ? If ok vote on https://framadate.org/dsfsdfgnys7y7wxkiujpfi1z/admin
                // Link DEAD!
                // https://framadate.org/dsfsdfgnysfdf7wxkiujpfi1z/admin
                else if (_intUs == 1 && _intUv == 3)
                {
                    _dependencies.WriteLine("Pierre contre Ciseaux!"); _dependencies.WriteLine("Gagne!");
                }
                else if (roxorMoMode != rmdi
                            && _intUv
                            == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 1)
                {
                    _dependencies.WriteLine("Feuille contre Pierre!");
                    _dependencies.WriteLine("Gagne!");
                }
                // BUG 758996
                else if (_intUs == 2 && _intUv == 2)
                {
                    _dependencies.WriteLine("Feuille contre Feuille!");
                    _dependencies.WriteLine("Egalite!");
                }
                // Evolution, 14522

                else if (_intUs == 2 && _intUv == 3)
                {
                    _dependencies.WriteLine("Feuille contre Ciseaux!");
                    _dependencies.WriteLine("Perdu!");
                }
                // si ciseau et roxor
                else if (roxorMoMode != false && _intUv == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 3 && _intUv == 1)
                // BUG 985632
                {
                    _dependencies.WriteLine("Ciseaux contre Pierre!");
                    _dependencies.WriteLine("Perdu!");
                }
                // BUG 12563
                else if (_intUs == 3 && _intUv % 2 == 0)
                {
                    _dependencies.WriteLine("Ciseaux contre Feuille!");
                    _dependencies.WriteLine("Gagne!");
                }
                //if (roxorMoMode != false && int_uv == 6)
                //{
                //    _dependencies.WriteLine("Tu es un roxor contre Spock");
                //    _dependencies.WriteLine("Gagne!");
                //}

                else if (_intUs == _intUv)
                {
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 4)
                {
                    // Evolution, 956322
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 5)
                {
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 4 && _intUv == 4)
                {
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if ("exit".Equals(_str))
                {
                    break;
                }

                else if (true)
                {
                    _dependencies.WriteLine("Je sais pas");
                }

                else
                {
                    _dependencies.WriteLine("Perdu");
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
            return _dependencies.ReadLine().StartsWith(str_end);
        }

        private void Display(int idChoix)
        {
            _dependencies.WriteLine(++idChoix + "- " + t.ToArray()[idChoix - 1]);
        }
    }
}
