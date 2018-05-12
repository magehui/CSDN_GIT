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
            }
        }
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
            if (damagePlayer != null)
            {
                playHealth.damage(1);
            }
        }
    }

}
