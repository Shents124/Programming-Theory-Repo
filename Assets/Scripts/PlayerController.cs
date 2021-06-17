using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public LayerMask ground;
    
    private float _horizontalInput;

    private float _verticalInput;

    private readonly float speedMultiplier = 1.5f;
    private bool _isSpeedUp = false;
    
    private float maxDistance = 25f;
    
    private Rigidbody _playerRb;
    
    // Start is called before the first frame update
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal") * speed;
        _verticalInput = Input.GetAxis("Vertical") * speed;

        // Increase speed when hold LeftShift key
        if (Input.GetKey(KeyCode.LeftShift) && !_isSpeedUp )
        {
            speed *= speedMultiplier;
            _isSpeedUp = true;
        }

        // Set speed to default when don't hold LeftShift key any more
        if (Input.GetKeyUp(KeyCode.LeftShift) && _isSpeedUp)
        {
            speed /= speedMultiplier;
            _isSpeedUp = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
        _playerRb.velocity = new Vector3(_horizontalInput * Time.deltaTime, _playerRb.velocity.y,
            _verticalInput * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, ground))
        {
            // Player look at mouse position
            transform.LookAt(hit.point);
        }
    }
}
