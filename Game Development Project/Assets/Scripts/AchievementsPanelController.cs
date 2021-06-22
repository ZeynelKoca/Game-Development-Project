using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class AchievementsPanelController : MonoBehaviour
    {
        public GameObject AchievementsPanel;

        [Header("Panda")]
        public Image PandaEnabledBadge;
        public Image PandaDisabledBadge;

        [Header("Bear")]
        public Image BearEnabledBadge;
        public Image BearDisabledBadge;

        [Header("Bird")]
        public Image BirdEnabledBadge;
        public Image BirdDisabledBadge;

        [Header("Dog")]
        public Image DogEnabledBadge;
        public Image DogDisabledBadge;

        [Header("Elephant")]
        public Image ElephantEnabledBadge;
        public Image ElephantDisabledBadge;

        [Header("Monkey")]
        public Image MonkeyEnabledBadge;
        public Image MonkeyDisabledBadge;

        [Header("Penguin")]
        public Image PenguinEnabledBadge;
        public Image PenguinDisabledBadge;

        [Header("Squirrel")]
        public Image SquirrelEnabledBadge;
        public Image SquirrelDisabledBadge;

        [Header("Ostrich")]
        public Image OstrichEnabledBadge;
        public Image OstrichDisabledBadge;

        [Header("Crocodile")]
        public Image CrocodileEnabledBadge;
        public Image CrocodileDisabledBadge;

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
            UpdateBearAchievement();
            UpdateBirdAchievement();
            UpdateDogAchievement();
            UpdateElephantAchievement();
            UpdateMonkeyAchievement();
            UpdatePenguinAchievement();
            UpdateSquirrelAchievement();
            UpdateOstrichAchievement();
            UpdateCrocodileAchievement();
        }

        /// <summary>
        /// Updates the UI display of the panda achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdatePandaAchievement()
        {
            if (AchievementsManager.Instance.PandaAchieved)
            {
                PandaEnabledBadge.enabled = true;
                PandaDisabledBadge.enabled = false;
            }
            else
            {
                PandaEnabledBadge.enabled = false;
                PandaDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the bear achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateBearAchievement()
        {
            if (AchievementsManager.Instance.BearAchieved)
            {
                BearEnabledBadge.enabled = true;
                BearDisabledBadge.enabled = false;
            }
            else
            {
                BearEnabledBadge.enabled = false;
                BearDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the bird achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateBirdAchievement()
        {
            if (AchievementsManager.Instance.BirdAchieved)
            {
                BirdEnabledBadge.enabled = true;
                BirdDisabledBadge.enabled = false;
            }
            else
            {
                BirdEnabledBadge.enabled = false;
                BirdDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the dog achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateDogAchievement()
        {
            if (AchievementsManager.Instance.DogAchieved)
            {
                DogEnabledBadge.enabled = true;
                DogDisabledBadge.enabled = false;
            }
            else
            {
                DogEnabledBadge.enabled = false;
                DogDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the elephant achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateElephantAchievement()
        {
            if (AchievementsManager.Instance.ElephantAchieved)
            {
                ElephantEnabledBadge.enabled = true;
                ElephantDisabledBadge.enabled = false;
            }
            else
            {
                ElephantEnabledBadge.enabled = false;
                ElephantDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the monkey achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateMonkeyAchievement()
        {
            if (AchievementsManager.Instance.MonkeyAchieved)
            {
                MonkeyEnabledBadge.enabled = true;
                MonkeyDisabledBadge.enabled = false;
            }
            else
            {
                MonkeyEnabledBadge.enabled = false;
                MonkeyDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the penguin achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdatePenguinAchievement()
        {
            if (AchievementsManager.Instance.PenguinAchieved)
            {
                PenguinEnabledBadge.enabled = true;
                PenguinDisabledBadge.enabled = false;
            }
            else
            {
                PenguinEnabledBadge.enabled = false;
                PenguinDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the squirrel achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateSquirrelAchievement()
        {
            if (AchievementsManager.Instance.SquirrelAchieved)
            {
                SquirrelEnabledBadge.enabled = true;
                SquirrelDisabledBadge.enabled = false;
            }
            else
            {
                SquirrelEnabledBadge.enabled = false;
                SquirrelDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the ostrich achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateOstrichAchievement()
        {
            if (AchievementsManager.Instance.OstrichAchieved)
            {
                OstrichEnabledBadge.enabled = true;
                OstrichDisabledBadge.enabled = false;
            }
            else
            {
                OstrichEnabledBadge.enabled = false;
                OstrichDisabledBadge.enabled = true;
            }
        }

        /// <summary>
        /// Updates the UI display of the crocodile achievement according
        /// to the achieved state in <see cref="AchievementsManager"/>.
        /// </summary>
        private void UpdateCrocodileAchievement()
        {
            if (AchievementsManager.Instance.CrocodileAchieved)
            {
                CrocodileEnabledBadge.enabled = true;
                CrocodileDisabledBadge.enabled = false;
            }
            else
            {
                CrocodileEnabledBadge.enabled = false;
                CrocodileDisabledBadge.enabled = true;
            }
        }
    }
}
