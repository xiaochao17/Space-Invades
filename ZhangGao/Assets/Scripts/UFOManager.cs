using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOManager : MonoBehaviour {

    [SerializeField] GameObject UFOPrefab;
    [SerializeField] float moveSpeed = 0.05f;

    GameObject newufo;
    float UFOtimeFlag = 0f;
    int side = 0;
    float appearTime;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
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

        appearTime = Random.Range(95,145);
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
            UFOtimeFlag += 0.1f;
            if (UFOtimeFlag > appearTime)
            {
                SpawnUFO();
                UFOtimeFlag = 0f;
            }
        }
    }
}
