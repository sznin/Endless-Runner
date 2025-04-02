using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplay;



    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
    }
}
