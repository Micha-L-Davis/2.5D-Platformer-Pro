using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private Transform _currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        _currentTarget = _targetB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToA = Vector3.Distance(transform.position, _targetA.position);
        float distanceToB = Vector3.Distance(transform.position, _targetB.position);

        if (distanceToA == 0f)
        {
            _currentTarget = _targetB;
        }

        if (distanceToB == 0f)
        {
            _currentTarget = _targetA;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.gameObject.transform;
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
