using UnityEngine;

namespace Assets.Scripts
{
    public class ConstantRotation : MonoBehaviour
    {
        public float X_RotationSpeed;
        public float Y_RotationSpeed;
        public float Z_RotationSpeed;

        // Update is called once per frame
        void Update()
        {
            var x = X_RotationSpeed * Time.deltaTime;
            var y = Y_RotationSpeed * Time.deltaTime;
            var z = Z_RotationSpeed * Time.deltaTime;

            transform.Rotate(x, y, z);
        }
    }
}
