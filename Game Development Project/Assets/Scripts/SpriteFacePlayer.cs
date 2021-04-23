using UnityEngine;

namespace Assets.Scripts
{
    public class SpriteFacePlayer : MonoBehaviour
    {
        private Camera _camera;

        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.LookAt(_camera.transform);

            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
