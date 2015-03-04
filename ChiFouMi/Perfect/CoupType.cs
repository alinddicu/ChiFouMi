namespace ChiFouMi.Perfect
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public static IEnumerable<CoupType> GetCoupsElligibles()
        {
            return Enum.GetValues(typeof(CoupType)).OfType<CoupType>().ToList().Where(o => o.IsCoupElligible());
        }
    }
}