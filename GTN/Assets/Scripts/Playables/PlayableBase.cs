using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNote
{
    public abstract class PlayableBase : MonoBehaviour
    {
        [SerializeField] private Button _playAudioClipButton;

        private List<GuessableButton> _choices;
        private AudioSource _audioSource;

        [HideInInspector] public GuessableBase CorrectGuessable;

        public string GuessablePath;

        public void Init(List<GuessableBase> guessables)
        {
            _choices = GetComponentsInChildren<GuessableButton>().ToList();
            _audioSource = GetComponent<AudioSource>();

            var randomGuessables = new List<GuessableBase>();

            while (randomGuessables.Count < 4) // 4 choices
            {
                var randomGuessable = guessables.GetRandom();

                var isRGPresent = randomGuessables.Where(rg => rg == randomGuessable)
                                                  .Count();

                if (isRGPresent == 0) // The note is not already on the list
                {
                    randomGuessables.Add(randomGuessable);
                }
            }

            CorrectGuessable = randomGuessables[0];
            print("Correct: " + CorrectGuessable.ToString());

            randomGuessables.Shuffle();

            for (int i = 0; i < randomGuessables.Count; i++)
            {
                var rg = randomGuessables[i];
                _choices[i].InitButton(rg);
            }

            var randomAudioClip = CorrectGuessable.AudioClips.GetRandom();
            _audioSource.clip = randomAudioClip;

            PlayAudioClip();

            _playAudioClipButton.onClick.AddListener(() => PlayAudioClip());
        }

        public void PlayAudioClip(float delay = 0)
        {
            _audioSource.PlayDelayed(delay);
        }
    }
}
