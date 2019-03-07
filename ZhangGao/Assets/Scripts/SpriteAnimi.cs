using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimi : MonoBehaviour {
    [SerializeField] Sprite state1;
    [SerializeField] Sprite state2;

    public static float moveInterval = 1f;
	
	// Update is called once per frame
	void Start () {
        InvokeRepeating("ChangeSprite", moveInterval, moveInterval);
	}

    void ChangeSprite(){
        if (gameObject.GetComponent<SpriteRenderer>().sprite == state1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = state2;
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = state1;
        }
    }

}
