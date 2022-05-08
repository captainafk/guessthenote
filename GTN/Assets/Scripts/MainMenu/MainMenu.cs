using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNote
{
    public class MainMenu : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _mainMenuCanvas;
        [SerializeField] private Transform _playableParent;
        [SerializeField] private RectTransform _playButton;
        [SerializeField] private RectTransform _playNotesButton;
        [SerializeField] private RectTransform _playChordsButton;

        [Header("Playables")]
        [SerializeField] private PlayableBase _notePlayable;
        [SerializeField] private PlayableBase _chordPlayable;

        [Header("Config")]
        [SerializeField] private float _buttonTweenDuration = 0.5f;

        private List<GuessableBase> _guessables;

        public List<GuessableBase> Guessables
        {
            get
            {
                if (_guessables == null)
                {
                    // TODO: Dynamic path string generation wrt instrument and note/chord
                    _guessables = Resources.LoadAll<GuessableBase>(_notePlayable.GuessablePath)
                                           .ToList();
                }

                return _guessables;
            }
        }

        private void Awake()
        {
            _playNotesButton.localScale = Vector3.zero;
            _playChordsButton.localScale = Vector3.zero;
        }

        public void ShowPlayableButtons()
        {
            _playButton.DOScale(0, _buttonTweenDuration)
                       .OnComplete(() =>
                       {
                           _playNotesButton.DOScale(1, _buttonTweenDuration);
                           _playChordsButton.DOScale(1, _buttonTweenDuration);

                           _playNotesButton.GetComponent<Button>()
                                           .onClick.AddListener(() =>
                                           {
                                               LoadPlayable(_notePlayable);
                                           });

                           _playChordsButton.GetComponent<Button>()
                                           .onClick.AddListener(() =>
                                           {
                                               LoadPlayable(_chordPlayable);
                                           });
                       });
        }

        private void LoadPlayable(PlayableBase playablePrefab)
        {
            _mainMenuCanvas.SetActive(false);

            print(playablePrefab.name + " initiated.");

            PlayableBase playable = Instantiate(playablePrefab, _playableParent);

            playable.Init(Guessables);

            MessageBus.Publish(new OnPlayButtonPressed(playable));
        }
    }
}
