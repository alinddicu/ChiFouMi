namespace ChiFouMi.Perfect
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class DisplayChoixCoup
    {
        private const string ChoixCoupLineFormat = "{0}- {1}";

        public IEnumerable<string> Get()
        {
            string line = string.Empty;
            foreach (var coup in Enum.GetValues(typeof(CoupType)))
            {
                yield return string.Format(CultureInfo.InvariantCulture, ChoixCoupLineFormat, (int)coup, coup);
            }
        }
    }
}