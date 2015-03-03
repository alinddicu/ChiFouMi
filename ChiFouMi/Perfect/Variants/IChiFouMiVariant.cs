namespace ChiFouMi.Perfect.Variants
{
    public interface IChiFouMiVariant
    {
        bool CanPlay(VariantType variantType);

        TurnResult PlayTurn(CoupType playerChoice);
    }
}
