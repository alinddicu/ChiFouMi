namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using System.Globalization;

    public class DisplayChoixCoupGenerator
    {
        private const string ChoixCoupLineFormat = "{0}- {1}";

        public IEnumerable<string> Generate(ChiFouMiMode mode)
        {
            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles(mode))
            {
                yield return string.Format(CultureInfo.InvariantCulture, ChoixCoupLineFormat, (int)coup, coup);
            }
        }
    }
}