using UnityEngine;

namespace GuessTheNote
{
    public abstract class PlayableBase : MonoBehaviour
    {
        public System.Action OnInitialized;
        [HideInInspector] public GuessableBase CorrectGuessable;
    }
}
