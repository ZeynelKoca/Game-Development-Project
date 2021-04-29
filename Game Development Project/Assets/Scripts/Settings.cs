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
        public Slider SensitivitySlider;
        public Toggle FullscreenToggle;
        public Dropdown ResolutionsDropdown;
        public AudioMixer AudioMixer;

        public static event EventHandler OnMouseSensitivityChanged;

        private Resolution[] _resolutions;

        /// <summary>
        /// Gets the player preference for the volume setting.
        /// </summary>
        public static float VolumeSetting => PlayerPrefs.GetFloat("SoundVolume", 0.4f);

        /// <summary>
        /// Gets the player preference for the fullscreen setting.
        /// </summary>
        public static bool FullscreenSetting => PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        /// <summary>
        /// Gets the player preference for the resolution setting.
        /// </summary>
        public static int ResolutionSetting => PlayerPrefs.GetInt("Resolution", -1);

        /// <summary>
        /// Gets the player preference for the mouse sensitivity setting.
        /// </summary>
        public static float MouseSensitivitySetting => PlayerPrefs.GetFloat("MouseSensitivity", 1f);

        void Awake()
        {
            InitializeSettingsInterface();
        }

        // Start is called before the first frame update
        void Start()
        {
            InitializeGameSettings();
        }

        /// <summary>
        /// Initializes the UI objects with the currently set player preferences.
        /// </summary>
        private void InitializeSettingsInterface()
        {
            FullscreenToggle.isOn = FullscreenSetting;

            AudioMixer.SetFloat("MainVolume", Mathf.Log(VolumeSetting) * 20);
            VolumeSlider.value = VolumeSetting;

            SensitivitySlider.value = MouseSensitivitySetting;
        }

        /// <summary>
        /// Initializes the game with the currently set player preferences.
        /// </summary>
        private void InitializeGameSettings()
        {
            SetFullscreenSetting();
            SetDropdownResolutions();
            SetResolutionSetting();
            SetVolumeSetting();
            SetMouseSensitivitySetting();
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
        /// Stores the current volume setting as a player preference.
        /// </summary>
        public void SetVolumeSetting()
        {
            PlayerPrefs.SetFloat("SoundVolume", VolumeSlider.value);
            VolumeSlider.value = VolumeSetting;

            AudioMixer.SetFloat("MainVolume", Mathf.Log(VolumeSetting) * 20);
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

        /// <summary>
        /// Sets the current mouse sensitivity setting as a player preference.
        /// </summary>
        public void SetMouseSensitivitySetting()
        {
            PlayerPrefs.SetFloat("MouseSensitivity", SensitivitySlider.value);
            SensitivitySlider.value = MouseSensitivitySetting;

            OnMouseSensitivityChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Activates the settings panel.
        /// </summary>
        public void ShowSettingsPanel()
        {
            SettingsPanel.SetActive(true);
            SettingsPanel.transform.parent.transform.SetAsLastSibling();
        }

        /// <summary>
        /// Deactivates the settings panel.
        /// </summary>
        public void CloseSettingsPanel()
        {
            SettingsPanel.SetActive(false);
        }
    }
}