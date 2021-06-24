using Assets.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer VideoPlayer;
    public RenderTexture RenderTexture;
    private Texture _texture;
    private bool _started;
    private AudioSource _audioSource;
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
        float test = PlayerPrefs.GetFloat("SoundVolume");
        VideoPlayer.SetDirectAudioVolume(0,PlayerPrefs.GetFloat("SoundVolume"));
        AudioManager.Instance.ToggleAudioSourceMute(true);
    
    }

    private void Update()
    {
        if(VideoPlayer.time >= VideoPlayer.length - 1)
        {
            VideoPlayer.Pause();
            RawImage raw = GetComponent<RawImage>();
            raw.color = Color.black;
            enabled = false;
            AudioManager.Instance.ToggleAudioSourceMute(false);
            SceneManager.LoadScene("SampleScene");
        }
    } 
}
