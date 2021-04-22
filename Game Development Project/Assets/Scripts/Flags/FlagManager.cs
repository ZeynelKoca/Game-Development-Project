using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{      
    public GameObject MainFlag;
    public Mesh SquareShape;
    public Mesh TriangleShape;
    public PlaceDecal DecalPlacer;
    public List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshFilter>().sharedMesh = TriangleShape;
        GetComponent<MeshCollider>().sharedMesh = TriangleShape;
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
            Destroy(child.gameObject);
        }
        
    }
    public void SetShapeSquare()
    {
        GetComponent<Renderer>().material.SetColor("_Color", DecalPlacer.CurrentColor);

        GetComponent<MeshFilter>().sharedMesh = SquareShape;
        GetComponent<MeshCollider>().sharedMesh = SquareShape;
        transform.eulerAngles = new Vector3(-90,-90,0);
        DestroyGameobjects();
    }
    public void SetShapeTriangle()
    {
        GetComponent<Renderer>().material.SetColor("_Color", DecalPlacer.CurrentColor);

        GetComponent<MeshFilter>().sharedMesh = TriangleShape;
        GetComponent<MeshCollider>().sharedMesh = TriangleShape;
        transform.eulerAngles = new Vector3(-90, 90, 0);
        DestroyGameobjects();
    }
    public void SetColorRed()
    {
        DecalPlacer.CurrentColor = Color.red;       
    }
    public void SetColorBlue()
    {
        DecalPlacer.CurrentColor = Color.blue;
    }
    public void SetColorYellow()
    {
        DecalPlacer.CurrentColor = Color.yellow;
    }
    public void SetColorGreen()
    {
        DecalPlacer.CurrentColor = Color.green;
    }
    public void SetColorPink()
    {
        DecalPlacer.CurrentColor = new Color32(231, 71, 180, 255);
    }
    public void SetColorPurple()
    {
        DecalPlacer.CurrentColor = new Color32(128, 0, 128, 255);
    }

}
