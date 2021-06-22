using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDecal : MonoBehaviour
{
    public GameObject Flag;
    public Color CurrentColor;

    public Texture2D RedSquarePrefab;
    public Texture2D YellowSquarePrefab;
    public Texture2D BlueSquarePrefab;
    public Texture2D GreenSquarePrefab;
    public Texture2D PinkSquarePrefab;
    public Texture2D PurpleSquarePrefab;

    public Texture2D PurpleTrianglePrefab;
    public Texture2D RedTrianglePrefab;
    public Texture2D YellowTrianglePrefab;
    public Texture2D GreenTrianglePrefab;
    public Texture2D PinkTrianglePrefab;
    public Texture2D BlueTrianglePrefab;

    public Texture2D PurpleCirclePrefab;
    public Texture2D RedCirclePrefab;
    public Texture2D YellowCirclePrefab;
    public Texture2D GreenCirclePrefab;
    public Texture2D PinkCirclePrefab;
    public Texture2D BlueCirclePrefab;

    public Texture2D PurpleHexagonPrefab;
    public Texture2D RedHexagonPrefab;
    public Texture2D YellowHexagonPrefab;
    public Texture2D GreenHexagonPrefab;
    public Texture2D PinkHexagonPrefab;
    public Texture2D BlueHexagonPrefab;

    public Texture2D PurplePolygonPrefab;
    public Texture2D RedPolygonPrefab;
    public Texture2D YellowPolygonPrefab;
    public Texture2D GreenPolygonPrefab;
    public Texture2D PinkPolygonPrefab;
    public Texture2D BluePolygonPrefab;

    public Texture2D PurpleDiamondPrefab;
    public Texture2D RedDiamondPrefab;
    public Texture2D YellowDiamondPrefab;
    public Texture2D GreenDiamondPrefab;
    public Texture2D PinkDiamondPrefab;
    public Texture2D BlueDiamondPrefab;





    private Texture2D _currentPatern;
    private string _currentColor;
    private string _currentShape;


    private void Start()
    {
        CurrentColor = Color.red;
        _currentColor = "Red";
        _currentShape = "Square";
        _currentPatern = RedSquarePrefab;       
    }
    // Update is called once per frame
    void Update()
    {                 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                MyShaderBehavior script = hit.collider.gameObject.GetComponent<MyShaderBehavior>();
                if (null != script)
                   
                    script.PaintOn(hit.textureCoord2, _currentPatern);
            }
        }
    }
    public void SetColorRed()
    {
        _currentColor = "Red";
        CurrentColor = Color.red;
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = RedSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = RedTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = RedCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = RedDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = RedPolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = RedHexagonPrefab;
                break;
        }
    }
    public void SetColorBlue()
    {
        _currentColor = "Blue";
        CurrentColor = Color.blue;
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = BlueSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = BlueTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = BlueCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = BlueDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = BluePolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = BlueHexagonPrefab;
                break;
        }
    }
    public void SetColorYellow()
    {
        _currentColor = "Yellow";
        CurrentColor = Color.yellow;
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = YellowSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = YellowTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = YellowCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = YellowDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = YellowPolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = YellowHexagonPrefab;
                break;
        }
    }
    public void SetColorGreen()
    {
        _currentColor = "Green";
        CurrentColor = Color.green;
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = GreenSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = GreenTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = GreenCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = GreenDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = GreenPolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = GreenHexagonPrefab;
                break;
        }
    }
    public void SetColorPink()
    {
        _currentColor = "Pink";
        CurrentColor = new Color32(231, 71, 180, 255);
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = PinkSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = PinkTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = PinkCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = PinkDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = PinkPolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = PinkHexagonPrefab;
                break;
        }
    }
    public void SetColorPurple()
    {
        _currentColor = "Purple";
        CurrentColor = new Color32(128, 0, 128, 255);
        switch (_currentShape)
        {
            case "Square":
                _currentPatern = PurpleSquarePrefab;
                break;
            case "Triangle":
                _currentPatern = PurpleTrianglePrefab;
                break;
            case "Circle":
                _currentPatern = PurpleCirclePrefab;
                break;
            case "Diamond":
                _currentPatern = PurpleDiamondPrefab;
                break;
            case "Polygon":
                _currentPatern = PurplePolygonPrefab;
                break;
            case "Hexagon":
                _currentPatern = PurpleHexagonPrefab;
                break;
        }
    }
    public void ChangePatternToSquare()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedSquarePrefab;
                break;
            case "Yellow":
                _currentPatern = YellowSquarePrefab;
                break;
            case "Blue":
                _currentPatern = BlueSquarePrefab;
                break;
            case "Green":
                _currentPatern = GreenSquarePrefab;
                break;
            case"Pink":
                _currentPatern = PinkSquarePrefab;
                break;
            case "Purple":
                _currentPatern = PurpleSquarePrefab;
                break;
        }
        _currentShape = "Square";
    }
    public void ChangePatternToTriangle()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedTrianglePrefab;
                break;
            case "Yellow":
                _currentPatern = YellowTrianglePrefab;
                break;
            case "Blue":
                _currentPatern = BlueTrianglePrefab;
                break;
            case "Green":
                _currentPatern = GreenTrianglePrefab;
                break;
            case "Pink":
                _currentPatern = PinkTrianglePrefab;
                break;
            case "Purple":
                _currentPatern = PurpleTrianglePrefab;
                break;
        }
        _currentShape = "Triangle";
    }
    public void ChangePatternToCircle()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedCirclePrefab;
                break;
            case "Yellow":
                _currentPatern = YellowCirclePrefab;
                break;
            case "Blue":
                _currentPatern = BlueCirclePrefab;
                break;
            case "Green":
                _currentPatern = GreenCirclePrefab;
                break;
            case "Pink":
                _currentPatern = PinkCirclePrefab;
                break;
            case "Purple":
                _currentPatern = PurpleCirclePrefab;
                break;
        }
        _currentShape = "Circle";
    }
    public void ChangePatternToHexagon()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedHexagonPrefab;
                break;
            case "Yellow":
                _currentPatern = YellowHexagonPrefab;
                break;
            case "Blue":
                _currentPatern = BlueHexagonPrefab;
                break;
            case "Green":
                _currentPatern = GreenHexagonPrefab;
                break;
            case "Pink":
                _currentPatern = PinkHexagonPrefab;
                break;
            case "Purple":
                _currentPatern = PurpleHexagonPrefab;
                break;
        }
        _currentShape = "Hexagon";
    }
    public void ChangePatternToPolygon()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedPolygonPrefab;
                break;
            case "Yellow":
                _currentPatern = YellowPolygonPrefab;
                break;
            case "Blue":
                _currentPatern = BluePolygonPrefab;
                break;
            case "Green":
                _currentPatern = GreenPolygonPrefab;
                break;
            case "Pink":
                _currentPatern = PinkPolygonPrefab;
                break;
            case "Purple":
                _currentPatern = PurplePolygonPrefab;
                break;
        }
        _currentShape = "Polygon";
    }
    public void ChangePatternToDiamond()
    {
        switch (_currentColor)
        {
            case "Red":
                _currentPatern = RedDiamondPrefab;
                break;
            case "Yellow":
                _currentPatern = YellowDiamondPrefab;
                break;
            case "Blue":
                _currentPatern = BlueDiamondPrefab;
                break;
            case "Green":
                _currentPatern = GreenDiamondPrefab;
                break;
            case "Pink":
                _currentPatern = PinkDiamondPrefab;
                break;
            case "Purple":
                _currentPatern = PurpleDiamondPrefab;
                break;
        }
        _currentShape = "Diamond";
    }

}
