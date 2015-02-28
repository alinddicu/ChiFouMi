namespace ChiFouMi
{
    static class Program
    {
        private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(new HorribleExternalDependecies());

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}
