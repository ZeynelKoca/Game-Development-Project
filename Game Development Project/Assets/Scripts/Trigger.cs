using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Npc;
    private bool _triggerActive = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggerActive = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggerActive = false;
        }
    }
    public void Update()
    {
        if(_triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            int numberOfChildren = Npc.transform.childCount;
            for (int i = 0; i < numberOfChildren; i++)
            {
                GameObject child = Npc.transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        if (!_triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            int numberOfChildren = Npc.transform.childCount;
            for (int i = 0; i < numberOfChildren; i++)
            {
                GameObject child = Npc.transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}

