namespace ChiFouMi.Perfect.Variants.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommonVariantRulesFactory : ICommonVariantRulesFactory
    {
        private readonly ChiFuMiMode _chiFuMiMode;

        public CommonVariantRulesFactory(ChiFuMiMode chiFuMiMode)
        {
            _chiFuMiMode = chiFuMiMode;
        }

        private static IEnumerable<CommonVariantRule> YieldBaseWinRules()
        {
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Ciseaux, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Feuille, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Pierre, PlayerTurnResult.Gagne);
        }

        private static IEnumerable<CommonVariantRule> YieldExtendedWinRules()
        {
            yield return new CommonVariantRule(CoupType.Pierre, CoupType.Lezard, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Spock, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Ciseaux, CoupType.Lezard, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Spock, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Lezard, CoupType.Feuille, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Pierre, PlayerTurnResult.Gagne);
            yield return new CommonVariantRule(CoupType.Spock, CoupType.Ciseaux, PlayerTurnResult.Gagne);
        }

        private static IEnumerable<CommonVariantRule> YieldBaseExceptionRules()
        {
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Ciseaux, PlayerTurnResult.Perdu, "Pierre contre Feuille!");
            yield return new CommonVariantRule(CoupType.Feuille, CoupType.Pierre, PlayerTurnResult.Perdu, "Pierre contre Feuille!");
        }

        public IEnumerable<CommonVariantRule> Create()
        {
            return _chiFuMiMode == ChiFuMiMode.Extended ? GenerateExtendedRules() : GenerateBaseRules();
        }

        private IEnumerable<CommonVariantRule> GenerateBaseRules()
        {
            var winRules = YieldBaseWinRules().ToArray();
            var equalityRules = GenerateBaseEqualityRules();
            var looseRules = winRules.Select(GenerateLooseRule);

            return GenerateAllRulesWithExceptions(winRules, equalityRules, looseRules);
        }

        private IEnumerable<CommonVariantRule> GenerateExtendedRules()
        {
            var winRules = YieldBaseWinRules().Union(YieldExtendedWinRules()).ToArray();
            var equalityRules = GenerateExtendedEqualityRules();
            var looseRules = winRules.Select(GenerateLooseRule);

            return GenerateAllRulesWithExceptions(winRules, equalityRules, looseRules);
        }

        private static IEnumerable<CommonVariantRule> GenerateAllRulesWithExceptions(
            IEnumerable<CommonVariantRule> winRules,
            IEnumerable<CommonVariantRule> equalityRules,
            IEnumerable<CommonVariantRule> looseRules)
        {
            var rules = new List<CommonVariantRule>();
            rules.AddRange(winRules);
            rules.AddRange(equalityRules);
            rules.AddRange(looseRules);

            var baseExceptionRules = YieldBaseExceptionRules().ToArray();

            rules = rules.Except(baseExceptionRules).ToList();
            rules.AddRange(baseExceptionRules);

            return rules;
        }

        private static IEnumerable<CommonVariantRule> GenerateBaseEqualityRules()
        {
            return Enum
                .GetValues(typeof(CoupType))
                .OfType<CoupType>()
                .Where(coup => coup.IsCoupElligible())
                .Where(coup => !coup.IsExtendedCoup())
                .Select(GenerateEqualityRule);
        }

        private static IEnumerable<CommonVariantRule> GenerateExtendedEqualityRules()
        {
            return Enum
                .GetValues(typeof(CoupType))
                .OfType<CoupType>()
                .Where(coup => coup.IsCoupElligible())
                .Select(GenerateEqualityRule);
        }

        private static CommonVariantRule GenerateEqualityRule(CoupType coup)
        {
            return new CommonVariantRule(coup, coup, PlayerTurnResult.Egalite);
        }

        private static CommonVariantRule GenerateLooseRule(CommonVariantRule winRule)
        {
            return new CommonVariantRule(winRule.ComputerCoup, winRule.PlayerCoup, PlayerTurnResult.Perdu);
        }
    }
}