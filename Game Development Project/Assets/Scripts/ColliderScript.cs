using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public float PushPower = 2;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //Object does not have a rigidbody
        if(body == null || body.isKinematic)
        {
            return;
        }

        //Objects don't get pushed below the player
        if(hit.moveDirection.y < -0.3f)
        {
            return;
        }
        //Checks what direction the players hits the object
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        //Applies the pushpower to the direction
        body.velocity = pushDirection * PushPower;
    }

}
