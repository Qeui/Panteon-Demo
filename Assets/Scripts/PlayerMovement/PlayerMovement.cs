using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _swerveInputSystem;
    [SerializeField] private float _swerveSpeed = 0.5f;
    [SerializeField] private float _maxSwerveAmount = 1f;
    [SerializeField] private float _maxXamount;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    private Vector3 _playerPos;

    private void Awake()
    {
        // Gets the PlayerInput script.
        _swerveInputSystem = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Gets the swerve amount and move player acording to that.
            float swerveAmount = Time.deltaTime * _swerveSpeed * _swerveInputSystem.MoveFactorX;
            swerveAmount = Mathf.Clamp(swerveAmount, -_maxSwerveAmount, _maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);
            // Clamps the position x of the player between _minX and _maxX.
            _maxXamount = Mathf.Clamp(transform.position.x, _minX, _maxX);
            _playerPos = new Vector3(_maxXamount, transform.position.y, transform.position.z);
            transform.position = _playerPos;
        }
        
    }
}
