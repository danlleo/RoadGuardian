using UnityEngine;

namespace Content.Features.PrefabSpawner.Scripts
{
    public interface IPrefabsFactory
    {
        GameObject Create(string prefabName);
        GameObject Create(string prefabName, Vector3 position);
    }
}