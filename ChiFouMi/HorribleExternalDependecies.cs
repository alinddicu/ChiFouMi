namespace ChiFouMi
{
    using System;

    public class HorribleExternalDependecies : IExternalDependecies
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
