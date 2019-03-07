using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile2 : MonoBehaviour {

    public static int deadEnemyNumber2;

    void OnTriggerEnter2D(Collider2D theOtherCollider)
    {
        if (theOtherCollider.gameObject.tag == "Octopus")
        {
            Score2.score += 10;
            deadEnemyNumber2 +=1;
        }
        if (theOtherCollider.gameObject.tag == "Crab")
        {
            Score2.score += 20;
            deadEnemyNumber2 += 1;
        }
        if (theOtherCollider.gameObject.tag == "Squid")
        {
            Score2.score += 30;
            deadEnemyNumber2 += 1;
        }
        if (theOtherCollider.gameObject.tag == "UFO")
        {
            Score2.score += Random.Range(1,5)*50;
        }
        Destroy(gameObject);
    }
}
