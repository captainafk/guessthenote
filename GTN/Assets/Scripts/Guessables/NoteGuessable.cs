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
    }
}
