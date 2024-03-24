using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 150;

    [SerializeField] private int currentBalance;

    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    }

    private void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        if (amount >= 0) // this is not necessary, but solution mention in the udemy
        {
            currentBalance += Mathf.Abs(amount);
        }
    }
    

    
    public void Withdraw(int amount)
    {
        if (amount >= 0) // this is not necessary, but solution mention in the udemy
        {
            currentBalance -= Mathf.Abs(amount);
            if (currentBalance < 0)
            {
                // TODO Lose the game
                ReloadScene();
            }
        }
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

}
