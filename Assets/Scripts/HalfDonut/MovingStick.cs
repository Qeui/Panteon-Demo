using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStick : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    private bool _stickIsPushed = false;
    private float _stickInspeed = 1f;
    private float _stickOutspeed = 2f;
    private float _startTime;
    private float _journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the sticktimer
        StartCoroutine(StickTimer());

        _journeyLength = Vector3.Distance(_startPoint, _endPoint);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Checks if stickIsPushed true
        if (_stickIsPushed)
        {
            // If it is, then stick is pushed out

            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - _startTime) * _stickOutspeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / _journeyLength;

            transform.localPosition = Vector3.Lerp(_startPoint, _endPoint, fractionOfJourney);

            
        }
        else if(!_stickIsPushed)
        {
            // If it isn't, then stick is pushed in

            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - _startTime) * _stickInspeed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / _journeyLength;

            transform.localPosition = Vector3.Lerp(_endPoint, _startPoint, fractionOfJourney);
            
        }
    }
    IEnumerator StickTimer()
    {
        // Waits random amount of time between 2-5 seconds
        int _waitingTime = Random.Range(2, 6);
        yield return new WaitForSeconds(_waitingTime);
        // Then it makes the stick puhed true so in the update stick will be pushed out
        _startTime = Time.time;
        _stickIsPushed = true;
        // Then it waits for 1 second and makes the stick pushed false so in the update stick will be pushed in
        yield return new WaitForSeconds(1);
        _startTime = Time.time;
        _stickIsPushed = false;
        // Then it calls itself to reate a loop
        StartCoroutine(StickTimer());
    }
}
