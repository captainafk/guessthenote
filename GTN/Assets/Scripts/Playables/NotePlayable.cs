using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    public class NotePlayable : PlayableBase
    {
        private void Awake()
        {
            OnInitialized += GetGuessableAndDisplay;
        }

        private void OnDestroy()
        {
            OnInitialized -= GetGuessableAndDisplay;
        }

        private void GetGuessableAndDisplay()
        {
            var mainMenu = GetComponentInParent<MainMenu>();
            var randomGuessable = mainMenu.NoteGuessables.GetRandom();

            print(randomGuessable.Note);

        }
    }
}
