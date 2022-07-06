using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _cameraFinishPos;
    [SerializeField] private Transform _cameraFinishRot;
    public bool _isGameFinished = false;
    [SerializeField] private Vector3 _speed;

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is finished or not
        if (_isGameFinished)
        {
            // If it is, it changes the camera position and rotation to look at the wall
            _camera.position = Vector3.SmoothDamp(_camera.position, _cameraFinishPos, ref _speed, 0.5f);
            _camera.rotation = Quaternion.RotateTowards(_camera.rotation,_cameraFinishRot.rotation, 0.2f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the player has entered to the finish
        if (other.CompareTag("Player"))
        {
            // If it is, it disables the player movement and switchs isGameFinished to true 
            _player.GetComponent<ForwardFOrce>().enabled = false;
            _player.GetComponent<PlayerInput>().enabled = false;
            _player.GetComponent<PlayerMovement>().enabled = false;
            _isGameFinished = true;
        }

    }
}
