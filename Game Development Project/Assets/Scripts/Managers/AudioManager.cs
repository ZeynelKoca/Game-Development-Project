using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private AudioSource _audioSource;
        private bool _checkingAudio;

        void Awake()
        {
            // Ensures that only one instance is made of this gameObject.
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StartCoroutine(CheckGamePausedState());
        }

        /// <summary>
        /// Checks whether the game is currently paused and if so,
        /// decreases the audio volume accordingly.
        /// </summary>
        private IEnumerator CheckGamePausedState()
        {
            // Check to prevent call-stacking through Couroutines.
            if (!_checkingAudio)
            {
                _checkingAudio = true;
                yield return new WaitForSeconds(2f);
                _audioSource.volume = PauseMenuController.GamePausedState ? 0.5f : 1f;
                _checkingAudio = false;
            }
        }
    }
}
