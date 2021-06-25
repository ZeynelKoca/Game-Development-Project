using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Npc
{
    public class NpcPatrol : MonoBehaviour
    {
        public float MovementSpeed;
        public float PatrolWaitTime;
        public Transform CameraTransform;
        public Transform[] PatrolSpots;

        private NavMeshAgent _navMeshAgent;
        private Quaternion _fixedCameraRotation;
        private Vector3 _cameraDeltaPosition;

        private int _currentPatrolIndex;
        private bool _isNpcWaiting;

        // Start is called before the first frame update
        void Start()
        {
            _currentPatrolIndex = 0;
            _fixedCameraRotation = CameraTransform.rotation;
            _cameraDeltaPosition = CameraTransform.position - transform.position;

            InitNavMesh();
        }

        /// <summary>
        /// Initializes the navigation mesh of the NPC.
        /// </summary>
        private void InitNavMesh()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.speed = MovementSpeed;
        }

        void LateUpdate()
        {
            // Makes sure that the camera object doesn't get rotated.
            CameraTransform.rotation = _fixedCameraRotation;

            // Updates the camera position according to the current position of the NPC.
            CameraTransform.position = transform.position + _cameraDeltaPosition;
        }

        // Update is called once per frame
        void Update()
        {
            var patrolTarget = PatrolSpots[_currentPatrolIndex].position;

            if (Vector3.Distance(transform.position, patrolTarget) > 2f)
            {
                // Npc is still walking towards the next patrol spot, so reset the wait timer.
                _navMeshAgent.SetDestination(patrolTarget);
                return;
            }

            // Boolean check in order to prevent Coroutine call stacking.
            if (!_isNpcWaiting)
            {
                // Npc has reached a patrol target, start the wait timer for this spot.
                StartCoroutine(SetNextPatrolTarget(PatrolWaitTime));
            }
        }

        /// <summary>
        /// Pauses the Npc according to the specified amount of seconds
        /// and afterwards, sets the next patrol target.
        /// </summary>
        /// <param name="waitTime">The amount of time that the Npc will wait.</param>
        private IEnumerator SetNextPatrolTarget(float waitTime)
        {
            _isNpcWaiting = true;
            yield return new WaitForSeconds(waitTime);

            if (_currentPatrolIndex != PatrolSpots.Length - 1)
            {
                _currentPatrolIndex += 1;
            }
            else
            {
                // If the last patrol target has been reached, reset target to the first patrol spot.
                _currentPatrolIndex = 0;
            }

            _isNpcWaiting = false;
        }
    }
}
