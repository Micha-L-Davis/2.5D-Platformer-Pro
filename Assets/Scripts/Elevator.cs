using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private int _status = 0; //0 = not called, 1 = going down, 2 = going up
    [SerializeField]
    private Transform _top, _bottom;
    [SerializeField]
    private float _speed = 4;

    public void CallElevator()
    {
        if (transform.position == _top.position)
        {
            _status = 1; //going down
        }
        else if (transform.position == _bottom.position)
        {
            _status = 2; //going up
        }
    }

    private void FixedUpdate()
    {
        if (_status == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _bottom.position, _speed * Time.deltaTime);
        }
        else if (_status == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, _top.position, _speed * Time.deltaTime);
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
}
