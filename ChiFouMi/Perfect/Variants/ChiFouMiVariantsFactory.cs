namespace ChiFouMi.Perfect.Variants
{
    using System.Collections.Generic;

    public class ChiFouMiVariantsFactory
    {
        public IEnumerable<IChiFouMiVariant> Create(IExternalDependencies externalDependencies)
        {
            yield return new CommonVariant(externalDependencies, new InputToCoupTypeConverter());
            yield return new RoxorVariant(externalDependencies, new InputToCoupTypeConverter());
        }
    }
}
