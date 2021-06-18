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

        #region BearAchievement

        public event Action OnBearAchievementChanged;
        protected virtual void BearAchievementChanged()
        {
            OnBearAchievementChanged?.Invoke();
        }

        public bool BearAchieved
        {
            get => PlayerPrefs.GetInt("BearAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("BearAchieved", value ? 1 : 0);
                BearAchievementChanged();
            }
        }

        #endregion

        #region BirdAchievement

        public event Action OnBirdAchievementChanged;
        protected virtual void BirdAchievementChanged()
        {
            OnBirdAchievementChanged?.Invoke();
        }

        public bool BirdAchieved
        {
            get => PlayerPrefs.GetInt("BirdAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("BirdAchieved", value ? 1 : 0);
                BirdAchievementChanged();
            }
        }

        #endregion

        #region DogAchievement

        public event Action OnDogAchievementChanged;
        protected virtual void DogAchievementChanged()
        {
            OnDogAchievementChanged?.Invoke();
        }

        public bool DogAchieved
        {
            get => PlayerPrefs.GetInt("DogAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("DogAchieved", value ? 1 : 0);
                DogAchievementChanged();
            }
        }

        #endregion

        #region ElephantAchievement

        public event Action OnElephantAchievementChanged;
        protected virtual void ElephantAchievementChanged()
        {
            OnElephantAchievementChanged?.Invoke();
        }

        public bool ElephantAchieved
        {
            get => PlayerPrefs.GetInt("ElephantAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("ElephantAchieved", value ? 1 : 0);
                ElephantAchievementChanged();
            }
        }

        #endregion

        #region MonkeyAchievement

        public event Action OnMonkeyAchievementChanged;
        protected virtual void MonkeyAchievementChanged()
        {
            OnMonkeyAchievementChanged?.Invoke();
        }

        public bool MonkeyAchieved
        {
            get => PlayerPrefs.GetInt("MonkeyAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("MonkeyAchieved", value ? 1 : 0);
                MonkeyAchievementChanged();
            }
        }

        #endregion

        #region PenguinAchievement

        public event Action OnPenguinAchievementChanged;
        protected virtual void PenguinAchievementChanged()
        {
            OnPenguinAchievementChanged?.Invoke();
        }

        public bool PenguinAchieved
        {
            get => PlayerPrefs.GetInt("PenguinAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("PenguinAchieved", value ? 1 : 0);
                PenguinAchievementChanged();
            }
        }

        #endregion

        #region SquirrelAchievement

        public event Action OnSquirrelAchievementChanged;
        protected virtual void SquirrelAchievementChanged()
        {
            OnSquirrelAchievementChanged?.Invoke();
        }

        public bool SquirrelAchieved
        {
            get => PlayerPrefs.GetInt("SquirrelAchieved", 0) == 1;
            set
            {
                PlayerPrefs.SetInt("SquirrelAchieved", value ? 1 : 0);
                SquirrelAchievementChanged();
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
