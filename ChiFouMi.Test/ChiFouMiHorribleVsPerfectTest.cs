namespace ChiFouMi.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class ChiFouMiHorribleVsPerfectTest
    {
        private readonly InputLinesGenerator _inputLinesGenerator = new InputLinesGenerator();
        private HorribleChiFouMi _horribleChiFouMi;
        private PerfectChiFouMi _perfectChiFouMi;

        [TestMethod]
        public void NoRoxxorTest()
        {
            var inputLines = _inputLinesGenerator.Generate(1500).ToArray();
            var horribleDependencies = new TestExternalDependencies(inputLines, DateTime.Now.Millisecond);
            var perfectDependencies = new TestExternalDependencies(inputLines, DateTime.Now.Millisecond);
            _horribleChiFouMi = new HorribleChiFouMi(horribleDependencies);
            _perfectChiFouMi = new PerfectChiFouMi(perfectDependencies);

            var noRoxxorMode = new[] { "noRoxxorMode" };
            _horribleChiFouMi.Play(noRoxxorMode);
            _perfectChiFouMi.Play(noRoxxorMode);

            Check.That(horribleDependencies.GetWrittenLines()).ContainsExactly(perfectDependencies.GetWrittenLines());
        }

        [TestMethod]
        [Ignore]
        public void RoxxorTest()
        {
            var inputLines = _inputLinesGenerator.Generate(4).ToArray();
            var horribleDependencies = new TestExternalDependencies(inputLines, DateTime.Now.Millisecond);
            var perfectDependencies = new TestExternalDependencies(inputLines, DateTime.Now.Millisecond);
            _horribleChiFouMi = new HorribleChiFouMi(horribleDependencies);
            _perfectChiFouMi = new PerfectChiFouMi(perfectDependencies);

            var roxor = new[] { "roxor" };
            _horribleChiFouMi.Play(roxor);
            _perfectChiFouMi.Play(roxor);

            Check.That(horribleDependencies.GetWrittenLines()).ContainsExactly(perfectDependencies.GetWrittenLines());
        }
    }
}
