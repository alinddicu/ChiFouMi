namespace ChiFouMi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PerfectChiFouMi : IChiFouMi
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

        public PerfectChiFouMi(IExternalDependecies dependencies)
        {
            _dependencies = dependencies;
        }

        public void Play(string[] args)
        {
            _a0 = 0;
            if (args.Any())
            {
                if (args[_a0].Equals("roxor")) roxorMoMode = true;
            }

            _str = "exit";
            _strTextIntro = "Veuillez choisir un signe:";
            _dependencies.WriteLine("Bienvenue dans mon chifumi," +
                              " ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            _dependencies.WriteLine("Taper sur la touche entrée pour commencer une partie," +
                              " ou 'exit' pour quitter.");
            while (!Initialize())
            {
                _dependencies.WriteLine(_strTextIntro);
                for (var idChoix = 0; idChoix < t.Count; idChoix++)
                {
                    Display(idChoix);
                }
                _intUs = (char)(_dependencies.ReadLine()[0] - 48);

                r = new Random(DateTime.Now.Millisecond);
                _intUv = (char)(_dependencies.GetNextRandomBetween1And3().ToString()[0] - 48);

                if (roxorMoMode != rmdi && _intUv == 1)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 1)
                {
                    _dependencies.WriteLine("Pierre contre Pierre!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (roxorMoMode != rmdi && _intUv == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs - 1 == _intUv % 2)
                {
                    _dependencies.WriteLine("Pierre contre Feuille!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (roxorMoMode != rmdi && _intUv == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 3)
                {
                    _dependencies.WriteLine("Pierre contre Ciseaux!"); _dependencies.WriteLine("Gagne!");
                }
                else if (roxorMoMode != rmdi && _intUv == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 1)
                {
                    _dependencies.WriteLine("Feuille contre Pierre!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 2)
                {
                    _dependencies.WriteLine("Feuille contre Feuille!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 2 && _intUv == 3)
                {
                    _dependencies.WriteLine("Feuille contre Ciseaux!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (roxorMoMode != false && _intUv == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 3 && _intUv == 1)
                {
                    _dependencies.WriteLine("Ciseaux contre Pierre!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_intUs == 3 && _intUv % 2 == 0)
                {
                    _dependencies.WriteLine("Ciseaux contre Feuille!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == _intUv)
                {
                    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_intUs == 3 && _intUv == 4)
                {
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
