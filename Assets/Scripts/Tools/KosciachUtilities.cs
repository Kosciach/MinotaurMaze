using System.Collections.Generic;
using UnityEngine;


namespace Kosciach
{
    public static class KosciachUtilities
    {
        public static Vector3 GetVectorFromAngleDeg(float angleDeg)
        {
            float angle = angleDeg * Mathf.Deg2Rad;
            return new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        }
        public static Vector3 GetVectorFromAngleRad(float angleRad)
        {
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0);
        }

        public static List<T> RemoveAllNullFromList<T>(List<T> inputList)
        {
            List<T> newList = new List<T>();

            foreach (T element in inputList)
                if (!element.Equals(null)) newList.Add(element);

            return newList;
        }
    }
}