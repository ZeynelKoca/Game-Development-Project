using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts
{
    public class AchievementsPanelController : MonoBehaviour
    {
        public GameObject AchievementsPanel;

        #region PandaAchievement

        private GameObject _pandaAchievementCross;

        #endregion

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
        }

        /// <summary>
        /// Updates the UI display of the panda achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>
        /// </summary>
        public void UpdatePandaAchievement()
        {
            _pandaAchievementCross = GameObject.FindGameObjectWithTag("PandaAchievementCross");
            _pandaAchievementCross.SetActive(!AchievementsManager.Instance.PandaAchieved);
        }
    }
}
