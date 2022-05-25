using MoreMountains.NiceVibrations;
using UniRx;
using UnityEngine;

namespace GuessTheNote
{
    public class HapticManager : MonoBehaviour
    {
        [SerializeField] private VibrationManager _vibrationManager;

        private void Awake()
        {
            MessageBus.Receive<OnGuessMade>().Subscribe(ge =>
            {
                if (_vibrationManager.IsVibrationEnabled)
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

            MessageBus.Receive<OnVibrationOptionChanged>().Subscribe(ge =>
            {
                if (ge.IsEnabled)
                {
                    MMVibrationManager.Haptic(HapticTypes.SoftImpact);
                }
            });
        }
    }
}