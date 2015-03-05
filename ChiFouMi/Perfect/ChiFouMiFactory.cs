﻿namespace ChiFouMi.Perfect
{
    using Perfect.Variants;
    using Variants.Common;

    public class ChiFouMiFactory
    {
        private ISystemDependencies _systemDependencies;
        private VariantMode _mode;

        public ChiFouMiFactory(ISystemDependencies systemDependencies, VariantMode mode)
        {
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
                new ChiFouMiVariantsFactory(_mode, _systemDependencies));
        }
    }
}