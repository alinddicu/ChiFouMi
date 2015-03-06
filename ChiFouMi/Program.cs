namespace ChiFouMi
{
    using Horrible;
    using Perfect;

    internal static class Program
    {
        private static readonly HorribleExternalDependecies HorribleExternalDependecies = new HorribleExternalDependecies();

        //private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(HorribleExternalDependecies);
        private static readonly IChiFouMi ChiFouMi = new ChiFouMiFactory(5, HorribleExternalDependecies, ChiFuMiMode.Extended).Create();

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}