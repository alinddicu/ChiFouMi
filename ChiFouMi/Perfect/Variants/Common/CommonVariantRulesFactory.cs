namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Collections.Generic;

    public class CommonVariantRulesFactory : ICommonVariantRulesFactory
    {
        private readonly ChiFouMiMode _mode;

        public CommonVariantRulesFactory(ChiFouMiMode mode)
        {
            _mode = mode;
        }

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

            if (_mode != ChiFouMiMode.Extended)
            {
                yield break;
            }

            foreach (var rule in YieldExtendedModeRules())
            {
                yield return rule;
            }
        }

        private IEnumerable<CommonVariantRule> YieldExtendedModeRules()
        {
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Lezard, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Spock, PlayerTurnResult.Perdu);

            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Lezard, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Spock, PlayerTurnResult.Gagne);

            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Lezard, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Spock, PlayerTurnResult.Perdu);

            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Lezard, PlayerTurnResult.Egalite);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Spock, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Pierre, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Feuille, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Ciseaux, PlayerTurnResult.Perdu);

            yield return new CommonVariantRule(CoupType.Spock, CoupType.Pierre, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Feuille, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Ciseaux, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Lezard, PlayerTurnResult.Perdu);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Spock, PlayerTurnResult.Egalite);
        }
    }
}