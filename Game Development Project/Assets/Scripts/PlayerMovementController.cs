using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovementController : MonoBehaviour
    {
        const int MIN_IDLE_TIME = 4;
        const int MAX_IDLE_TIME = 7;

        public Animator Animator;

        public Transform Camera;
        public float GravityForce = 14f;
        public float MovementSpeed = 10f;
        public float SmoothTurnTime = 0.1f;

        private CharacterController _characterController;
        private float _currentTurnVelocity;
        private float _verticalVelocity;
        private float _idleTimeDecimal;
        private int _idleTime;

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
            var hasMovementInput = Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0;
            Animator.SetBool("IsWalking", hasMovementInput);
            if (!hasMovementInput)
            {
                // Player in Idle state
                DoIdleAnimation();
            }
        }

        /// <summary>
        /// Handles the idle animation by comparing the amount of
        /// time being idled and starting the animation for looking around.
        /// </summary>
        private void DoIdleAnimation()
        {
            _idleTimeDecimal += 1 * Time.deltaTime;
            _idleTime = Mathf.RoundToInt(_idleTimeDecimal);

            if (_idleTime > Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME))
            {
                StartCoroutine(StartLookAroundAnimation());
                return;
            }

            Animator.SetBool("IsLookingAround", false);
        }

        /// <summary>
        /// Starts the animation for the player to look around.
        /// </summary>
        private IEnumerator StartLookAroundAnimation()
        {
            Animator.SetBool("IsLookingAround", true);
            yield return new WaitForSeconds(.2f);

            // Reset wait timers and set animation state back to Idle.
            Animator.SetBool("IsLookingAround", false);
            _idleTime = 0;
            _idleTimeDecimal = 0;
        }

        /// <summary>
        /// Rotates the x-axis of the player in order to face the specified target position.
        /// </summary>
        /// <param name="targetPosition">The target position.</param>
        public void FaceDirection(Vector3 targetPosition)
        {
            var forward = new Vector3(targetPosition.x - transform.position.x, 0f, 0f);
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
