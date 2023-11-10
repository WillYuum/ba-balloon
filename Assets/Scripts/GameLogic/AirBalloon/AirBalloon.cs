using UnityEngine;

public class AirBalloon : MonoBehaviour
{

    [SerializeField] private Transform _centerOfAirBalloon;



    public Transform GetCenterOfAirBalloon()
    {
        return _centerOfAirBalloon;
    }
}
