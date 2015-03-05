namespace ChiFouMi
{
    using Horrible;
    using Perfect;
    using Perfect.Variants;

    internal static class Program
    {
        private static readonly HorribleExternalDependecies HorribleExternalDependecies = new HorribleExternalDependecies();

        //private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(HorribleExternalDependecies);
        private static readonly IChiFouMi ChiFouMi = new ChiFouMiFactory(HorribleExternalDependecies, ChiFouMiMode.Base).Create();

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}