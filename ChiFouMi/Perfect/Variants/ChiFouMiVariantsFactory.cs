namespace ChiFouMi.Perfect.Variants
{
    using System.Collections.Generic;
    using Perfect.Variants.Common;

    public class ChiFouMiVariantsFactory
    {
        public IEnumerable<IChiFouMiVariant> Create(ISystemDependencies externalDependencies)
        {
            yield return new CommonVariant(
                externalDependencies,
                new InputToCoupTypeConverter(),
                new CommonVariantReferee(
                    new CommonVariantRulesFactory()));
            yield return new RoxorVariant(externalDependencies, new InputToCoupTypeConverter());
        }
    }
}
