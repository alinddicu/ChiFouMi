﻿namespace ChiFouMi.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Horrible;
    using ChiFouMi.Perfect;
    using TestHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class ChiFouMiHorribleVsPerfectTest
    {
        private const int UpperLimitRandomGenerator = 4;

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
                var horribleDependencies = new TestExternalDependencies(UpperLimitRandomGenerator, inputLines, seed);
                var perfectDependencies = new TestExternalDependencies(UpperLimitRandomGenerator, inputLines, seed);
                _horribleChiFouMi = new HorribleChiFouMi(horribleDependencies);
                _perfectChiFouMi = new ChiFouMiFactory(UpperLimitRandomGenerator, perfectDependencies, ChiFuMiMode.Base).Create();

                var roxor = new[] { mode };
                _horribleChiFouMi.Play(roxor);
                _perfectChiFouMi.Play(roxor);

                Check.That(horribleDependencies.GetWrittenLines()).ContainsExactly(perfectDependencies.GetWrittenLines());
            }
        }
    }
}