using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private FinishTrigger _trigger;

    // Update is called once per frame
    void Update()
    {
        // Check if the player touches the screen and change animation acordingly
        if (Input.GetMouseButton(0) && !_trigger._isGameFinished)
        {
            _playerAnim.SetBool("IsRunning", true);
        }
        else
        {
            _playerAnim.SetBool("IsRunning", false);
        }

    }
}
