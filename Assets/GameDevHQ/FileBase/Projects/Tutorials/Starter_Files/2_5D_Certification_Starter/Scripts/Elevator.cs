using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private int _status = 0; //0 = not called, 1 = going down, 2 = going up
    [SerializeField]
    private List<Transform> _floorList;
    private int _currentTarget;
    [SerializeField]
    private float _speed = 4;
    private bool _reverse;
    private bool _targetReached;

    private void FixedUpdate()
    {
        if (_floorList.Count > 0 && _floorList[_currentTarget] != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _floorList[_currentTarget].position, _speed * Time.deltaTime);
            if (transform.position == _floorList[_currentTarget].position && _targetReached == false)
            {
                _targetReached = true;
                StartCoroutine(PauseAtFloor());
                if (!_reverse)
                {
                    _currentTarget++;
                }
                else
                {
                    _currentTarget--;
                }
                if (_currentTarget == _floorList.Count - 1)
                {
                    _reverse = true;
                }
                else if (_currentTarget == 0)
                {
                    _reverse = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

    private IEnumerator PauseAtFloor()
    {
        yield return new WaitForSeconds(5f);
        _targetReached = false;
    }
}
