using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishUı : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finish;
    [SerializeField] private GameObject _wallText;
    [SerializeField] private GameObject _restartBtn;

    // Update is called once per frame
    void Update()
    {
        // Checks if the game has ended
        if (_finish._isGameFinished)
        {
            // If the game is ended it enables the restart button and wall text
            _wallText.SetActive(true);
            _restartBtn.SetActive(true);
        }
    }
    // This restarts the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
