using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts
{
    public class AchievementsPanelController : MonoBehaviour
    {
        public GameObject AchievementsPanel;

        /// <summary>
        /// Activates the achievements panel.
        /// </summary>
        public void ShowAchievementsPanel()
        {
            AchievementsPanel.SetActive(true);
            AchievementsPanel.transform.parent.transform.SetAsLastSibling();
            UpdateAllAchievements();
        }

        /// <summary>
        /// Deactivates the settings panel.
        /// </summary>
        public void CloseAchievementsPanel()
        {
            AchievementsPanel.SetActive(false);
        }

        /// <summary>
        /// Updates all achievements for the user interface.
        /// </summary>
        private void UpdateAllAchievements()
        {
            UpdatePandaAchievement();
            UpdateCrocodileAchievement();
        }

        /// <summary>
        /// Updates the UI display of the panda achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdatePandaAchievement()
        {
            var pandaAchievementCross = GameObject.FindGameObjectWithTag("PandaAchievementCross");
            pandaAchievementCross.SetActive(!AchievementsManager.Instance.PandaAchieved);
        }

        /// <summary>
        /// Updates the UI display of the crocodile achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateCrocodileAchievement()
        {
            var crocodileAchievementCross = GameObject.FindGameObjectWithTag("CrocodileAchievementCross");
            crocodileAchievementCross.SetActive(!AchievementsManager.Instance.CrocodileAchieved);
        }
    }
}
