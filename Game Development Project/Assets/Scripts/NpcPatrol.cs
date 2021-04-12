using UnityEngine;

namespace Assets.Scripts
{
    public class NpcPatrol : MonoBehaviour
    {
        public float MovementSpeed;
        public float StartWaitTime;
        public Transform[] PatrolSpots;

        private int _currentPatrolIndex;
        private float _waitTime;
        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _currentPatrolIndex = 0;
            _waitTime = StartWaitTime;
            _animator = GetComponent<Animator>();
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
                _animator.SetBool("IsWalking", false);
                _waitTime -= Time.deltaTime;
            }
        }

        /// <summary>
        /// Calculates the new position and rotation values for the current npc according
        /// to the specified patrol target and starts the walking animation state.
        /// </summary>
        /// <param name="patrolTarget">The patrol target.</param>
        private void DoNpcTranslation(Vector3 patrolTarget)
        {
            _animator.SetBool("IsWalking", true);

            var maxDistance = MovementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, patrolTarget, maxDistance);

            var targetRotation = Quaternion.LookRotation(patrolTarget - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, maxDistance);
        }
    }
}
