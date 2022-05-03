using UnityEngine;

namespace GuessTheNote
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Playables")]
        [SerializeField] private PlayableBase _notePlayable;

        public void LoadPlayable()
        {
            Instantiate(_notePlayable);

            MessageBus.Publish(new OnPlayButtonPressed(_notePlayable));
        }
    }
}
