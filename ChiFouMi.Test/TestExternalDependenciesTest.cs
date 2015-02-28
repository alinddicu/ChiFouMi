namespace ChiFouMi.Test
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
            var list = new List<string>{"1", "2"};
            list.Reverse();
            _testExternalDependecies = new TestExternalDependencies(list);

            Check.That(_testExternalDependecies.ReadLine()).IsEqualTo("1");
            Check.That(_testExternalDependecies.ReadLine()).IsEqualTo("2");
        }

        [TestMethod]
        public void GivenLineToWriteWhenGetWrittenLinesThenWrittenLinesAreCorrect()
        {
            _testExternalDependecies = new TestExternalDependencies(new List<string>());

            _testExternalDependecies.WriteLine("nouvelle ligne");

            var writtenLines = _testExternalDependecies.GetWrittenLines().ToArray();
            Check.That(writtenLines).HasSize(2);
            Check.That(writtenLines[0]).IsEqualTo("nouvelle ligne");
            Check.That(writtenLines[1]).IsEqualTo(Environment.NewLine);
        }
    }
}
