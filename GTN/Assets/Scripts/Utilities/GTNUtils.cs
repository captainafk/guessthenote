using System.Collections.Generic;
using UnityEngine;

namespace GuessTheNote
{
    public static class GTNUtils
    {
        /// <summary>
        /// Gets a random item from the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}
