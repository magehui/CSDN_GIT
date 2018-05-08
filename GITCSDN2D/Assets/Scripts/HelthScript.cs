using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelthScript : MonoBehaviour {

    public int hp = 1;
    ///敌人还是玩家？
    public bool isEnemy = true;

    //造成伤害并检查物体是否应该被毁坏
    public void damage(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShotScript shot = collision.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyshot != isEnemy)//避免友方伤害

            {
                damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
    }

   
}
