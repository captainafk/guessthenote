using UnityEngine;
using DG.Tweening;

namespace GuessTheNote
{
    public class SettingsPopup : Singleton<SettingsPopup>
    {
        [Header("References")]
        [SerializeField] private GameObject _onToggle;
        [SerializeField] private GameObject _offToggle;

        [Header("Config")]
        [SerializeField] private float _popupTweenDuration = 1;

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

        public float PopupTweenDuration => _popupTweenDuration;

        private void Awake() => SetToggles();

        public void SwitchVibration()
        {
            IsVibrationEnabled = !IsVibrationEnabled;

            SetToggles();
        }

        private void SetToggles()
        {
            _onToggle.SetActive(IsVibrationEnabled);
            _offToggle.SetActive(!IsVibrationEnabled);
        }

        public void ClosePopup()
        {
            GetComponent<RectTransform>().DOMoveX(-Screen.width / 2f,
                                                  _popupTweenDuration)
                                         .SetEase(Ease.InOutElastic);
        }
    }
}
