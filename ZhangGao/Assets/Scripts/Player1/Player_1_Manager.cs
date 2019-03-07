using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_1_Manager : MonoBehaviour {

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject bunkerPrefab;
    GameObject currentPlayer = null;
    GameObject bunker;
    [SerializeField] GameObject bottomLine;

    public int playerLives = 3;
    public static bool playerOneDead = false;
    public static bool changePlayer1 = false;
    int delay = 100;

    private void Start()
    {
        Spawn();
        SpawnBunker();
    }

    void Update () {
        Check();
	}

    void Spawn()
    {
        currentPlayer = Instantiate(playerPrefab, new Vector3(-6f,-3.5f,0f), Quaternion.identity);
        currentPlayer.transform.parent = gameObject.transform;
    }
    public void SpawnBunker(){
        Destroy(bunker);
        bunker = Instantiate(bunkerPrefab, transform.position, Quaternion.identity);
        bunker.transform.parent = gameObject.transform;
    }

    void Check() 
    {
        // Check for the current player's live status or if the handler become null
        if (currentPlayer == null) 
        {
            delay--;
            if (delay<0){
                ChangeDelay();
                delay = 100;
            }

        }
        if(bottomLine.GetComponent<CheckEnemies>().TouchBottom() == true){
            playerLives = 0;
            GameObject.Find("LifeRemaining").GetComponent<Text>().text = (playerLives).ToString();
            playerOneDead = true;
        }

    }

    void ChangeDelay(){
        CheckEnemies.touch = 0;
        if (playerLives > 1)
        {
            gameObject.SetActive(false);
            changePlayer1 = true;
            Spawn();
            playerLives -= 1;
            GameObject.Find("LifeRemaining").GetComponent<Text>().text = (playerLives).ToString();
            Destroy(gameObject.transform.GetChild(0).gameObject);

        }
        else if (playerLives == 1)
        {
            playerLives -= 1;
            GameObject.Find("LifeRemaining").GetComponent<Text>().text = (playerLives).ToString();
            Destroy(gameObject.transform.GetChild(0).gameObject);
            playerOneDead = true;

        }
    }
}
