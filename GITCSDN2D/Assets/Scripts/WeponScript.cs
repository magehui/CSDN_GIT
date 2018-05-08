using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponScript : MonoBehaviour {

    public Transform shotPrefab;
    public float shootingRate = 0.25f;

    private float shootCooldown;

    public bool canAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
     }

    // Use this for initialization
    void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(shootCooldown>0)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    public void Attack(bool isEnemy)
    {
        if (canAttack)
        {
            shootCooldown = shootingRate;
            //创建一个新的射击
            var shotTransform = Instantiate(shotPrefab) as Transform;
            //弹药发射位置是当前玩家位置
            shotTransform.position = transform.position;
            // The is enemy property
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyshot = isEnemy;
            }
            // Make the weapon shot always towards it
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move != null)
            {
                move.direction = this.transform.right;
            }
        }
    }
}
