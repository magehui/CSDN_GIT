using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
    //造成的伤害
    public int damage = 1;
    ///弹丸伤害玩家或敌人？
    public bool isEnemyshot = false;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 20);
	}
	
	
}
