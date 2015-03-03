namespace ChiFouMi.Perfect
{
    using Variants;

    public class ChiFouMiFactory
    {
        public ChiFouMi Create(ISystemDependencies dependencies)
        {
            return new ChiFouMi(
                dependencies, 
                new DisplayChoixCoupGenerator(), 
                new InputToCoupTypeConverter(),
                new VariantTypeConverter(),
                new ChiFouMiVariantsFactory());
        }
    }
}