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

            // TODO: Remove listeners when a level is done
            _button.onClick.AddListener(() => MakeTheGuess());
        }

        private void MakeTheGuess()
        {
            if (_guessable == _playable.CorrectGuessable)
            {
                print("Correct Guess!");

                MessageBus.Publish(new OnGuessMade(true, _guessable));
            }
            else
            {
                print("Wrong Guess.");

                MessageBus.Publish(new OnGuessMade(false, _playable.CorrectGuessable));
            }
        }
    }
}
