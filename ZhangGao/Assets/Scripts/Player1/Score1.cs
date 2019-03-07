using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour {

    public static int score = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = score.ToString().PadLeft(6, '0');
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = score.ToString().PadLeft(6, '0');
    }



}
