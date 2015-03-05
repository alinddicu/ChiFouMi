namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using Perfect.Variants;

    public enum CoupType
    {
        None = 0,
        Pierre = 1,
        Feuille = 2,
        Ciseaux = 3,
        Lezard = 4,
        Spock = 5
    }

    public static class CoupTypeExtensions
    {
        public static bool IsCoupElligible(this CoupType coup)
        {
            return coup != CoupType.None;
        }

        public static IEnumerable<CoupType> GetCoupsElligibles(ChiFouMiMode commonMode)
        {
            yield return CoupType.Pierre;
            yield return CoupType.Feuille;
            yield return CoupType.Ciseaux;

            if (commonMode == ChiFouMiMode.Extended)
            {
                yield return CoupType.Lezard;
                yield return CoupType.Spock;
            }
        }
    }
}