namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class DisplayChoixCoupGenerator
    {
        private const string ChoixCoupLineFormat = "{0}- {1}";

        public IEnumerable<string> Generate(ChiFuMiMode mode)
        {
            return CoupTypeExtensions
                .GetCoupsElligibles(mode)
                .Select(coup => string.Format(CultureInfo.InvariantCulture, ChoixCoupLineFormat, (int)coup, coup));
        }
    }
}