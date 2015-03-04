namespace ChiFouMi.Perfect
{
    public enum CoupType
    {
        None = 0,
        Pierre = 1,
        Feuille = 2,
        Ciseaux = 3
    }

    public static class CoupTypeExtensions
    {
        public static bool IsCoupElligible(this CoupType coup)
        {
            return coup != CoupType.None;
        }
    }
}