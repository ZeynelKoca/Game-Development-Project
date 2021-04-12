using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class NpcTrigger : MonoBehaviour
    {
        public NpcPatrol NpcPatrol;
        public IntractableObject Npc;
        public Text Text;
        private GameObject _player;
        private bool _gamePaused;
        private bool _triggerActive;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            Npc.Camera.enabled = false;
            _gamePaused = false;
            _triggerActive = false;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _triggerActive = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _triggerActive = false;
            }
        }

        public void Update()
        {
            if (_triggerActive && !_gamePaused)
            {
                Text.text = "Press E to interact";
                Text.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Text.enabled = true;
                    _gamePaused = true;
                    Npc.Camera.enabled = true;
                    _player.transform.position = Npc.Object.transform.position + Npc.PlayerPosition;
                    NpcPatrol.FaceDirection(_player.transform.position);
                    Npc.InitDialog();
                    Time.timeScale = 0f;
                }
            }

            if (_gamePaused && Input.GetKeyDown(KeyCode.E))
            {
                if (!Npc.DialogDone)
                {
                    Npc.Talk(Text);
                }
                else
                {
                    IntractableObject.IsDialogShowing = false;
                    Npc.Camera.enabled = false;
                    Text.enabled = false;
                    _gamePaused = false;
                    Time.timeScale = 1f;
                }
            }

            if (!_triggerActive)
            {
                Text.enabled = false;
            }
        }
    }
}
