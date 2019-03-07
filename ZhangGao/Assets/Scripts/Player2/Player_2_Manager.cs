using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_2_Manager : MonoBehaviour {

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject bunkerPrefab;
    [SerializeField] GameObject bottomLine;
    GameObject currentPlayer = null;
    GameObject bunker;

    public int playerLives = 3;
    public static bool player2Dead = false;
    public static bool changePlayer2 = false;

    int delay = 100;

    private void Start()
    {
        Spawn();
        SpawnBunker();
    }

    void FixedUpdate () {
        Check();
	}

    void Spawn()
    {
        currentPlayer = Instantiate(playerPrefab, new Vector3(-6f,-3.5f,0f), Quaternion.identity);
        currentPlayer.transform.parent = gameObject.transform;
    }
    public void SpawnBunker()
    {
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
            if (delay < 0)
            {
                ChangeDelay();
                delay = 100;
            }
        }
        if (bottomLine.GetComponent<CheckEnemies>().TouchBottom() == true)
        {
            playerLives = 0;
            GameObject.Find("LifeRemaining").GetComponent<Text>().text = (playerLives).ToString();
            player2Dead = true;
        }
    }

    private void ChangeDelay()
    {
        CheckEnemies.touch = 0;
        if (playerLives > 1)
        {
            gameObject.SetActive(false);
            changePlayer2 = true;
            Spawn();
            playerLives -= 1;
            GameObject.Find("LifeRemaining2").GetComponent<Text>().text = (playerLives).ToString();
            Destroy(gameObject.transform.GetChild(0).gameObject);

        }
        else if (playerLives == 1)
        {
            playerLives -= 1;
            GameObject.Find("LifeRemaining2").GetComponent<Text>().text = (playerLives).ToString();
            Destroy(gameObject.transform.GetChild(0).gameObject);
            player2Dead = true;

        }
    }
}
