using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed, _jumpHeight, _gravity;
    Vector3 _direction, _velocity;
    float _yVelocity;

    CharacterController _controller;
    Vector3 _surfaceNormal;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");

        if(_controller.isGrounded)
        {
            _direction = new Vector3(0, 0, horizontal);
            _velocity = _direction * _speed;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
            }

        }else
        {
            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime);

    }
}
