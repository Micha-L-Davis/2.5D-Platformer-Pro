using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        float distance = Vector3.Distance(transform.position, other.transform.position);
        if (other.tag == "MovingBox" && distance <= .15f)
        {
            other.attachedRigidbody.isKinematic = true;
            Material mat = gameObject.GetComponentInChildren<MeshRenderer>().material;
            if (mat != null)
            {
                mat.color = Color.blue;
            }
        }
    }
    //detect moving box
    //when close to center
    //set box to kinematic
    //change pressure pad to blue
}
