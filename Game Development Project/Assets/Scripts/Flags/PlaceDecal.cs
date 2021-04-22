using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDecal : MonoBehaviour
{
    public GameObject Flag;
    public Color CurrentColor;
    public GameObject TrianglePrefab;
    public GameObject SquarePrefab;
    public GameObject CirclePrefab;
    public GameObject HexagonPrefab;
    public GameObject PolygonPrefab;
    public GameObject DiamondPrefab;
    private GameObject _currentPatern;


    private void Start()
    {
        CurrentColor = Color.red;
        _currentPatern = TrianglePrefab;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitInfo) && hitInfo.transform.name == "MainFlag")
            {                
                SpawnDecal(hitInfo);
            }
        }
    }
    private void SpawnDecal(RaycastHit hitInfo)
    {        
        var decal = Instantiate(_currentPatern);
        decal.GetComponent<Renderer>().material.color = CurrentColor;
        decal.transform.position = hitInfo.point;
        decal.transform.forward = hitInfo.normal * -1f;
        decal.transform.parent = Flag.transform;
       
    }
    public void ChangePatternToSquare()
    {
        _currentPatern = SquarePrefab;
    }
    public void ChangePatternToTriangle()
    {
        _currentPatern = TrianglePrefab;
    }
    public void ChangePatternToCircle()
    {
        _currentPatern = CirclePrefab;  
    }
    public void ChangePatternToHexagon()
    {
        _currentPatern = HexagonPrefab;
    }
    public void ChangePatternToPolygon()
    {
        _currentPatern = PolygonPrefab;
    }
    public void ChangePatternToDiamond()
    {
        _currentPatern = DiamondPrefab;
    }
}
