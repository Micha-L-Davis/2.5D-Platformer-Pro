using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LedgeGrabChecker"))
        {
            Player player = other.GetComponentInParent<Player>();
            player.GrabLedge(new Vector3(-0.16f, 67.97f, 122.99f));
        }
    }
}
