namespace ChiFouMi
{
    using ChiFouMi.Horrible;
    using ChiFouMi.Perfect;

    internal static class Program
    {
        private static readonly HorribleExternalDependecies HorribleExternalDependecies = new HorribleExternalDependecies();

        private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(HorribleExternalDependecies);
        //private static readonly IChiFouMi ChiFouMi = new ChiFouMiFactory().Create(HorribleExternalDependecies);

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}