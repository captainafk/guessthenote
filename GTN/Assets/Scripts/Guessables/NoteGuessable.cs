using UnityEngine;

namespace GuessTheNote
{
    [CreateAssetMenu(fileName = "Note", menuName = "ScriptableObjects/Note")]
    public class NoteGuessable : GuessableBase
    {
        // TODO: Add flats for B and E
        public override string ToString()
        {
            if (Sound.ToString().Length == 1)
            {
                return Sound.ToString();
            }
            else
            {
                return string.Format("{0}#", Sound.ToString()[0]);
            }
        }
    }
}
