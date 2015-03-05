namespace ChiFouMi
{
    using ChiFouMi.Horrible;
    using ChiFouMi.Perfect;
    using ChiFouMi.Perfect.Variants;

    internal static class Program
    {
        private static readonly HorribleExternalDependecies HorribleExternalDependecies = new HorribleExternalDependecies();

        //private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(HorribleExternalDependecies);
        private static readonly IChiFouMi ChiFouMi = new ChiFouMiFactory(HorribleExternalDependecies, ChiFuMiMode.Extended).Create();

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}