using System;
using System.Collections;
using Assets.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Npc
{
    public class InteractableObject : MonoBehaviour
    {
        public static bool IsDialogShowing;

        public NpcType NpcType;
        public NpcType NextQuestNpcType;
        public Animator[] AchievementAnimators;
        public Camera Camera;
        public TextMeshPro InteractText;
        public Text UiText;
        public string[] InitialDialog;
        public string[] MiniGameAchievedDialog;
        public string[] FinishedDialog;

        private AudioSource _achievementAudioSource;
        private string[] _currentDialogText;
        private int _currentDialogIndex;
        private bool _dialogInitialized;

        public bool Interactable { get; set; }

        public bool DialogDone { get; private set; }

        void Start()
        {
            _achievementAudioSource = GetComponent<AudioSource>();

            UpdateSfxVolume(null, null);
            SubscribeToExternalEvents();
        }

        void OnDestroy()
        {
            UnsubscribeFromExternalEvents();
        }

        /// <summary>
        /// Subscribes to all external events.
        /// </summary>
        private void SubscribeToExternalEvents()
        {
            Settings.OnVolumeChanged += UpdateSfxVolume;
        }

        /// <summary>
        /// Unsubscribes from all external events.
        /// </summary>
        private void UnsubscribeFromExternalEvents()
        {
            Settings.OnVolumeChanged -= UpdateSfxVolume;
        }

        /// <summary>
        /// Updates the volume of achievement sound effect
        /// according to the player's volume setting.
        /// </summary>
        private void UpdateSfxVolume(object sender, EventArgs e)
        {
            _achievementAudioSource.volume = Settings.VolumeSetting;
        }

        /// <summary>
        /// Sets the proper sentence(s) of the dialog on the UI Text.
        /// </summary>
        public void DisplayDialogSentence()
        {
            _currentDialogIndex++;
            DialogDone = _currentDialogIndex == _currentDialogText.Length;

            if (DialogDone)
            {
                IsDialogShowing = false;
                _dialogInitialized = false;
                return;
            }

            UiText.text = _currentDialogText[_currentDialogIndex];
        }

        /// <summary>
        /// Initializes the proper settings in order to start the dialog
        /// of the current object and tries to display the first dialog text.
        /// </summary>
        private void InitGlobalDialogSettings()
        {
            _currentDialogIndex = -1;
            _dialogInitialized = true;
            DialogDone = false;
            IsDialogShowing = true;
            if (_currentDialogText.Length > 0)
            {
                DisplayDialogSentence();
            }
        }

        /// <summary>
        /// Starts the dialog of the current object by using the
        /// sentences specified at <see cref="InitialDialog"/>.
        /// </summary>
        public void StartInitialDialog()
        {
            if (!_dialogInitialized)
            {
                _currentDialogText = InitialDialog;
                InitGlobalDialogSettings();
            }
        }

        /// <summary>
        /// Starts the dialog of the current object by using the
        /// sentences specified at <see cref="MiniGameAchievedDialog"/>.
        /// </summary>
        public void StartMiniGameAchievedDialog()
        {
            if (!_dialogInitialized)
            {
                _currentDialogText = MiniGameAchievedDialog;
                InitGlobalDialogSettings();
            }
        }

        /// <summary>
        /// Starts the dialog of the current object by using the
        /// sentences specified at <see cref="FinishedDialog"/>.
        /// </summary>
        public void StartFinishedDialog()
        {
            if (!_dialogInitialized)
            {
                _currentDialogText = FinishedDialog;
                InitGlobalDialogSettings();
            }
        }

        /// <summary>
        /// Checks whether the current Npc has an active quest
        /// for the player to finish, according to the <see cref="NpcType"/>.
        /// </summary>
        /// <returns>True if the npc has an unfinished quest, false otherwise.</returns>
        public bool HasActiveQuest()
        {
            switch (NpcType)
            {
                case NpcType.Panda:
                    return !AchievementsManager.Instance.PandaAchieved;
                case NpcType.Bear:
                    return !AchievementsManager.Instance.BearAchieved;
                case NpcType.Bird:
                    return !AchievementsManager.Instance.BirdAchieved;
                case NpcType.Dog:
                    return !AchievementsManager.Instance.DogAchieved;
                case NpcType.Elephant:
                    return !AchievementsManager.Instance.ElephantAchieved;
                case NpcType.Monkey:
                    return !AchievementsManager.Instance.MonkeyAchieved;
                case NpcType.Penguin:
                    return !AchievementsManager.Instance.PenguinAchieved;
                case NpcType.Squirrel:
                    return !AchievementsManager.Instance.SquirrelAchieved;
                case NpcType.Crocodile:
                    return !AchievementsManager.Instance.CrocodileAchieved;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Starts the achievement animation for all animators
        /// in <see cref="AchievementAnimators"/> and their SFX.
        /// </summary>
        public void StartAchievementBadgeAnimation()
        {
            float totalWaitTime = 0.5f;

            foreach (var achievement in AchievementAnimators)
            {
                StartCoroutine(DoBadgeAnimation(achievement, totalWaitTime));
                StartCoroutine(DoAchievementSound(totalWaitTime + 0.15f));

                totalWaitTime += 2.5f;
            }
        }

        private IEnumerator DoBadgeAnimation(Animator badgeAnimator, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            badgeAnimator.SetBool("DoAnimation", true);
        }

        private IEnumerator DoAchievementSound(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            _achievementAudioSource.Play();
        }
    }
}
