using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringDashboard : MonoBehaviour
{
    private int punts;
    
    public void IncreaseScore(int amount)
    {
        punts += amount;
        Debug.Log($"score is now {punts}");
    }
  
}
