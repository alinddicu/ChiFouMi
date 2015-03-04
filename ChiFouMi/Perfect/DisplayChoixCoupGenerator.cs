namespace ChiFouMi.Perfect
{
    using System.Collections.Generic;
    using System.Globalization;
    using Variants.Common;

    public class DisplayChoixCoupGenerator
    {
        private const string ChoixCoupLineFormat = "{0}- {1}";

        public IEnumerable<string> Get(CommonVariantMode commonMode)
        {
            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles(commonMode))
            {
                yield return string.Format(CultureInfo.InvariantCulture, ChoixCoupLineFormat, (int)coup, coup);
            }
        }
    }
}