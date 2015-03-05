namespace ChiFouMi.Perfect.Variants.Common
{
    using System;
    using System.Collections.Generic;

    public interface ICommonVariantRulesFactory
    {
        IEnumerable<CommonVariantRule> Create();
    }
}