using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

namespace GuessTheNote
{
    public class NotePlayable : PlayableBase
    {
        [SerializeField] private List<GuessableButton> _choices;

        private void Awake()
        {
            OnInitialized += DisplayGuessables;
        }

        private void OnDestroy()
        {
            OnInitialized -= DisplayGuessables;
        }

        // TODO: Move this to an upper level
        private void DisplayGuessables()
        {
            var mainMenu = GetComponentInParent<MainMenu>();
            var randomGuessables = new List<NoteGuessable>();

            while (randomGuessables.Count < 4) // 4 choices
            {
                var randomGuessable = mainMenu.NoteGuessables.GetRandom();

                var isRGPresent = randomGuessables.Where(rg => rg.Note.Equals(randomGuessable.Note))
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
        }
    }
}
