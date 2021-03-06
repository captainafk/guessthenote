using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UniRx;
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
        [SerializeField] private float _playableReloadDelay = 1;

        private string _guessablePath = "";
        private List<GuessableBase> _guessables;
        private PlayableBase _currentPlayable;
        private PlayableBase _lastInstantiatedPlayable;
        private System.IDisposable _reloadDisposable;

        public List<GuessableBase> Guessables
        {
            get
            {
                if (_guessables == null)
                {
                    // TODO: Dynamic path string generation wrt instrument and note/chord
                    _guessables = Resources.LoadAll<GuessableBase>(_guessablePath)
                                           .ToList();
                }

                return _guessables;
            }
        }

        private void Awake()
        {
            _playNotesButton.localScale = Vector3.zero;
            _playChordsButton.localScale = Vector3.zero;

            MessageBus.Receive<OnGuessMade>().Subscribe(ge =>
            {
                ReloadCurrentPlayable(_playableReloadDelay);
            });

            MessageBus.Receive<OnReturnedToMainMenu>().Subscribe(ge =>
            {
                ResetMainMenu();
            });
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
            _lastInstantiatedPlayable = playablePrefab;

            _mainMenuCanvas.SetActive(false);

            _guessablePath = playablePrefab.GuessablePath;

            _currentPlayable = Instantiate(playablePrefab, _playableParent);

            _guessables = null;
            _currentPlayable.Init(Guessables);

            MessageBus.Publish(new OnPlayButtonPressed(_currentPlayable));
        }

        private void ReloadCurrentPlayable(float delay)
        {
            _reloadDisposable = Observable.Timer(System.TimeSpan.FromSeconds(delay)).Subscribe(_ =>
            {
                Destroy(_currentPlayable.gameObject);

                _currentPlayable = Instantiate(_lastInstantiatedPlayable, _playableParent);

                _currentPlayable.Init(Guessables);
            });
        }

        private void ResetMainMenu()
        {
            _playNotesButton.GetComponent<Button>()
                            .onClick.RemoveAllListeners();

            _playChordsButton.GetComponent<Button>()
                             .onClick.RemoveAllListeners();

            _playNotesButton.localScale = Vector3.zero;
            _playChordsButton.localScale = Vector3.zero;

            _mainMenuCanvas.SetActive(true);

            Destroy(_currentPlayable.gameObject);
            _reloadDisposable?.Dispose();

            _playButton.localScale = Vector3.one;
        }
    }
}