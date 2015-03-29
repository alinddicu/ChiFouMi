namespace ChiFouMi.Perfect.Variants.Common
{
    using System.Globalization;

    public class CommonVariantRule
    {
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

        public override string ToString()
        {
            const string format = "{0}, {1}, {2}, {3}";
            return string.Format(
                CultureInfo.InvariantCulture,
                format,
                PlayerCoup,
                ComputerCoup,
                PlayerTurnResult,
                OverridenAnnouncement);
        }

        public string ToAnnouncement()
        {
            if (!string.IsNullOrEmpty(OverridenAnnouncement))
            {
                return OverridenAnnouncement;
            }

            const string decisionText = "{0} contre {1}!";
            return string.Format(CultureInfo.InvariantCulture, decisionText, PlayerCoup, ComputerCoup);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj != null && Equals((CommonVariantRule)obj);
        }

        private bool Equals(CommonVariantRule other)
        {
            return Equals(PlayerCoup, other.PlayerCoup)
                && Equals(ComputerCoup, other.ComputerCoup);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ComputerCoup.GetHashCode() ^ 397 * PlayerCoup.GetHashCode() ^ 397;
            }
        }
    }
}