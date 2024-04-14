using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
 //   [SerializeField] private int ammoAmount = 10;

 [SerializeField] private AmmoSlot[] ammoSlots;
 
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmmount;
    }
     
    public int GetAmmo(AmmoType type)
    {
        //return ammoAmount;
        return GetSlot(type).ammoAmmount;
    }

    AmmoSlot GetSlot(AmmoType type)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == type)
            {
                return slot;
            }
        }

        throw new Exception("Not existing slot for this type");
    }
    

    public void ReduceAmmo(AmmoType type)
    {
        // ammoAmount = ammoAmount - 1;
        GetSlot(type).ammoAmmount--;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
