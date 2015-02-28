namespace ChiFouMi
{
    using System;
    using System.Collections.Generic;

    public class TestExternalDependencies : IExternalDependecies
    {
        private readonly List<string> _linesBuffer = new List<string>();
        private readonly Stack<string> _inputLines;
        private readonly int _seedForRandomGenerator;

        public TestExternalDependencies(
            IEnumerable<string> inputLines,
            int seedForRandomGenerator)
        {
            _inputLines = new Stack<string>(inputLines);
            _seedForRandomGenerator = seedForRandomGenerator;
        }

        public void WriteLine(string line)
        {
            _linesBuffer.Add(line);
            _linesBuffer.Add(Environment.NewLine);
        }

        public IEnumerable<string> GetWrittenLines()
        {
            return _linesBuffer;
        }

        public string ReadLine()
        {
            return _inputLines.Pop();
        }

        public int GetNextRandomBetween1And3()
        {
            return new Random(_seedForRandomGenerator).Next(1, 4);
        }
    }
}
