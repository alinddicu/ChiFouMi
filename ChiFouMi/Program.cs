namespace ChiFouMi
{
    using ChiFouMi.Horrible;
    using ChiFouMi.Perfect;

    internal static class Program
    {
        private static readonly IChiFouMi ChiFouMi = new HorribleChiFouMi(new HorribleExternalDependecies());
        //private static readonly IChiFouMi ChiFouMi = new ChiFouMi(new HorribleExternalDependecies(), new DisplayChoixCoupGenerator());

        private static void Main(string[] args)
        {
            ChiFouMi.Play(args);
        }
    }
}