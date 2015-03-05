namespace ChiFouMi.Perfect
{
    using Perfect.Variants;
    using Variants.Common;

    public class ChiFouMiFactory
    {
        private ISystemDependencies _systemDependencies;
        private CommonVariantMode _mode;

        public ChiFouMiFactory(ISystemDependencies systemDependencies, CommonVariantMode mode)
        {
            _systemDependencies = systemDependencies;
            _mode = mode;
        }

        public ChiFouMi Create()
        {
            return new ChiFouMi(
                _systemDependencies,
                new DisplayChoixCoupGenerator(),
                new InputToCoupTypeConverter(),
                new Perfect.Variants.VariantTypeConverter(),
                new Perfect.Variants.ChiFouMiVariantsFactory(_mode, _systemDependencies));
        }
    }
}