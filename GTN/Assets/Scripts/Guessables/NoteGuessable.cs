using UnityEngine;

namespace GuessTheNote
{
    [CreateAssetMenu(fileName = "Note", menuName = "ScriptableObjects/Note")]
    public class NoteGuessable : GuessableBase
    {
        // TODO: Add flats for B and E
        public override string ToString()
        {
            if (Note.ToString().Length == 1)
            {
                return Note.ToString();
            }
            else
            {
                return string.Format("{0}#", Note.ToString()[0]);
            }
        }
    }
}
