using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public InteractableObject Npc;
    public Text text;
    private GameObject Player;
    public Camera MainCamera;
    private bool _gamePaused = false;
    private bool _triggerActive = false;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
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
        if (_triggerActive && !_gamePaused)
        {
            text.text = "Press E to interact";
            text.enabled = true;
        }
        if(_triggerActive && Input.GetKeyDown(KeyCode.E) && !_gamePaused)
        {
            int numberOfChildren = Npc.Object.transform.childCount;
            text.enabled = true;
            Npc.Talk(text);
            for (int i = 0; i < numberOfChildren; i++)
            {
                GameObject child = Npc.Object.transform.GetChild(i).gameObject;
                child.GetComponent<Renderer>().material.color = Color.yellow;
                MainCamera.enabled = false;
                Npc.Camera.enabled = true;
                _gamePaused = true;
                Player.transform.position = Npc.PlayerPostion;
                Time.timeScale = 0f;
            }
        }
        if (_gamePaused && Input.GetKeyDown(KeyCode.E))
        {
            if(Npc.DialogDone)
            {

                MainCamera.enabled = true;
                Npc.Camera.enabled = false;
                text.enabled = false;
                _gamePaused = false;
                Time.timeScale = 1f;
            }
            else
            {
                Npc.Talk(text);
            }

        }
        if (!_triggerActive)
        {
            text.enabled = false;
        }
    }
}

