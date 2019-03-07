using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemies : MonoBehaviour {

    public static int touch;

    private void Update()
    {
        TouchBottom();
    }

    public bool TouchBottom()
    {
        if (touch==1){
            return true;
        }
        else{
            return false;
        }
    }

    void OnTriggerEnter2D(Collider2D theOtherCollider)
    {
        if (theOtherCollider.gameObject.tag == "Octopus" || theOtherCollider.gameObject.tag == "Crab" || theOtherCollider.gameObject.tag == "Squid")
        {
            touch = 1;
        }
        else{
            touch = 0;
        }
    }

}
