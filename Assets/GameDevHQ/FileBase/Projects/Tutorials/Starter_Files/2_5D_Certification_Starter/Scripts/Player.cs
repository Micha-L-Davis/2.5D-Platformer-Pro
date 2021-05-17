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
    float _speed = 8;
    [SerializeField]
    float _gravity = -0.25f;
    Vector3 _direction;
    Vector3 _velocity;
    [SerializeField]
    float _jumpHeight = 4;
    float _yVelocity;
    CharacterController _controller;
    Animator _anim;

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
                _yVelocity += _jumpHeight;
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
        
        //if grounded
        //calculate movement direciton based on user inputs
        //
        //if jump
        //adjust jump height
        //
        //move
    }
}
