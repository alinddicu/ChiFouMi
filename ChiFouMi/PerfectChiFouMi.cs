namespace ChiFouMi
{
    using System.Collections.Generic;
    using System.Linq;

    public class PerfectChiFouMi : IChiFouMi
    {
        private const string ExitPhrase = "exit";
        private const string TextIntro = "Veuillez choisir un signe:";

        private int _intUs;
        private int _intUv;

        private readonly Stack<string> t = new Stack<string>();

        private bool _roxorMode;

        private readonly IExternalDependecies _dependencies;

        public PerfectChiFouMi(IExternalDependecies dependencies)
        {
            _dependencies = dependencies;
            t.Push("Ciseaux");
            t.Push("Feuille");
            t.Push("Pierre");
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

            _dependencies.WriteLine("Bienvenue dans mon chifumi," +
                              " ici c'est un appli de ROXXXXXXXXXXXXXXXOOR!");
            _dependencies.WriteLine("Taper sur la touche entrée pour commencer une partie," +
                              " ou 'exit' pour quitter.");
            while (!Initialize())
            {
                _dependencies.WriteLine(TextIntro);
                for (var idChoix = 0; idChoix < t.Count; idChoix++)
                {
                    Display(idChoix);
                }
                _intUs = (char)(_dependencies.ReadLine()[0] - 48);

                _intUv = (char)(_dependencies.GetNextRandomBetween1And3().ToString()[0] - 48);

                if (_roxorMode && _intUv == 1)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Pierre");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 1)
                {
                    _dependencies.WriteLine("Pierre contre Pierre!");
                    _dependencies.WriteLine("Egalite!");
                }
                else if (_roxorMode && _intUv == 2)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Feuille");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs - 1 == _intUv % 2)
                {
                    _dependencies.WriteLine("Pierre contre Feuille!");
                    _dependencies.WriteLine("Perdu!");
                }
                else if (_roxorMode && _intUv == 3)
                {
                    _dependencies.WriteLine("Tu es un roxor contre Ciseaux");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 1 && _intUv == 3)
                {
                    _dependencies.WriteLine("Pierre contre Ciseaux!");
                    _dependencies.WriteLine("Gagne!");
                }
                else if (_intUs == 2 && _intUv == 2)
                {
                    _dependencies.WriteLine("Feuille contre Feuille!");
                    _dependencies.WriteLine("Egalite!");
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

        private void Display(int idChoix)
        {
            _dependencies.WriteLine(++idChoix + "- " + t.ToArray()[idChoix - 1]);
        }
    }
}
