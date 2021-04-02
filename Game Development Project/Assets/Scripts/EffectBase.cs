using UnityEngine;

namespace Assets.Scripts
{
    [ExecuteInEditMode]
    //[RequireComponent(typeof(Camera))]
    public class EffectBase : MonoBehaviour
    {
        // Called when need to create the material used by this effect
        protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
        {
            if (shader == null)
            {
                return null;
            }

            switch (shader.isSupported)
            {
                case true when material && material.shader == shader:
                    return material;
                case false:
                    return null;
                default:
                    material = new Material(shader);
                    material.hideFlags = HideFlags.DontSave;
                    return material ? material : null;
            }
        }
    }
}