using UnityEngine;

namespace Assets.Scripts
{
    public class Brightness : EffectBase
    {

        public Shader BrightnessShader;
        private Material _brightnessMaterial;
        public Material Material
        {
            get
            {
                _brightnessMaterial = CheckShaderAndCreateMaterial(BrightnessShader, _brightnessMaterial);
                return _brightnessMaterial;
            }
        }

        [Range(0.0f, 2.0f)]
        public float BrightnessAmount = 1.0f;

        void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            if (Material != null)
            {
                Material.SetFloat("_Brightness", BrightnessAmount);
                Graphics.Blit(src, dest, Material);
            }
            else
            {
                Graphics.Blit(src, dest);
            }
        }
    }
}