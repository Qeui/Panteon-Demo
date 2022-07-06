using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    [SerializeField] private Transform[] _opponents;
    [SerializeField] private Transform _player;
    [SerializeField] private int _count;
    [SerializeField] private int _playerRank;
    private bool _gameEnded = false;
    public int LastRank;

    private void FixedUpdate()
    {
        // This counts the opponents in front of the player
        _count = 0;
        foreach (Transform _opponent in _opponents)
        {

            if (_opponent.position.z > _player.position.z)
            {
                _count++;
            }
        }
        // Adds our player to the count
        _playerRank = _count + 1;
        // This checks if the game is ended
        if (!_gameEnded)
        {
            // It is is, player rank shouldn't change
            LastRank = _playerRank;
        }
    }
    // This checks if the player passed the finish line
    private void OnTriggerEnter(Collider other)
    {
        // If it is, game is ended
        if (other.CompareTag("Player"))
        {
            _gameEnded = true;
        }
        
    }
}
