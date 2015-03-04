namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Collections.Generic;

    public class CommonVariantRulesFactory : ICommonVariantRulesFactory
    {
        public IEnumerable<CommonVariantRule> Create()
        {
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Feuille, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Ciseaux, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Pierre, PlayerTurnResult.Egalite);
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Feuille, PlayerTurnResult.Egalite);
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Ciseaux, PlayerTurnResult.Perdu, "Pierre contre Feuille!");
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Pierre, PlayerTurnResult.Perdu, "Pierre contre Feuille!");
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Pierre, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Feuille, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Ciseaux, PlayerTurnResult.Egalite);
        }
    }
}