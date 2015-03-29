namespace ChiFouMi.Perfect.Variants
{
    using System.Collections.Generic;
    using Common;

    public class ChiFouMiVariantsFactory
    {
        private readonly ChiFuMiMode _mode;
        private readonly ISystemDependencies _systemDependencies;
        private readonly int _randomUpperLimit;

        public ChiFouMiVariantsFactory(
            int randomUpperLimit,
            ChiFuMiMode mode,
            ISystemDependencies systemDependencies)
        {
            _randomUpperLimit = randomUpperLimit;
            _mode = mode;
            _systemDependencies = systemDependencies;
        }

        public IEnumerable<IChiFouMiVariant> Create()
        {
            yield return new CommonVariant(
                _randomUpperLimit,
                _systemDependencies,
                new InputToCoupTypeConverter(),
                new CommonVariantReferee(
                    new CommonVariantRulesFactory(_mode)));

            yield return new RoxorVariant(
                _randomUpperLimit,
                _systemDependencies,
                new InputToCoupTypeConverter());
        }
    }
}