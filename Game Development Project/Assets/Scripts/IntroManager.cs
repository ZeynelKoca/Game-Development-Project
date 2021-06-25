using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RenderTexture RenderTexture;
    // Start is called before the first frame update
    void Start()
    {
        RenderTexture render = new RenderTexture(RenderTexture)
        {
            height = Screen.currentResolution.height,
            width = Screen.currentResolution.width
        };
        RawImage raw = GetComponent<RawImage>();
        raw.texture = render;
        VideoPlayer.targetTexture = render;
        VideoPlayer.SetDirectAudioVolume(0,PlayerPrefs.GetFloat("SoundVolume"));
        AudioManager.Instance.ToggleAudioSourceMute(true);
    
    }

    private void Update()
    {
        if(VideoPlayer.time >= VideoPlayer.length - 1)
        {
            CloseIntroCutScene();
        }

#if DEBUG
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseIntroCutScene();
        }
#endif
    }

    private void CloseIntroCutScene()
    {
        VideoPlayer.Pause();
        RawImage raw = GetComponent<RawImage>();
        raw.color = Color.black;
        enabled = false;
        AudioManager.Instance.ToggleAudioSourceMute(false);
        SceneManager.LoadScene("SampleScene");
    }
}
