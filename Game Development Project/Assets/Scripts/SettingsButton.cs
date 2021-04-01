using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void ShowSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }
}
