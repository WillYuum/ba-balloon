using UnityEngine;
using GameloopCore;
// using PrefabManager = PrefabManager.PrefabManager;

class GameSceneLoop : GameloopBehavior
{
    private BehaviorUpdater _behaviorUpdater;

    private float _windSpeed = 0.3f;
    protected override void OnPlay()
    {
        print("GameSceneLoop OnPlay");

        _behaviorUpdater = BehaviorUpdater.Create("WindBehaviorUpdater");
    }

    protected override void OnLoopUpdate()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnWind(mousePosition);
        }
#endif

    }

    protected override void OnToggle(bool toActive)
    {

    }

    protected override void OnEnd()
    {

    }

    protected override void OnResetLoopProps()
    {

    }



    private GameObject SpawnWind(Vector2 position)
    {
        Vector3 spawnPosition = position;
        GameObject spawnedWind = PrefabManager.PrefabManager.instance.WindPrefab.CreateGameObject(spawnPosition, Quaternion.identity);

        Vector3 windDirection = spawnPosition.x > 0 ? Vector2.left : Vector2.right;
        spawnedWind.GetComponent<WindVisuals>().SetWindDirection(windDirection);

        _behaviorUpdater.AddBehavioral(new BehavioralDataWithTimer()
        {
            DurationOfBehavior = 5.0f,
            UpdateBehavior = () =>
            {
                spawnedWind.transform.position += _windSpeed * Time.deltaTime * windDirection;
            },
            OnBehaviorEnd = () =>
            {
                Destroy(spawnedWind);
            }
        });

        return spawnedWind;
    }
}