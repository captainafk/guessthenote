namespace GuessTheNote
{
    /// <summary>
    /// Publish this when a guess is made
    /// </summary>
    public class OnGuessMade : GameEventBase
    {
        public bool IsCorrect;

        public OnGuessMade(bool isCorrect)
        {
            IsCorrect = isCorrect;
        }
    }
}
