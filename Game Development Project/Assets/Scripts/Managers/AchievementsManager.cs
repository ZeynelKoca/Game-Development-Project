using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the achievements completed player-achievements
    /// </summary>
    public class AchievementsManager : MonoBehaviour
    {
        public static AchievementsManager Instance;

        #region PandaAchievement

        public event Action OnPandaAchievementChanged;
        protected virtual void PandaAchievementChanged()
        {
            OnPandaAchievementChanged?.Invoke();
        }

        public bool PandaAchieved
        {
            get => PlayerPrefs.GetInt("PandaAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("PandaAchieved", value ? 1 : 0);
                PandaAchievementChanged();
            }
        }

        #endregion

        #region CrocodileAchievement

        public event Action OnCrocodileAchievementChanged;
        protected virtual void CrocodileAchievementChanged()
        {
            OnCrocodileAchievementChanged?.Invoke();
        }

        public bool CrocodileAchieved
        {
            get => PlayerPrefs.GetInt("CrocodileAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("CrocodileAchieved", value ? 1 : 0);
                CrocodileAchievementChanged();
            }
        }

        #endregion

        void Awake()
        {
            CreateSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetAllAchievements();
        }

        /// <summary>
        /// Ensures that only one instance is made of this gameObject.
        /// </summary>
        private void CreateSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Resets all player-earned-achievements to their default state.
        /// </summary>
        public void ResetAllAchievements()
        {
            PandaAchieved = false;
            CrocodileAchieved = false;
        }
    }
}
