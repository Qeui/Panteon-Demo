using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _rankText;
    [SerializeField] private RankSystem _rankSys;

    // Update is called once per frame
    void Update()
    {
        // Updates the rank text acording to the rank system
        _rankText.text = _rankSys.LastRank.ToString() + "/11";
    }
}
