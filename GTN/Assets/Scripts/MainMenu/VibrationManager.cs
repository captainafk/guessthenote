using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNote
{
    public class VibrationManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Sprite _enabledIcon;
        [SerializeField] private Sprite _disabledIcon;
        [SerializeField] private Image _buttonImage;

        public bool IsVibrationEnabled
        {
            get
            {
                return System.Convert.ToBoolean(PlayerPrefs.GetInt("Vibration", 1));
            }
            set
            {
                PlayerPrefs.SetInt("Vibration", System.Convert.ToInt32(value));
            }
        }

        private void Awake() => SetSprites();

        public void SwitchVibration()
        {
            IsVibrationEnabled = !IsVibrationEnabled;

            SetSprites();

            MessageBus.Publish(new OnVibrationOptionChanged(IsVibrationEnabled));
        }

        private void SetSprites()
        {
            var icon = IsVibrationEnabled ? _enabledIcon : _disabledIcon;

            _buttonImage.sprite = icon;
        }
    }
}