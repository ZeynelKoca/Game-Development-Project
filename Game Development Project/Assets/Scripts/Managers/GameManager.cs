using Assets.Scripts.Npc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        void Awake()
        {
            CreateSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                InitNpcs();
            }
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
        /// Initializes the proper variables and states for
        /// all the NPCs in the game.
        /// </summary>
        private void InitNpcs()
        {
            if (!AchievementsManager.PandaAchieved)
            {
                var panda = GameObject.FindGameObjectWithTag("PandaNPC");
                ActivateNpc(panda);
            }
            // TODO: else if statements for every other npc in the game in order of activation.
        }

        /// <summary>
        /// Activates an NPC by setting its GameObject's
        /// interactibility to <c>true</c>.
        /// </summary>
        /// <param name="npcGameObject"></param>
        private void ActivateNpc(GameObject npcGameObject)
        {
            var interactableObject = npcGameObject.GetComponent<InteractableObject>();
            interactableObject.Interactable = true;
        }
    }
}
