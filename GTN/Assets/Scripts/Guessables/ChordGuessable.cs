using UnityEngine;

namespace GuessTheNote
{
    [CreateAssetMenu(fileName = "Chord", menuName = "ScriptableObjects/Chord")]
    public class ChordGuessable : GuessableBase
    {
        // TODO: Handle flats and minors
        public override string ToString()
        {
            if (Sound.ToString().Length == 1 || Sound.ToString().Length == 2)
            {
                return Sound.ToString();
            }
            else
            {
                return string.Format("{0}#", Sound.ToString().Substring(0, 2));
            }
        }
    }
}
