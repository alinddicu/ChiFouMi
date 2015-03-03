namespace ChiFouMi.Test.Perfect
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ChiFouMi.Perfect;
    using ChiFouMi.Test.TestHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class ChiFouMiTest
    {
        private ChiFouMi _perfectChiFouMi;

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
            _perfectChiFouMi = new ChiFouMiFactory().Create(dependencies);

            _perfectChiFouMi.Play(Enumerable.Empty<string>().ToArray());

            var writtenLines = dependencies.GetWrittenLines();

            Check.That(writtenLines).Not.IsEmpty();
        }
    }
}