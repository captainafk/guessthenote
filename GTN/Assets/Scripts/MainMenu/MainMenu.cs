using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GuessTheNote
{
    public class MainMenu : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _mainMenuCanvas;
        [SerializeField] private Transform _playableParent;

        [Header("Playables")]
        [SerializeField] private PlayableBase _notePlayable;

        public List<NoteGuessable> NoteGuessables
        {
            get
            {
                return Resources.LoadAll<NoteGuessable>("ScriptableObjects/NoteGuessables")
                                .ToList();
            }
        }

        public void LoadPlayable()
        {
            _mainMenuCanvas.SetActive(false);

            // TODO: Remove the hard coded playable
            PlayableBase playable = Instantiate(_notePlayable, _playableParent);

            playable.OnInitialized?.Invoke();
            MessageBus.Publish(new OnPlayButtonPressed(playable));
        }
    }
}
