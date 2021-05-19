using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField]
    Transform _grabPos, _standPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LedgeGrabChecker"))
        {
            Player player = other.GetComponentInParent<Player>();
            if (player != null)
            {
                player.GrabLedge(_grabPos.position, this);
            }
        }   
    }
    public Vector3 GetStandPos()
    {
        return _standPos.position;
    }
}
