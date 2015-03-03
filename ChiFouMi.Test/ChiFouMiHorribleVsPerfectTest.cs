namespace ChiFouMi.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using ChiFouMi.Horrible;
    using ChiFouMi.Perfect;
    using ChiFouMi.Test.TestHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class ChiFouMiHorribleVsPerfectTest
    {
        private readonly InputLinesGenerator _inputLinesGenerator = new InputLinesGenerator();
        private HorribleChiFouMi _horribleChiFouMi;
        private ChiFouMi _perfectChiFouMi;

        [TestMethod]
        public void NoRoxxorTest()
        {
            var inputLines = _inputLinesGenerator.Generate(20).ToArray();

            CheckResultWithMode(inputLines, "whatever");
        }

        [TestMethod]
        public void RoxxorTest()
        {
            var inputLines = _inputLinesGenerator.Generate(20).ToList();
            inputLines.RemoveAt(0);
            CheckResultWithMode(inputLines, "roxor");
        }

        private void CheckResultWithMode(IList<string> inputLines, string mode)
        {
            for (var seed = 0; seed < 100; seed++)
            {
                var horribleDependencies = new TestExternalDependencies(inputLines, seed);
                var perfectDependencies = new TestExternalDependencies(inputLines, seed);
                _horribleChiFouMi = new HorribleChiFouMi(horribleDependencies);
                _perfectChiFouMi = new ChiFouMi(perfectDependencies, new DisplayChoixCoupGenerator(), new InputToCoupTypeConverter());

                var roxor = new[] { mode };
                _horribleChiFouMi.Play(roxor);
                _perfectChiFouMi.Play(roxor);

                Check.That(horribleDependencies.GetWrittenLines()).ContainsExactly(perfectDependencies.GetWrittenLines());
            }
        }
    }
}