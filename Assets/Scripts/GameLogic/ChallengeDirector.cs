using System.Collections.Generic;
using UnityEngine;

public class ChallengeDirector : MonoBehaviour
{
    private List<InterestArea> _interestAreas;
    private GameObject _airBalloon;


    public void StartChallenge(GameObject airBalloon)
    {
        _interestAreas = new List<InterestArea>();


        float repeatTime = 5.45f;
        InvokeRepeating(nameof(CreateInteretPoint), 1f, repeatTime);

        _airBalloon = airBalloon;
    }


    private void CreateInteretPoint()
    {
        Vector2 positionNearBalloon = GetRandomNearBalloonPosition();

        InterestArea interestArea = new GameObject("InterestArea_" + _interestAreas.Count).AddComponent<InterestArea>();
        interestArea.StartInterestArea(positionNearBalloon);


        _interestAreas.Add(interestArea);
    }

    private Vector2 GetRandomNearBalloonPosition()
    {
        Vector2 balloonMoveDir = _airBalloon.GetComponent<AirBalloonFloatController>().MoveDirection.normalized;
        float offsetPosAfterMoveDir = Random.Range(10f, 25f);
        Vector2 balloonPosition = (Vector2)_airBalloon.transform.position;

        Vector2 randomPosition = balloonPosition + balloonMoveDir * offsetPosAfterMoveDir;

        return randomPosition;
    }
}


