using UnityEngine;

namespace GuessTheNote
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<T>(true);

                return _instance;
            }
        }
    }
}