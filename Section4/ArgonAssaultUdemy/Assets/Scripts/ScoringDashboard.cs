using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringDashboard : MonoBehaviour
{
    private int punts;
    private TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }
   
    public void IncreaseScore(int amount)
    {
        punts += amount;
        Debug.Log($"score is now {punts}");
        scoreText.text = punts.ToString();
    }
  
}
