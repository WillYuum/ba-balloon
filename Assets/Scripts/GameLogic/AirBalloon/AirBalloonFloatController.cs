using UnityEngine;

public class AirBalloonFloatController : MonoBehaviour
{
    [SerializeField] private float _ascentForce = 5f;     // The force applied when ascending
    [SerializeField] private float _descentForce = 2f;    // The force applied when descending
    [SerializeField] private float _maxAscentSpeed = 5f;  // Maximum ascent speed
    [SerializeField] private float _damping = 0.5f;       // Damping factor for reducing momentum when not pressing space


    public Vector2 MoveDirection { get; private set; } = Vector2.zero;

    [HideInInspector] public float AirBalloonTiltAngle = 0.0f;
    private float _clampedAngle = 35.0f;
    private const float _resetAngleSpeed = 0.01f;
    private float _currentResetAngleSpeed = 0.0f;


    private Rigidbody2D _rb;
    private bool _isAscending = false;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAscending = true;
        }

        // Check for space key release
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isAscending = false;
        }


        _currentResetAngleSpeed += _resetAngleSpeed * Time.deltaTime;
        AirBalloonTiltAngle = Mathf.Lerp(AirBalloonTiltAngle, 0, _currentResetAngleSpeed);


        MoveDirection = _rb.velocity;
    }

    void FixedUpdate()
    {
        // Apply forces based on the current state (ascending or descending)
        if (_isAscending)
        {
            _rb.AddForce(Vector2.up * _ascentForce);
            // Limit the ascent speed
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, 0f, _maxAscentSpeed));
        }
        else
        {
            _rb.AddForce(Vector2.down * _descentForce);
            _rb.velocity *= 1 - _damping * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the collider is the wind collider
        if (collision.CompareTag("Wind"))
        {
            // Get the wind direction
            Vector3 windDirection = collision.GetComponent<WindVisuals>().WindDirection;
            // Apply the wind force
            _rb.AddForce(windDirection);
            LerpAirBalloonAngleWithWind(windDirection);
        }
    }

    private void LerpAirBalloonAngleWithWind(Vector2 Direction)
    {
        float angle = AirBalloonTiltAngle;
        float windAngle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;


        float windPush = 0.5f;
        angle += windAngle > 0 ? windPush : -windPush;
        angle = Mathf.Clamp(angle, -_clampedAngle, _clampedAngle);


        AirBalloonTiltAngle = angle;
        _currentResetAngleSpeed = 0;
    }
}
