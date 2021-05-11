using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _jumpHeight = 5f;
    private float _yVelocity;
    private bool _canDoubleJump = true;

    private bool _isAlive = true;

    private int _coins;
    private int _lives = 3;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        if (_controller == null)
        {
            Debug.LogError("The Character Controller is NULL");
        }
        UIManager.Instance.UpdateLives = _lives;
    }


    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, 0f);
        Vector3 velocity = direction * _speed; 

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            _yVelocity += _gravity;
            if (_canDoubleJump == true && Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity += _jumpHeight;
                _canDoubleJump = false;
            }
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins()
    {
        ++_coins;
        UIManager.Instance.UpdateCoins = _coins;
    }
    public void LoseLife()
    {
        --_lives;
        UIManager.Instance.UpdateLives = _lives;
        if (_lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
