using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GuessTheNote
{
    public class GuessableButton : MonoBehaviour
    {
        private GuessableBase _guessable;
        private Button _button;
        private PlayableBase _playable;

        public void InitButton(GuessableBase guessable)
        {
            _guessable = guessable;
            _button = GetComponent<Button>();
            _playable = GetComponentInParent<PlayableBase>();

            var choiceText = GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = guessable.ToString();

            _button.onClick.AddListener(() => MakeTheGuess());
        }

        // TODO: Revamp this castings
        private void MakeTheGuess()
        {
            if (_playable is NotePlayable)
            {
                var noteGuessable = (NoteGuessable)_guessable;
                var correctGuessable = (NoteGuessable)((NotePlayable)_playable).CorrectGuessable;

                if (noteGuessable.Note == correctGuessable.Note)
                {
                    print("Correct Guess!");

                    MessageBus.Publish(new OnCorrectGuess());
                }
                else
                {
                    print("Wrong Guess.");

                    MessageBus.Publish(new OnIncorrectGuess());
                }
            }
        }
    }
}
