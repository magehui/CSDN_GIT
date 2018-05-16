using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public Vector2 speed = new Vector2(50,50);
    private Vector2 movement;
 
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        movement = new Vector2
        (
            speed.x * inputX,
            speed.y * inputY
        );
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            WeponScript weapon = GetComponent<WeponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
                SoundEffectsHelper.instance.MakePlayShotSound();
            }
        }
        //下面代码确保主角不在相机边界之外
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
             new Vector3(1, 0, dist)).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).y;

        var buttonBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0,1, dist)).y;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, buttonBorder),
            transform.position.z);
    }
     void FixedUpdate()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = movement;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            HelthScript enemyHelth = enemy.GetComponent<HelthScript>();
            if (enemyHelth != null)
                 enemyHelth.damage(enemyHelth.hp);
            damagePlayer = true;
        }
        if (damagePlayer)
        {
            HelthScript playHealth = this.GetComponent<HelthScript>();
            if (playHealth != null)
            {
                playHealth.damage(1);
            }
        }
    }
     void OnDestroy()
    {
        //玩家死亡时实例化GameOverScript
        transform.parent.gameObject.AddComponent<GameOverScript>();
    }
}
