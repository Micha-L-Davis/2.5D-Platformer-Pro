using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed
    //gravity
    //direction
    //jumpHeight
    [SerializeField]
    float _speed = 12f;
    [SerializeField]
    float _gravity = -7f;
    Vector3 _direction;
    Vector3 _velocity;
    [SerializeField]
    float _jumpHeight = 1.1f;
    float _yVelocity;
    CharacterController _controller;
    Animator _anim;
    bool _isGrabbing;

    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("Character Controller is null");
        }
        _anim = gameObject.GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }
    }


    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        if (_isGrabbing && Input.GetKey(KeyCode.Space))
        {
            _anim.SetTrigger("ClimbUp");
        }
        if (_controller.isGrounded)
        {
            _anim.SetBool("isGrounded", true);
            _yVelocity = 0;
            float horizInput = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(0, 0, horizInput);
            _anim.SetFloat("Speed", Mathf.Abs(horizInput));
            _velocity = _direction * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _anim.SetTrigger("Jumped");
            }
        }
        else
        {
            _anim.SetBool("isGrounded", false);
            _yVelocity += _gravity * Time.deltaTime;
        }

        if (_controller.velocity != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000 * Time.deltaTime);
        }

        _velocity.y += _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void GrabLedge(Vector3 position)
    {
        _anim.SetBool("LedgeGrab", true);
        _anim.SetFloat("Speed", 0f);
        _controller.enabled = false;
        transform.position = position;
        _isGrabbing = true;
        
    }
}
