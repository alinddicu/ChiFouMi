namespace ChiFouMi.Perfect.Variants
{
    using System.Collections.Generic;
    using Perfect.Variants.Common;

    public class ChiFouMiVariantsFactory
    {
        private readonly ChiFouMiMode _mode;
        private readonly ISystemDependencies _systemDependencies;

        public ChiFouMiVariantsFactory(
            ChiFouMiMode mode,
            ISystemDependencies systemDependencies)
        {
            _mode = mode;
            _systemDependencies = systemDependencies;
        }

        public IEnumerable<IChiFouMiVariant> Create()
        {
            yield return new CommonVariant(
                _systemDependencies,
                new InputToCoupTypeConverter(),
                new CommonVariantReferee(
                    new CommonVariantRulesFactory(_mode)));
            yield return new RoxorVariant(_systemDependencies, new InputToCoupTypeConverter());
        }
    }
}