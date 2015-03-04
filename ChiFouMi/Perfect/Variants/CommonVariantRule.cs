namespace ChiFouMi.Perfect.Variants
{
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
    }
}