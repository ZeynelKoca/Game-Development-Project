using UnityEngine;

namespace Assets.Scripts
{
    public class NpcFacePlayer : MonoBehaviour
    {
        public bool IsInteracted { get; set; }

        private Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            // Main camera is always following the player, so sprites will face the player.
            _camera = Camera.main;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (IsInteracted)
            {
                // Don't face the player when the Npc sprite is in the Interacted state.
                return;
            }

            transform.LookAt(_camera.transform);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }

        /// <summary>
        /// Rotates the x-axis of the sprite in order to face the specified target.
        /// </summary>
        /// <param name="targetTransform">The target Transform.</param>
        public void FaceDirection(Transform targetTransform)
        {
            IsInteracted = true;

            transform.LookAt(targetTransform);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
