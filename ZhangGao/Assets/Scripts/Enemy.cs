using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool enemyDie = false;
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] float enemyMissileSpeed = -2f;
    [SerializeField] GameObject explosion;
    private float delaytime = 0.1f;

    //Enemy Shoot
    public void EnemyFire()
    {
        GameObject enemyMissile = Instantiate(enemyProjectile,
                                            gameObject.transform.position,
                                         Quaternion.identity) as GameObject;
       // enemyMissile.transform.parent = gameObject.transform;
        enemyMissile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, enemyMissileSpeed);
    }

    //Enemy Move Horizontally
    public void EnemyMove(float direction){
        transform.position += new Vector3(direction,0f,0f);
    }
    //Enemy move vertically
    public void MoveDown(){
        transform.position += new Vector3(0f,-0.2f,0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Bunker"){
            this.enemyDie = true;
           
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
            Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.SetActive(false);
            GameObject exploPic = Instantiate(explosion, position, Quaternion.identity);
            Destroy(exploPic, delaytime);
        }
      
    }
}
