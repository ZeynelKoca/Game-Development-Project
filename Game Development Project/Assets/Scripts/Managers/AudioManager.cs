using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;

        private AudioSource _backgroundAudio;

        void Awake()
        {
            // Ensures that only one instance is made of this gameObject.
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _backgroundAudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            // Decrease the audio volume when the game is paused.
            _backgroundAudio.volume = PauseMenuController.GamePausedState ? 0.3f : 1f;
        }
    }
}
