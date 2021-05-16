using UnityEngine;

namespace Assets.Scripts.MiniGames.Cake
{
    /// <summary>
    /// A class that stores an <see cref="Ingredient"/> enum. This class
    /// can then be serialized in the Unity editor as a separate component.
    /// </summary>
    public class IngredientComponent : MonoBehaviour
    {
        public Ingredient Ingredient;
    }
}
