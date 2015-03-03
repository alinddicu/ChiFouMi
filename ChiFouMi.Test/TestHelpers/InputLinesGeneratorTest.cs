namespace ChiFouMi.Test.TestHelpers
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class InputLinesGeneratorTest
    {
        private InputLinesGenerator _generator;

        [TestMethod]
        public void CheckThatInputLinesAreGeneratedCorrectly()
        {
            _generator = new InputLinesGenerator();
            const int linesNumber = 10;

            var lines = _generator.Generate(linesNumber).ToArray();

            Check.That(EnumerableExtensions.Count(lines)).IsEqualTo(2 + linesNumber * 2);
            Check.That(lines.Last()).IsEqualTo("exit");
            Check.That(lines[lines.Count() - 2]).IsEqualTo(Environment.NewLine);
            for (var i = 0; i < linesNumber * 2; i++)
            {
                var lineValue = lines[i];
                if (i % 2 == 1)
                {
                    Check.That(Convert.ToInt32(lineValue)).IsGreaterThan(0).And.IsLessThan(4);
                }
                else
                {
                    Check.That(lineValue).IsEqualTo(Environment.NewLine);
                }
            }
        }
    }
}