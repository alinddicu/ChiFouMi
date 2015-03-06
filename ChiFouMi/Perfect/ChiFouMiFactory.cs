namespace ChiFouMi.Perfect
{
    using Variants;

    public class ChiFouMiFactory
    {
        private readonly ISystemDependencies _systemDependencies;
        private readonly ChiFuMiMode _mode;
        private readonly int _randomUpperLimit;

        public ChiFouMiFactory(
            int randomUpperLimit,
            ISystemDependencies systemDependencies,
            ChiFuMiMode mode)
        {
            _randomUpperLimit = randomUpperLimit;
            _systemDependencies = systemDependencies;
            _mode = mode;
        }

        public ChiFouMi Create()
        {
            return new ChiFouMi(
                _mode,
                _systemDependencies,
                new DisplayChoixCoupGenerator(),
                new InputToCoupTypeConverter(),
                new VariantTypeConverter(),
                new ChiFouMiVariantsFactory(_randomUpperLimit, _mode, _systemDependencies));
        }
    }
}