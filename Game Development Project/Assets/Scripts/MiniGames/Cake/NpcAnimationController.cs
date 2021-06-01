using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGames.Cake
{
    public class NpcAnimationController : MonoBehaviour
    {
        public Animator DefaultNpcAnimator;
        public Animator NpcExpressionsAnimator;
        public Sprite[] CorrectExpressionSprites;
        public Sprite[] WrongExpressionSprites;

        private Image _npcExpressionsImage;
        private int _currentCorrectExpressionIndex;
        private int _currentWrongExpressionIndex;

        public bool Initialized { get; set; }

        void Awake()
        {
            _npcExpressionsImage = GameObject.FindGameObjectWithTag("OstrichExpressions").GetComponent<Image>();
        }

        /// <summary>
        /// Enables the finished Npc sprite(s).
        /// </summary>
        public IEnumerator SetFinishedSprite()
        {
            StartCoroutine(ChangeCorrectNpcExpression());
            yield return new WaitForSeconds(0.08f);
            var finishedTextObject = GameObject.Find("GoedzoImage");
            finishedTextObject.GetComponent<Image>().enabled = true;
        }

        /// <summary>
        /// Initializes the Npc sprite expression
        /// </summary>
        /// <param name="correctIngredient">Was the correct ingredient selected?</param>
        public IEnumerator InitNpcExpression(bool correctIngredient)
        {
            DefaultNpcAnimator.SetBool("InitTransition", true);
            yield return new WaitForSeconds(0.08f);
            DisableDefaultNpcSprite();
            _npcExpressionsImage.enabled = true;
            _npcExpressionsImage.sprite = correctIngredient ? CorrectExpressionSprites[1] : WrongExpressionSprites[1];
            NpcExpressionsAnimator.SetBool("InitTransition", true);
            yield return new WaitForSeconds(0.08f);
            NpcExpressionsAnimator.SetBool("InitTransition", false);

            Initialized = true;
        }

        /// <summary>
        /// Disables the Image component of the default Npc sprite.
        /// </summary>
        private void DisableDefaultNpcSprite()
        {
            var npcObject = GameObject.FindGameObjectWithTag("DefaultOstrich");
            npcObject.GetComponent<Image>().enabled = false;
        }

        /// <summary>
        /// Changes the Npc expression based on the <see cref="correctIngredient"/>
        /// argument.
        /// </summary>
        /// <param name="correctIngredient">Was the correct ingredient selected?</param>
        public void ChangeNpcExpression(bool correctIngredient)
        {
            // Make sure the expressions object's Image component is enabled.
            Debug.Assert(_npcExpressionsImage.enabled);

            StartCoroutine(correctIngredient ? ChangeCorrectNpcExpression() : ChangeWrongNpcExpression());
        }

        /// <summary>
        /// Changes the Npc expression to one of the <c>Correct Expression</c> sprites.
        /// </summary>
        private IEnumerator ChangeCorrectNpcExpression()
        {
            NpcExpressionsAnimator.SetBool("ScaleTransition", true);
            yield return new WaitForSeconds(0.08f);
            ChangeToCorrectExpressionSprite();
            NpcExpressionsAnimator.SetBool("ScaleTransition", false);
        }

        /// <summary>
        /// Changes the Npc sprite to one of the sprites in <see cref="CorrectExpressionSprites"/>.
        /// </summary>
        private void ChangeToCorrectExpressionSprite()
        {
            if (_currentCorrectExpressionIndex == CorrectExpressionSprites.Length)
            {
                _currentCorrectExpressionIndex = 0;
            }

            _npcExpressionsImage.sprite = CorrectExpressionSprites[_currentCorrectExpressionIndex];
            _currentCorrectExpressionIndex++;
        }

        /// <summary>
        /// Changes the Npc expression to one of the <c>Wrong Expression</c> sprites.
        /// </summary>
        private IEnumerator ChangeWrongNpcExpression()
        {
            NpcExpressionsAnimator.SetBool("ScaleTransition", true);
            yield return new WaitForSeconds(0.08f);
            ChangeToWrongExpressionSprite();
            NpcExpressionsAnimator.SetBool("ScaleTransition", false);
        }

        /// <summary>
        /// Changes the Npc sprite to one of the sprites in <see cref="WrongExpressionSprites"/>.
        /// </summary>
        private void ChangeToWrongExpressionSprite()
        {
            if (_currentWrongExpressionIndex == WrongExpressionSprites.Length)
            {
                _currentWrongExpressionIndex = 0;
            }

            _npcExpressionsImage.sprite = WrongExpressionSprites[_currentWrongExpressionIndex];
            _currentWrongExpressionIndex++;
        }
    }
}
