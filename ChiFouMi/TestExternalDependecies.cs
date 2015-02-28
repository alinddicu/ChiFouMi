namespace ChiFouMi
{
    using System.Collections.Generic;
    using System.Text;

    public class TestExternalDependecies : IExternalDependecies
    {
        private readonly StringBuilder _linesBuffer = new StringBuilder();
        private readonly Stack<string> _inputLines = new Stack<string>();

        public void WriteLine(string line)
        {
            _linesBuffer.AppendLine(line);
        }

        public string ReadLine()
        {
            return _inputLines.Pop();
        }
    }
}
