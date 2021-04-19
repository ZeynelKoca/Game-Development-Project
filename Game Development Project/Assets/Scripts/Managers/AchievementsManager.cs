using UnityEngine;

namespace Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the achievements completed player-achievements
    /// </summary>
    /// <remarks>Achievement sprite sizes have to be <c>256x256</c></remarks>
    public class AchievementsManager : MonoBehaviour
    {
        private static AchievementsManager _instance;

        // Panda achievement
        public Sprite PandaSprite;
        public static bool PandaAchieved
        {
            get => PlayerPrefs.GetInt("PandaAchieved", 0) == 1;
            set => PlayerPrefs.SetInt("PandaAchieved", value ? 1 : 0);
        }
        
        void Awake()
        {
            CreateSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetAllAchievements();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Ensures that only one instance is made of this gameObject.
        /// </summary>
        private void CreateSingleton()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Resets all player-earned-achievements to their default state.
        /// </summary>
        public void ResetAllAchievements()
        {
            PandaAchieved = false;
        }
    }
}
