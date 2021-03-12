using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthMovement : MonoBehaviour
{
    public float Speed = 2.5f;
    public float Distance = 5;
    float startZ;
    float addZ;

    // Start is called before the first frame update
    void Start()
    {
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        addZ = Mathf.PingPong(Time.time * Speed, Distance);
        transform.position = new Vector3(transform.position.x,transform.position.y,startZ + addZ);
        
    }
}
