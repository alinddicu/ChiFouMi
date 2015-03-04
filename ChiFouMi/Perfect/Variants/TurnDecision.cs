namespace ChiFouMi.Perfect.Variants
{
    public class TurnDecision
    {
        public TurnDecision(PlayerTurnResult playerTurnResult, string announcement)
        {
            PlayerTurnResult = playerTurnResult;
            Announcement = announcement;
        }

        public PlayerTurnResult PlayerTurnResult { get; private set; }

        public string Announcement { get; private set; }
    }
}