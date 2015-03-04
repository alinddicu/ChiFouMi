namespace ChiFouMi.Perfect
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class DisplayChoixCoupGenerator
    {
        private const string ChoixCoupLineFormat = "{0}- {1}";

        public IEnumerable<string> Get()
        {
            string line = string.Empty;
            foreach (var coup in CoupTypeExtensions.GetCoupsElligibles())
            {
                yield return string.Format(CultureInfo.InvariantCulture, ChoixCoupLineFormat, (int)coup, coup);
            }
        }
    }
}