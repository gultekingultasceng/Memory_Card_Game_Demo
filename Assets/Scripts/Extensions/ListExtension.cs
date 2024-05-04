using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace MCG.Core.Extensions
{
    public static class ListExtension
    {

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}