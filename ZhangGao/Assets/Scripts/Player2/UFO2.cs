using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO2 : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        UFOManager2.UFOtimer2 = Time.time;
    }

}
