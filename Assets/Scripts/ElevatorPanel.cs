using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    private int elevatorCost = 8;
    [SerializeField]
    private MeshRenderer _buttonMeshRenderer;
    private int _coinsCollected;
    private bool _playerPresent;
    private bool _elevatorCalled;
    [SerializeField]
    private Elevator _elevator;

    private void Update()
    {
        if (_playerPresent == true && Input.GetKeyDown(KeyCode.E) && _coinsCollected >= elevatorCost)
        {
            if (_elevatorCalled == false)
            {
                _buttonMeshRenderer.material.color = Color.blue;
                _elevatorCalled = true;
            }
            else
            {
                _buttonMeshRenderer.material.color = Color.red;
                _elevatorCalled = false;
            }
            
            _elevator.CallElevator();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _coinsCollected = other.GetComponent<Player>().CoinCount();
            _playerPresent = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerPresent = false;
        }
    }
}
