using UnityEngine;
using DG.Tweening;

namespace GuessTheNote
{
    public class SettingsPopup : Singleton<SettingsPopup>
    {
        [SerializeField] private GameObject _onToggle;
        [SerializeField] private GameObject _offToggle;

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
            GetComponent<RectTransform>().DOScale(Vector3.zero,
                                                  MainMenu.Instance.ButtonTweenDuration);
        }
    }
}
