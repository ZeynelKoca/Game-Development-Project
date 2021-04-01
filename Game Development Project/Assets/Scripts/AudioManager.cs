using Assets.Scripts;
using UnityEngine;

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
        if (PauseMenu.GamePausedState)
        {
            _backgroundAudio.volume = Settings.VolumeSetting / 3;
        }
        else
        {
            _backgroundAudio.volume = Settings.VolumeSetting;
        }
    }
}
