namespace ChiFouMi.Perfect.Variants
{
    using System.Collections.Generic;

    public class ChiFouMiVariantsFactory
    {
        public IEnumerable<IChiFouMiVariant> Create(ISystemDependencies externalDependencies)
        {
            yield return new CommonVariant(externalDependencies, new InputToCoupTypeConverter());
            yield return new RoxorVariant(externalDependencies, new InputToCoupTypeConverter());
        }
    }
}
