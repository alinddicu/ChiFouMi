﻿namespace ChiFouMi.Perfect
{
    public class ChiFouMiFactory
    {
        public ChiFouMi Create(IExternalDependencies dependencies)
        {
            return new ChiFouMi(dependencies, new DisplayChoixCoupGenerator(), new InputToCoupTypeConverter());
        }
    }
}