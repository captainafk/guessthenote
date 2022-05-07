using System;
using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    public abstract class GuessableBase : ScriptableObject, IEquatable<GuessableBase>
    {
        [Header("Guessable Config")]
        [SerializeField] protected EInstruments _instrument;
        [SerializeField] private ENotes _note;
        [SerializeField] private List<AudioClip> _audioClips;

        public EInstruments Instrument => _instrument;
        public ENotes Note => _note;
        public List<AudioClip> AudioClips => _audioClips;

        #region Equals & GetHashCode

        public override bool Equals(object obj)
        {
            return Equals(obj as GuessableBase);
        }

        public bool Equals(GuessableBase other)
        {
            return other != null &&
                   Instrument == other.Instrument &&
                   Note == other.Note;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Instrument, Note);
        }

        public static bool operator ==(GuessableBase left, GuessableBase right)
        {
            return EqualityComparer<GuessableBase>.Default.Equals(left, right);
        }

        public static bool operator !=(GuessableBase left, GuessableBase right)
        {
            return !(left == right);
        }

        #endregion
    }
}
