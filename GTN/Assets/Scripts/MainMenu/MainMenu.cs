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

        private List<GuessableBase> _guessables;

        public List<GuessableBase> Guessables
        {
            get
            {
                if (_guessables == null)
                {
                    _guessables = Resources.LoadAll<GuessableBase>(_notePlayable.GuessablePath)
                                           .ToList();
                }

                return _guessables;
            }
        }

        public void LoadPlayable()
        {
            _mainMenuCanvas.SetActive(false);

            // TODO: Remove the hard coded playable
            PlayableBase playable = Instantiate(_notePlayable, _playableParent);

            playable.Init(Guessables);

            MessageBus.Publish(new OnPlayButtonPressed(playable));
        }
    }
}
