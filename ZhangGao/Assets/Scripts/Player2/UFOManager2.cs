using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManager2 : MonoBehaviour {

    [SerializeField] GameObject UFOPrefab;
    [SerializeField] float moveSpeed = 0.05f;

    GameObject newufo;
    public static float UFOtimer2=0;
    int side = 0;
    float appearTime;
	// Use this for initialization
	void Start () {
       // SpawnUFO();
	}
	
	// Update is called once per frame
	void Update () {
        appearTime = Random.Range(10f, 20f);
        moveUFO();

	}

    void SpawnUFO(){
        side = Random.Range(0, 2);
        if (side==0){
            newufo = Instantiate(UFOPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        }
        if (side==1){
            newufo = Instantiate(UFOPrefab, new Vector3(gameObject.transform.position.x * -1, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
        } // TODO:write it better

        newufo.transform.parent = gameObject.transform;
    }
    void moveUFO(){
        if (newufo!=null){
            if (side==0){
                newufo.transform.Translate(new Vector3(moveSpeed, 0f, 0f));
            }
            if (side == 1)
            {
                newufo.transform.Translate(new Vector3(-moveSpeed, 0f, 0f));
            }
        }

        else
        {
            if (Time.time - UFOtimer2 > appearTime)
            {
                SpawnUFO();
            }
        }
    }
}
