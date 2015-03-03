namespace ChiFouMi.Test.TestHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class TestExternalDependenciesTest
    {
        private TestExternalDependencies _testExternalDependecies;

        [TestMethod]
        public void GivenInputStringsWhenReadLineThenReturnCorrectStrings()
        {
            var list = new List<string> { "1", "2" };
            //list.Reverse();
            _testExternalDependecies = new TestExternalDependencies(list, 1);

            Check.That(_testExternalDependecies.ReadLine()).IsEqualTo("1");
            Check.That(_testExternalDependecies.ReadLine()).IsEqualTo("2");
        }

        [TestMethod]
        public void GivenLineToWriteWhenGetWrittenLinesThenWrittenLinesAreCorrect()
        {
            _testExternalDependecies = new TestExternalDependencies(new List<string>(), 1);

            _testExternalDependecies.WriteLine("nouvelle ligne");

            var writtenLines = _testExternalDependecies.GetWrittenLines().ToArray();
            Check.That(writtenLines).HasSize(2);
            Check.That(writtenLines[0]).IsEqualTo("nouvelle ligne");
            Check.That(writtenLines[1]).IsEqualTo(Environment.NewLine);
        }

        [TestMethod]
        public void GivenSameSeedOnRandomWhenNextThenResultsAreTheSame()
        {
            var commonSeed = DateTime.Now.Millisecond;
            var random1 = new Random(commonSeed);
            var random2 = new Random(commonSeed);

            for (var i = 0; i < 1000; i++)
            {
                Check.That(random1.Next(1, 100000)).IsEqualTo(random2.Next(1, 100000));
            }
        }

        [TestMethod]
        public void WhenGetNextRandomBetween1And3ThenResultsAreBetween1And3()
        {
            for (var i = 0; i < 1000; i++)
            {
                _testExternalDependecies = new TestExternalDependencies(new List<string>(), DateTime.Now.Millisecond);
                var randomGenerated = _testExternalDependecies.GetNextRandomBetween1And3();
                Check.That(randomGenerated).IsGreaterThan(0).And.IsLessThan(4);
            }
        }
    }
}