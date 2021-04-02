using UnityEngine;

namespace Assets.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _backgroundAudio;

        void Awake()
        {
            DontDestroyOnLoad(this);
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
            _backgroundAudio.volume = PauseMenu.GamePausedState ? 0.3f : 1f;
        }
    }
}
