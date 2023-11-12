using UnityEngine;
using GameloopCore;

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
            SpawnWind(mousePosition, Vector3.right);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SpawnWind(mousePosition, Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PrefabManager.PrefabManager.instance.ButterfliesPrefab.CreateGameObject(mousePosition, Quaternion.identity);


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



    private GameObject SpawnWind(Vector3 spawnPosition, Vector3 windDirection)
    {
        GameObject spawnedWind = PrefabManager.PrefabManager.instance.WindPrefab.CreateGameObject(spawnPosition, Quaternion.identity);

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