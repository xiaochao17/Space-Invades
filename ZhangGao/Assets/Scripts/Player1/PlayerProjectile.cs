using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public static int deadEnemyNumber1 = 0;

    void OnTriggerEnter2D(Collider2D theOtherCollider)
    {
        if (theOtherCollider.gameObject.tag == "Octopus")
        {
            Score1.score += 10;
            deadEnemyNumber1 +=1;
        }
        if (theOtherCollider.gameObject.tag == "Crab")
        {
            Score1.score += 20;
            deadEnemyNumber1 += 1;
        }
        if (theOtherCollider.gameObject.tag == "Squid")
        {
            Score1.score += 30;
            deadEnemyNumber1 += 1;
        }
        if (theOtherCollider.gameObject.tag == "UFO")
        {
            Score1.score += Random.Range(1,5)*50;
        }
        Destroy(gameObject);
        print(PlayerProjectile.deadEnemyNumber1);
    }
}
