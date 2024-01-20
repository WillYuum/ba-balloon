using UnityEngine;
using PrefabManagerTool.Configs;
using Utils.GenericSingletons;

namespace PrefabManagerTool
{

    public class PrefabManager : MonoBehaviourSingleton<PrefabManager>
    {
        [SerializeField] private PrefabConfig _enemyPrefab;
        [SerializeField] public PrefabConfig WindPrefab;
        [SerializeField] public PrefabConfig ButterfliesPrefab;
    }
}