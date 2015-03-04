namespace ChiFouMi.Perfect
{
    public enum PlayerTurnResult
    {
        Gagne,
        Perdu,
        Egalite
    }

    public static class PlayerTurnResultExtensions
    {
        public static string Announce(this PlayerTurnResult turnResult)
        {
            return turnResult.ToString() + "!";
        }
    }
}