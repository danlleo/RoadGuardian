using UnityEngine;

namespace Content.Global.Scripts
{
    public static class Vector3Extension
    {
        public static float SqrMagnitudeTo(this Vector3 from, Vector3 to) 
            => Vector3.SqrMagnitude(to - from);
    }
}