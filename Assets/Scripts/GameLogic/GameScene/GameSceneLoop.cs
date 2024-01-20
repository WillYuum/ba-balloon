using UnityEngine;
using GameloopCore;
using PrefabManagerTool;
using System.Collections.Generic;

class GameSceneLoop : GameloopBehavior
{
    private BehaviorUpdater _behaviorUpdater;

    private ChallengeDirector _challengeDirector;


    private GameUntilLoseTimer _untilLoseTimer;
    private AirBalloon _airBalloon;

    private float _windSpeed = 0.3f;
    protected override void OnPlay()
    {
        print("GameSceneLoop OnPlay");

        _behaviorUpdater = BehaviorUpdater.Create("WindBehaviorUpdater");


        float startingTimer = 60.0f;
        var gameScreenConnection = GameUI.instance.GetScreen<GameScreen>().CreateConnection<ConnectTimerWithUI>();

        _untilLoseTimer = new GameUntilLoseTimer(startingTimer, gameScreenConnection);



        _airBalloon = GameObject.Find("AirBalloon").GetComponent<AirBalloon>();

        _challengeDirector = GameObject.Find("ChallengeDirector").GetComponent<ChallengeDirector>();
        _challengeDirector.StartChallenge(_airBalloon.gameObject);
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
            PrefabManager.instance.ButterfliesPrefab.CreateGameObject(mousePosition, Quaternion.identity);
        }
#endif



        _untilLoseTimer.UpdateTimer();
        if (_untilLoseTimer.IsTimerDone())
        {
            print("GameSceneLoop OnLoopUpdate: Timer done");
            End();
        }
    }

    protected override void OnToggle(bool toActive)
    {

    }

    protected override void OnEnd()
    {
        //Need to show how many butterflies were caught
        //Show Time ended visuals
    }

    protected override void OnResetLoopProps()
    {

    }



    private GameObject SpawnWind(Vector3 spawnPosition, Vector3 windDirection)
    {
        GameObject spawnedWind = PrefabManager.instance.WindPrefab.CreateGameObject(spawnPosition, Quaternion.identity);

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

    protected override void InitDebuggerHandler(List<DebuggerHandlerData> debuggerData)
    {
        TextMesh CreateTextIn3DSpace(string text, Vector3 position, float fontScale = .25f)
        {
            TextMesh textMesh = new GameObject("textMesh").AddComponent<TextMesh>();
            textMesh.transform.position = position;
            textMesh.text = text;
            textMesh.fontSize = 20;
            textMesh.transform.localScale = Vector3.one * fontScale;
            textMesh.color = Color.black;
            textMesh.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");

            return textMesh;
        }

        TextMesh balloonDir = CreateTextIn3DSpace("Balloon Direction", Vector3.zero);


        AirBalloonFloatController airBalloonFloatController = _airBalloon.GetComponent<AirBalloonFloatController>();


        debuggerData.Add(new DebuggerHandlerData()
        {
            action = () =>
            {
                balloonDir.transform.position = _airBalloon.transform.position;
                balloonDir.text = "Balloon Direction" + airBalloonFloatController.MoveDirection.ToString();
            }
        });


    }

}


public class GameUntilLoseTimer
{
    public float StartingTimer { get; private set; } = 0.0f;
    public float CurrentTime { get; private set; } = 0.0f;
    private ConnectTimerWithUI _connectionWithUI;

    public GameUntilLoseTimer(float startingTimer, ConnectTimerWithUI connectTimerWithUI)
    {
        StartingTimer = startingTimer;
        CurrentTime = startingTimer;
        _connectionWithUI = connectTimerWithUI;
    }

    public void UpdateTimer()
    {
        CurrentTime -= Time.deltaTime;
        _connectionWithUI.UpdateTimer(CurrentTime);
    }

    public void ResetTimer()
    {
        CurrentTime = StartingTimer;
        _connectionWithUI.UpdateTimer(CurrentTime);
    }

    public bool IsTimerDone()
    {
        return CurrentTime <= 0.0f;
    }
}