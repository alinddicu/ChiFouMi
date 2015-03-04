namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Globalization;

    public class CommonVariantRule
    {
        private const string DecisionText = "{0} contre {1}!";

        public CommonVariantRule(
            CoupType playerCoup,
            CoupType computerCoup,
            PlayerTurnResult playerTurnResult,
            string overridenAnnouncement = "")
        {
            PlayerCoup = playerCoup;
            ComputerCoup = computerCoup;
            PlayerTurnResult = playerTurnResult;
            OverridenAnnouncement = overridenAnnouncement;
        }

        public CoupType PlayerCoup { get; private set; }

        public CoupType ComputerCoup { get; private set; }

        public PlayerTurnResult PlayerTurnResult { get; private set; }

        public string OverridenAnnouncement { get; private set; }

        public string ToAnnouncement()
        {
            if (!string.IsNullOrEmpty(OverridenAnnouncement))
            {
                return OverridenAnnouncement;
            }

            return string.Format(CultureInfo.InvariantCulture, DecisionText, PlayerCoup, ComputerCoup);
        }
    }
}