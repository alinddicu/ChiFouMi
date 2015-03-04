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
            foreach (var coupElligile in Enum.GetValues(typeof(CoupType)).OfType<CoupType>().ToList().Except(new[] { CoupType.None }))
            {
                Check.That(coupElligile.IsCoupElligible()).IsTrue();
            }
        }
    }
}