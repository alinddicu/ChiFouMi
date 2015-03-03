namespace ChiFouMi.Test.TestHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class InputLinesGenerator
    {
        private readonly Random _randomGenerator = new Random(DateTime.Now.Millisecond);

        public IEnumerable<string> Generate(int linesNumber)
        {
            for (var i = 0; i < linesNumber; i++)
            {
                yield return Environment.NewLine;
                yield return _randomGenerator.Next(1, 4).ToString(CultureInfo.InvariantCulture);
            }

            yield return Environment.NewLine;
            yield return "exit";
        }
    }
}