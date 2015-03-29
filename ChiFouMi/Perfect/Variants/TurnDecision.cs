namespace ChiFouMi.Perfect.Variants
{
    public struct TurnDecision
    {
        public TurnDecision(
            PlayerTurnResult playerTurnResult, 
            TurnNextAction turnNextAction,
            string announcement)
            : this()
        {
            PlayerTurnResult = playerTurnResult;
            TurnNextAction = turnNextAction;
            Announcement = announcement;
        }

        public TurnDecision(TurnNextAction turnNextAction)
            : this()
        {
            TurnNextAction = turnNextAction;
        }

        public PlayerTurnResult PlayerTurnResult { get; private set; }

        public TurnNextAction TurnNextAction { get; private set; }

        public string Announcement { get; private set; }
    }
}