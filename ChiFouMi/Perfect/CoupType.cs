﻿namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using Variants;

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

        public static IEnumerable<CoupType> GetCoupsElligibles(VariantMode mode)
        {
            yield return CoupType.Pierre;
            yield return CoupType.Feuille;
            yield return CoupType.Ciseaux;

            if (mode != VariantMode.Extended)
            {
                yield break;
            }

            yield return CoupType.Lezard;
            yield return CoupType.Spock;
        }
    }
}