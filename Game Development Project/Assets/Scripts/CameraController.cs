using System;
using Cinemachine;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private CinemachineFreeLook _cinemachineFreeLook;

        // Start is called before the first frame update
        void Start()
        {
            _cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed *= Settings.MouseSensitivitySetting;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed *= Settings.MouseSensitivitySetting;
            Settings.OnMouseSensitivityChanged += SetMouseSensitivity;
        }

        /// <summary>
        /// Updates the speed value of the X and Y axis according
        /// to the mouse sensitivity setting.
        /// </summary>
        private void SetMouseSensitivity(object sender, EventArgs e)
        {
            // Multiply sensitivity value by the default speed values of the CinemachineFreeLook component.
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 200f * Settings.MouseSensitivitySetting;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 1.4f * Settings.MouseSensitivitySetting;
        }
    }
}
