using UnityEngine;

public class AirBalloonController : MonoBehaviour
{
    [SerializeField] private float _ascentForce = 5f;     // The force applied when ascending
    [SerializeField] private float _descentForce = 2f;    // The force applied when descending
    [SerializeField] private float _maxAscentSpeed = 5f;  // Maximum ascent speed
    [SerializeField] private float _damping = 0.5f;       // Damping factor for reducing momentum when not pressing space

    private Rigidbody2D _rb;
    private bool _isAscending = false;

    void Awake()
    {
        // Get the Rigidbody component
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
}
