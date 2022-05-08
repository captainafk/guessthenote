using UnityEngine;

namespace GuessTheNote
{
    [CreateAssetMenu(fileName = "Chord", menuName = "ScriptableObjects/Chord")]
    public class ChordGuessable : GuessableBase
    {
        // TODO: Handle flats and minors
        public override string ToString()
        {
            if (Sound.ToString().Length == 1 || Sound.ToString().Length == 2) // A and Am
            {
                return Sound.ToString();
            }
            if (Sound.ToString().Length == 6) // Asharp
            {
                return string.Format("{0}#", Sound.ToString()[0]);
            }
            else
            {
                return string.Format("{0}#", Sound.ToString().Substring(0, 2)); // Amsharp
            }
        }
    }
}
