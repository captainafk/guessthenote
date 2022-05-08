using System;
using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    public abstract class GuessableBase : ScriptableObject, IEquatable<GuessableBase>
    {
        [Header("Guessable Config")]
        [SerializeField] protected EInstruments _instrument;
        [SerializeField] private ESounds _sound;
        [SerializeField] private List<AudioClip> _audioClips;

        public EInstruments Instrument => _instrument;
        public ESounds Sound => _sound;
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
                   Sound == other.Sound;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Instrument, Sound);
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
