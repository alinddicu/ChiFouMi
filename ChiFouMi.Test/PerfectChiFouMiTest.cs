namespace ChiFouMi.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class PerfectChiFouMiTest
    {
        private PerfectChiFouMi _perfectChiFouMi;

        [TestMethod]
        public void GivenTestDependencyInjectionInPerfectChiFouMiWhenPlayThenLinesAreGeneratedAndExit()
        {
            var inputLines = new List<string>
            {
                Environment.NewLine,
                "1",
                Environment.NewLine,
                "2",
                Environment.NewLine,
                "exit"
            };
            var dependencies = new TestExternalDependencies(inputLines, 1);
            _perfectChiFouMi = new PerfectChiFouMi(dependencies);

            _perfectChiFouMi.Play(new[] { Environment.NewLine });

            var writtenLines = dependencies.GetWrittenLines();

            Check.That(writtenLines).Not.IsEmpty();
        }
    }
}
