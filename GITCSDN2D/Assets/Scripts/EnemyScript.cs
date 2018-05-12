using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private WeponScript[] weapons;

    void Awake()
    {
        // Retrieve the weapon only once
        weapons = GetComponentsInChildren<WeponScript>();
    }

    void Update()
    {
        foreach (WeponScript weapon in weapons)
        {
            // Auto-fire
            if (weapon != null && weapon.canAttack)
            {
                weapon.Attack(true);
            }
        }
    }
}




