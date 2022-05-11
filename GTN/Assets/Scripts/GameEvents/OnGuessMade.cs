namespace GuessTheNote
{
    /// <summary>
    /// Publish this when a guess is made
    /// </summary>
    public class OnGuessMade : GameEventBase
    {
        public bool IsCorrect;
        public GuessableBase Guessable;

        public OnGuessMade(bool isCorrect, GuessableBase guessable = null)
        {
            IsCorrect = isCorrect;
            Guessable = guessable;
        }
    }
}
