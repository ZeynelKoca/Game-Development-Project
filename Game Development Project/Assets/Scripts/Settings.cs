using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Settings : MonoBehaviour
    {
        public GameObject SettingsPanel;
        public Slider VolumeSlider;
        public Slider BrightnessSlider;
        public Brightness Brightness;
        public Toggle FullscreenToggle;
        public Dropdown ResolutionsDropdown;

        public AudioMixer AudioMixer;

        private Resolution[] _resolutions;

        public static float VolumeSetting => PlayerPrefs.GetFloat("SoundVolume", -20f);

        public static float BrightnessSetting => PlayerPrefs.GetFloat("Brightness", 1f);

        public static bool FullscreenSetting => PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        public static int ResolutionSetting => PlayerPrefs.GetInt("Resolution", -1);

        // Start is called before the first frame update
        void Start()
        {
            VolumeSlider.value = VolumeSetting;
            BrightnessSlider.value = BrightnessSetting;
            FullscreenToggle.isOn = FullscreenSetting;
            CalculateResolutions();

            InitializeGameSettings();
        }

        private void InitializeGameSettings()
        {
            Screen.fullScreen = FullscreenSetting;

            var currentResolution = _resolutions[ResolutionSetting];
            Screen.SetResolution(currentResolution.width, currentResolution.height, FullscreenSetting);
        }

        private void CalculateResolutions()
        {
            _resolutions = Screen.resolutions;
            ResolutionsDropdown.ClearOptions();

            Resolution currentResolution = new Resolution();
            List<string> dropdownOptions = new List<string>();
            foreach (var resolution in _resolutions)
            {
                dropdownOptions.Add($"{resolution.width} x {resolution.height}");

                if (resolution.height == Screen.currentResolution.height &&
                    resolution.width == Screen.currentResolution.width)
                {
                    currentResolution = resolution;
                }
            }

            ResolutionsDropdown.AddOptions(dropdownOptions);
            ResolutionsDropdown.value = ResolutionSetting == -1
                ? Array.IndexOf(_resolutions, currentResolution)
                : ResolutionSetting;
            ResolutionsDropdown.RefreshShownValue();
        }

        public void ShowSettingsPanel()
        {
            SettingsPanel.SetActive(true);
        }

        public void CloseSettingsPanel()
        {
            SettingsPanel.SetActive(false);
        }

        public void SetVolumeSetting()
        {
            PlayerPrefs.SetFloat("SoundVolume", VolumeSlider.value);

            AudioMixer.SetFloat("MainVolume", VolumeSetting);
            VolumeSlider.value = VolumeSetting;
        }

        public void SetBrightnessSetting()
        {
            PlayerPrefs.SetFloat("Brightness", BrightnessSlider.value);

            Brightness.brightness = BrightnessSetting;
        }

        public void SetFullscreenSetting()
        {
            PlayerPrefs.SetInt("Fullscreen", FullscreenToggle.isOn ? 1 : 0);

            Screen.fullScreen = FullscreenSetting;
        }

        public void SetResolutionSetting()
        {
            PlayerPrefs.SetInt("Resolution", ResolutionsDropdown.value);

            var currentResolution = _resolutions[ResolutionSetting];
            Screen.SetResolution(currentResolution.width, currentResolution.height, FullscreenSetting);
        }
    }
}