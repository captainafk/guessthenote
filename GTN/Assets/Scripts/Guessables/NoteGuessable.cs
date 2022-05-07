using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    [CreateAssetMenu(fileName = "Note", menuName = "ScriptableObjects/Note")]
    public class NoteGuessable : GuessableBase
    {
        [Header("Note Config")]
        [SerializeField] private ENotes _note;
        [SerializeField] private List<AudioClip> _audioClips;

        public ENotes Note => _note;
        public List<AudioClip> AudioClips => _audioClips;

        public override string ToString()
        {
            if (_note.ToString().Length == 1)
            {
                return _note.ToString();
            }
            else
            {
                return string.Format("{0}#", _note.ToString()[0]);
            }
        }
    }
}
