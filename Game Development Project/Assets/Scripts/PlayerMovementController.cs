using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Animator Animator;

    public Transform Camera;
    public float GravityForce = 14f;
    public float MovementSpeed = 10f;
    public float SmoothTurnTime = 0.1f;

    private CharacterController _characterController;
    private float _currentTurnVelocity;
    private float _verticalVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        HandleMovement();
        HandleAnimation();
    }

    /// <summary>
    /// Handles the player movement according to user input. This also 
    /// includes the rotational movement of the player.
    /// </summary>
    private void HandleMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Change the rotation of the player according to the direction that it is facing.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentTurnVelocity, SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            // Apply the positional movement of the player.
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * MovementSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// Calculates the amount of gravitational force and
    /// applies it to the character controller.
    /// </summary>
    private void HandleGravity()
    {
        if (_characterController.isGrounded)
        {
            // Player is grounded, so don't increment the vertical velocity.
            _verticalVelocity = -GravityForce * Time.deltaTime;
            return;
        }

        _verticalVelocity -= GravityForce * Time.deltaTime;
        var gravityMovement = new Vector3(0f, _verticalVelocity, 0f);
        _characterController.Move(gravityMovement * Time.deltaTime);
    }

    /// <summary>
    /// Plays the right animation according to the current player movement state.
    /// </summary>
    private void HandleAnimation()
    {
        Animator.SetBool("IsWalking", Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0);
    }
}
