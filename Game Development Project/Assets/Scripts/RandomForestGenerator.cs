using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts
{
    public class RandomForestGenerator : MonoBehaviour
    {
        public int ForestSize = 25; // Overall size of the forest (a square of forestSize X forestSize).
        public int ElementSpacing = 3; // The spacing between element placements. Basically grid size.
        public bool Elevated;

        public Element[] Elements;

        private void Start()
        {
            int xPos = (int)gameObject.transform.localPosition.x;
            int zPos = (int)gameObject.transform.localPosition.z;
            float yPos = Elevated ? 0.4f : -0.2f;

            // Loop through all the positions within our forest boundary.
            for (int x = xPos; x < ForestSize + xPos; x += ElementSpacing)
            {
                for (int z = zPos; z < ForestSize + zPos; z += ElementSpacing)
                {
                    // For each position, loop through each element...
                    for (int i = 0; i < Elements.Length; i++)
                    {
                        // Get the current element.
                        Element element = Elements[i];

                        // Check if the element can be placed.
                        if (element.CanPlace())
                        {
                            // Add random elements to element placement.
                            Vector3 position = new Vector3(x, yPos, z);
                            Vector3 offset = new Vector3(Random.Range(-0.75f, 0.75f), yPos, Random.Range(-0.75f, 0.75f));
                            Vector3 rotation = new Vector3(Random.Range(0, 5f), Random.Range(0, 360f), Random.Range(0, 5f));
                            Vector3 scale = Vector3.one * Random.Range(element.MinScale, element.MaxScale);

                            // Instantiate and place element in world.
                            GameObject newElement = Instantiate(element.GetRandom());
                            newElement.transform.SetParent(transform);
                            newElement.transform.position = position + offset;
                            newElement.transform.eulerAngles = rotation;
                            newElement.transform.localScale = scale;

                            var mesh = newElement.GetComponentInChildren<MeshRenderer>();
                            if (mesh != null)
                            {
                                mesh.shadowCastingMode = !element.UseShadows ? ShadowCastingMode.Off : ShadowCastingMode.On;
                            }


                            newElement.isStatic = true;

                            // Break out of this for loop to ensure we don't place another element at this position.
                            break;
                        }
                    }
                }
            }
        }
    }

    [System.Serializable]
    public class Element
    {
        public string Name;
        public bool UseShadows;
        [Range(1, 10)]
        public int Density;
        [Range(0.1f, 1.0f)]
        public float MinScale;
        [Range(0.1f, 1.0f)]
        public float MaxScale;


        public GameObject[] Prefabs;

        public bool CanPlace()
        {
            // Validation check to see if element can be placed. More detailed calculations can go here, such as checking perlin noise.
            return Random.Range(0, 10) < Density;
        }

        public GameObject GetRandom()
        {
            // Return a random GameObject prefab from the prefabs array.
            return Prefabs[Random.Range(0, Prefabs.Length)];
        }

    }
}