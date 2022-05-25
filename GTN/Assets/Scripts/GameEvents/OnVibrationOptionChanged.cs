namespace GuessTheNote
{
    public class OnVibrationOptionChanged : GameEventBase
    {
        public bool IsEnabled;

        public OnVibrationOptionChanged(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }
    }
}