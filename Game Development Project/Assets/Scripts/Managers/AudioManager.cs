using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        private AudioSource _audioSource;

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
            // Decrease the audio volume when the game is paused.
            _audioSource.volume = PauseMenuController.GamePausedState ? 0.5f : 1f;
        }
    }
}
