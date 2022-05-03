using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    public abstract class GuessableBase : ScriptableObject
    {
        [Header("Guessable Config")]
        [SerializeField] protected EInstruments _instrument;

        public EInstruments Instrument => _instrument;
    }
}
