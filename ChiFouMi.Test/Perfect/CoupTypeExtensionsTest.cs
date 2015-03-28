namespace ChiFouMi.Test.Perfect
{
    using System;
    using System.Linq;
    using ChiFouMi.Perfect;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class CoupTypeExtensionsTest
    {
        [TestMethod]
        public void GivenNoneWhenIsCoupElligibleThenReturnFalse()
        {
            Check.That(CoupType.None.IsCoupElligible()).IsFalse();
        }

        [TestMethod]
        public void ForAllCoupElligiblesWhenIsCoupElligibleReturnTrue()
        {
            var coupsElligibles = Enum
                .GetValues(typeof(CoupType))
                .OfType<CoupType>()
                .ToArray()
                .Except(new[] { CoupType.None });
            foreach (var coupElligile in coupsElligibles)
            {
                Check.That(coupElligile.IsCoupElligible()).IsTrue();
            }
        }

        [TestMethod]
        public void CheckIsExtendedCoup()
        {
            Check.That(CoupType.None.IsExtendedCoup()).IsFalse();
            Check.That(CoupType.Ciseaux.IsExtendedCoup()).IsFalse();
            Check.That(CoupType.Feuille.IsExtendedCoup()).IsFalse();
            Check.That(CoupType.Pierre.IsExtendedCoup()).IsFalse();
            Check.That(CoupType.Lezard.IsExtendedCoup()).IsTrue();
            Check.That(CoupType.Spock.IsExtendedCoup()).IsTrue();
        }
    }
}