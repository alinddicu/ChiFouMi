namespace ChiFouMi.Horrible
{
    using System;

    public class HorribleExternalDependecies : ISystemDependencies
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public int GetNextRandomBetween1And3()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 4);
        }
    }
}