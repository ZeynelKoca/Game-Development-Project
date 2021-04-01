using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Settings : MonoBehaviour
    {
        public GameObject SettingsPanel;
        public Slider VolumeSlider;
        public Slider BrightnessSlider;
        public Toggle FullscreenToggle;

        public static float VolumeSetting => PlayerPrefs.GetFloat("SoundVolume", 0.8f);

        public static float BrightnessSetting => PlayerPrefs.GetFloat("Brightness", 0.9f);

        public static bool FullscreenSetting => PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        // Start is called before the first frame update
        void Start()
        {
            VolumeSlider.value = VolumeSetting;
            BrightnessSlider.value = BrightnessSetting;
            FullscreenToggle.isOn = FullscreenSetting;
            Screen.fullScreen = FullscreenSetting;
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
        }

        public void SetBrightnessSetting()
        {
            PlayerPrefs.SetFloat("Brightness", BrightnessSlider.value);
        }

        public void SetFullscreenSetting()
        {
            PlayerPrefs.SetInt("Fullscreen", FullscreenToggle.isOn ? 1 : 0);
        }
    }
}