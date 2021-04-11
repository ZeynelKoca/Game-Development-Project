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
        public Toggle FullscreenToggle;
        public Dropdown ResolutionsDropdown;
        public AudioMixer AudioMixer;

        private Resolution[] _resolutions;

        /// <summary>
        /// Gets the player preference for the volume setting.
        /// </summary>
        public static float VolumeSetting => PlayerPrefs.GetFloat("SoundVolume", -25f);

        /// <summary>
        /// Gets the player preference for the fullscreen setting.
        /// </summary>
        public static bool FullscreenSetting => PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        /// <summary>
        /// Gets the player preference for the resolution setting.
        /// </summary>
        public static int ResolutionSetting => PlayerPrefs.GetInt("Resolution", -1);

        // Start is called before the first frame update
        void Start()
        {
            VolumeSlider.value = VolumeSetting;
            FullscreenToggle.isOn = FullscreenSetting;
            SetDropdownResolutions();

            InitializeGameSettings();
        }


        /// <summary>
        /// Initializes the game with the currently set player preferences.
        /// </summary>
        private void InitializeGameSettings()
        {
            Screen.fullScreen = FullscreenSetting;

            var currentResolution = _resolutions[ResolutionSetting];
            Screen.SetResolution(currentResolution.width, currentResolution.height, FullscreenSetting);
        }

        /// <summary>
        /// Calculates the currently available resolutions on the user's hardware
        /// and displays them in the resolutions-dropdown options.
        /// </summary>
        private void SetDropdownResolutions()
        {
            _resolutions = Screen.resolutions;
            ResolutionsDropdown.ClearOptions();

            var currentResolution = new Resolution();
            var dropdownOptions = new List<string>();
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
            // Check whether a preference has been set for the resolution.
            // If not, set the current screen's resolution as preference.
            ResolutionsDropdown.value = ResolutionSetting == -1
                ? Array.IndexOf(_resolutions, currentResolution)
                : ResolutionSetting;
            ResolutionsDropdown.RefreshShownValue();
        }

        /// <summary>
        /// Activates the settings panel.
        /// </summary>
        public void ShowSettingsPanel()
        {
            SettingsPanel.SetActive(true);
        }

        /// <summary>
        /// Deactivates the settings panel.
        /// </summary>
        public void CloseSettingsPanel()
        {
            SettingsPanel.SetActive(false);
        }

        /// <summary>
        /// Stores the current volume setting as a player preference.
        /// </summary>
        public void SetVolumeSetting()
        {
            PlayerPrefs.SetFloat("SoundVolume", VolumeSlider.value);

            AudioMixer.SetFloat("MainVolume", VolumeSetting);
            VolumeSlider.value = VolumeSetting;
        }

        /// <summary>
        /// Stores the current fullscreen setting as a player preference.
        /// </summary>
        public void SetFullscreenSetting()
        {
            PlayerPrefs.SetInt("Fullscreen", FullscreenToggle.isOn ? 1 : 0);

            Screen.fullScreen = FullscreenSetting;
        }

        /// <summary>
        /// Sets the current resolution setting as a player preference.
        /// </summary>
        public void SetResolutionSetting()
        {
            PlayerPrefs.SetInt("Resolution", ResolutionsDropdown.value);

            var currentResolution = _resolutions[ResolutionSetting];
            Screen.SetResolution(currentResolution.width, currentResolution.height, FullscreenSetting);
        }
    }
}