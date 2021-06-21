using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{      
    public GameObject MainFlag;
    public MeshCollider SquareCollider;
    public MeshCollider TriangleCollider;
    public Mesh SquareShape;
    public Mesh TriangleShape;
    public PlaceDecal DecalPlacer;
    public List<Button> buttons;
    private void Start()
    {
        SetShapeTriangle();
    }
    private void Update()
    {
        foreach (Button button in buttons)
        {
            button.image.color = DecalPlacer.CurrentColor;
        }
    }
    private void DestroyGameobjects()
    {
        for (int i = 0; i < MainFlag.transform.childCount; i++)
        {
            Transform child = MainFlag.transform.GetChild(i);
            if (child.tag == "Pattern")
            {
                Destroy(child.gameObject);
            }
        }        
    }
    public void SetShapeSquare()
    {
        MyShaderBehavior script = GetComponent<MyShaderBehavior>();
        script.ResetTexture();
        GetComponent<Renderer>().material.SetColor("_Color", DecalPlacer.CurrentColor);
        GetComponent<MeshFilter>().sharedMesh = SquareShape;
        transform.eulerAngles = new Vector3(-90,-90,0);
        DestroyGameobjects();
        SquareCollider.enabled = true;
        TriangleCollider.enabled = false;
    }
    public void SetShapeTriangle()
    {
        MyShaderBehavior script = GetComponent<MyShaderBehavior>();
        script.ResetTexture();
        GetComponent<Renderer>().material.SetColor("_Color", DecalPlacer.CurrentColor);
        GetComponent<MeshFilter>().sharedMesh = TriangleShape;
        transform.eulerAngles = new Vector3(-90, 90, 0);
        DestroyGameobjects();
        SquareCollider.enabled = false;
        TriangleCollider.enabled = true;
    }

}
