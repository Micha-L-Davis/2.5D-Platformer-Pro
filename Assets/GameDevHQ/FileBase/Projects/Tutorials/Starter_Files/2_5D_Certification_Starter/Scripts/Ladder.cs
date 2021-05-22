using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    bool _playerPresent;
    Player _player;
    [SerializeField]
    Transform _startPos, _endPos;

    private void Update()
    {
        if (_playerPresent && Input.GetKeyDown(KeyCode.E))
        {
            _player.OnLadder(_startPos.position, this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" ) 
        {
            _player = other.GetComponent<Player>();
            if (_player != null && !_player.onLadder)
            {
                _playerPresent = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && _player.onLadder)
        {
            //_player.onLadder = false;
        }
    }

    public Vector3 GetEndPos()
    {
        return _endPos.position;
    }
}
