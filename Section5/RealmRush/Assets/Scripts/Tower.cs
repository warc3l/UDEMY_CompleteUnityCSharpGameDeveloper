using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int cost = 75;

    public bool CreateTower(Tower towerPrefab, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false;
            
        }
        if (bank.CurrentBalance >= cost)
        {
            Instantiate(towerPrefab, position, Quaternion.identity);
            bank.Withdraw(cost);            
            return true;
        }

        return false;
    }
    
}
