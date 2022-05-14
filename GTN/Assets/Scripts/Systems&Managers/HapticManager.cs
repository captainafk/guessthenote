using MoreMountains.NiceVibrations;
using UniRx;
using UnityEngine;

namespace GuessTheNote
{
    public class HapticManager : MonoBehaviour
    {
        private void Awake()
        {
            MessageBus.Receive<OnGuessMade>().Subscribe(ge =>
            {
                if (SettingsPopup.Instance.IsVibrationEnabled)
                {
                    if (ge.IsCorrect)
                    {
                        MMVibrationManager.Haptic(HapticTypes.Success);
                    }
                    else
                    {
                        MMVibrationManager.Haptic(HapticTypes.Failure);
                    }
                }
            });
        }
    }
}
