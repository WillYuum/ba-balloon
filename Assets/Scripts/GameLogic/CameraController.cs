using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private AirBalloon _target;



    void Awake()
    {
        _target = GameObject.Find("AirBalloon").GetComponent<AirBalloon>();
    }
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = _target.GetCenterOfAirBalloon().position;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }

}
