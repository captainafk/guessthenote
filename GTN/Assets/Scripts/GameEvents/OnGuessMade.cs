namespace GuessTheNote
{
    /// <summary>
    /// Publish this when a guess is made
    /// </summary>
    public class OnGuessMade : GameEventBase
    {
        public bool IsCorrect;
        public GuessableBase CorrectGuessable;

        public OnGuessMade(bool isCorrect, GuessableBase correctGuessable)
        {
            IsCorrect = isCorrect;
            CorrectGuessable = correctGuessable;
        }
    }
}