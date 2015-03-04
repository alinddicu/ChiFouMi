namespace ChiFouMi.Perfect.Variants
{
    public interface IChiFouMiVariant
    {
        bool CanPlay(VariantType variantType);

        TurnNextAction PlayTurn(CoupType playerCoup);
    }
}