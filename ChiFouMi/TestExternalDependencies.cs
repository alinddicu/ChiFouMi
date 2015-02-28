namespace ChiFouMi
{
    using System;
    using System.Collections.Generic;

    public class TestExternalDependencies : IExternalDependecies
    {
        private readonly List<string> _linesBuffer = new List<string>();
        private readonly Stack<string> _inputLines;

        public TestExternalDependencies(IEnumerable<string> inputLines)
        {
            _inputLines = new Stack<string>(inputLines);
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
    }
}
