using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _startPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.LoseLife();
            }
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                StartCoroutine(CCEnableRoutine(cc));
            }
            other.transform.position = _startPosition.position;

        }
    }
    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(.5f);
        controller.enabled = true;
    }
}
