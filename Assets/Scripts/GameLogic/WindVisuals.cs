using UnityEngine;

public class WindVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _windSprite;

    public Vector2 WindDirection;
    public void SetWindDirection(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _windSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        WindDirection = direction;
    }
}
