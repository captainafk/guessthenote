namespace GuessTheNote
{
    /// <summary>
    /// Publish this when the play button is pressed
    /// </summary>
    public class OnPlayButtonPressed : GameEventBase
    {
        public PlayableBase Playable;

        public OnPlayButtonPressed(PlayableBase playable)
        {
            Playable = playable;
        }
    }
}
