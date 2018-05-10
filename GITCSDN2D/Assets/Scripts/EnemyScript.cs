using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private WeponScript[]  weapons;

    void Awake()
    {
        weapons = GetComponentInChildren<WeponScript[]>();
    }

     void Update()
    {
        foreach (WeponScript weapon in weapons)
        {
            if (weapon != null&&weapon.canAttack)
            {
                weapon.Attack(true);
            }
        }
    }



}
