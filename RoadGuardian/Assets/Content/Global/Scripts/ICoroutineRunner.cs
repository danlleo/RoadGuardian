using System.Collections;
using UnityEngine;

namespace Content.Global.Scripts
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
        void StopCoroutine(IEnumerator enumerator);
    }
}