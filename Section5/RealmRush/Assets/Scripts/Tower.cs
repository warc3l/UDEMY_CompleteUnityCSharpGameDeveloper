using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int cost = 75;

    [SerializeField] private float buildDelay = 1f;
    
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

    private void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        
        
        foreach (Transform child in transform) // We are disabling the transform
        {
            child.gameObject.SetActive(false);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
            
        }
        
        foreach (Transform child in transform) // We are enabling the transform after each seconds
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
            
        }
    }
}
