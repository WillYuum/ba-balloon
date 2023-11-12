using UnityEngine;

public class AirBalloon : MonoBehaviour
{

    [SerializeField] private Transform _centerOfAirBalloon;

    private AirBalloonFloatController airBalloonFloatController;

    void Start()
    {
        airBalloonFloatController = GetComponent<AirBalloonFloatController>();
    }


    void Update()
    {
        UpdateAirBalloonAngle();
    }


    private void UpdateAirBalloonAngle()
    {
        float angle = airBalloonFloatController.AirBalloonTiltAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Transform GetCenterOfAirBalloon()
    {
        return _centerOfAirBalloon;
    }
}
