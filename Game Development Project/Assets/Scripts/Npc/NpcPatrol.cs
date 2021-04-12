using UnityEngine;

namespace Assets.Scripts.Npc
{
    public class NpcPatrol : MonoBehaviour
    {
        public float MovementSpeed;
        public float StartWaitTime;
        public Animator Animator;
        public Transform CameraTransform;
        public Transform[] PatrolSpots;

        private int _currentPatrolIndex;
        private float _waitTime;
        private Quaternion _fixedCameraRotation;
        private Vector3 _cameraDeltaPosition;

        // Start is called before the first frame update
        void Start()
        {
            _currentPatrolIndex = 0;
            _waitTime = StartWaitTime;
            _fixedCameraRotation = CameraTransform.rotation;
            _cameraDeltaPosition = CameraTransform.position - transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            var patrolTarget = PatrolSpots[_currentPatrolIndex].position;

            if (!(Vector3.Distance(transform.position, patrolTarget) < 0.2f))
            {
                // Npc is still walking towards the next patrol spot, so reset the wait timer.
                _waitTime = StartWaitTime;
                DoNpcTranslation(patrolTarget);
                return;
            }

            if (_waitTime <= 0f)
            {
                // Once the wait timer is done, move to the next patrol spot or reset it if the last patrol spot is reached.
                if (_currentPatrolIndex != PatrolSpots.Length - 1)
                {
                    _currentPatrolIndex += 1;
                }
                else
                {
                    _currentPatrolIndex = 0;
                }
            }
            else
            {
                // Target spot is reached so start the wait timer and reset walking animation state.
                Animator.SetBool("IsWalking", false);
                _waitTime -= Time.deltaTime;
            }
        }

        void LateUpdate()
        {
            // Makes sure that the camera object doesn't get rotated.
            CameraTransform.rotation = _fixedCameraRotation;

            // Updates the camera position according to the current position of the NPC.
            CameraTransform.position = transform.position + _cameraDeltaPosition;
        }

        /// <summary>
        /// Calculates the new position and rotation values for the current npc according
        /// to the specified patrol target. Also starts the walking animation state.
        /// </summary>
        /// <param name="patrolTarget">The patrol target.</param>
        private void DoNpcTranslation(Vector3 patrolTarget)
        {
            Animator.SetBool("IsWalking", true);

            var maxDistance = MovementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, patrolTarget, maxDistance);

            var targetRotation = Quaternion.LookRotation(patrolTarget - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, maxDistance);
        }

        /// <summary>
        /// Rotates the x-axis of the current npc in order to face the specified target position.
        /// </summary>
        /// <param name="targetPosition">The target position.</param>
        public void FaceDirection(Vector3 targetPosition)
        {
            var forward = new Vector3(targetPosition.x - transform.position.x, 0f, 0f);
            transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
        }
    }
}
