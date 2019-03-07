using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject mask;
    [SerializeField] GameObject player1ChangeText;
    [SerializeField] GameObject player2ChangeText;
    [SerializeField] GameObject enemiesGO1;
    [SerializeField] GameObject enemiesGO2;
    [SerializeField] GameObject gameover1;
    [SerializeField] GameObject gameover2;




    void Update()
    {
        if (PlayerPrefs.GetInt("playerMode") == 2){
        
            if (Player_1_Manager.changePlayer1 == true && !player2.activeSelf)
            {
                GameObject.Find("LifeRemaining").GetComponent<Text>().enabled = false;
                mask.SetActive(true);
                player2ChangeText.SetActive(true);
                Player_1_Manager.changePlayer1 = false;
                Invoke("ActivatePlayerTwo", 2.5f);

            }

            if (Player_2_Manager.changePlayer2 == true && !player1.activeSelf)
            {
                GameObject.Find("LifeRemaining2").GetComponent<Text>().enabled = false;
                mask.SetActive(true);
                player1ChangeText.SetActive(true);
                Player_2_Manager.changePlayer2 = false;
                Invoke("ActivatePlayerOne", 2.5f);
            }

            if (Player_1_Manager.playerOneDead == true)
            {
                gameover1.SetActive(true);
                if (Score1.score > PlayerPrefs.GetInt("highestScore"))
                {
                    PlayerPrefs.SetInt("highestScore", Score1.score);
                }
                Invoke("Player1ToPlayer2", 2f);
                Invoke("ActivatePlayerTwo",4.5f);
                Player_1_Manager.playerOneDead = false;
            }
            if (Player_2_Manager.player2Dead == true)
            {

                gameover2.SetActive(true);
                if (Score2.score > PlayerPrefs.GetInt("highestScore"))
                {
                    PlayerPrefs.SetInt("highestScore", Score2.score);
                }
                Invoke("Player2Die", 2f);
                Player_2_Manager.player2Dead = false;
            }


        }
        else{

            if (Player_1_Manager.changePlayer1 == true){
                mask.SetActive(true);
                player1ChangeText.SetActive(true);
                Player_1_Manager.changePlayer1 = false;
                Invoke("ActivatePlayerOne", 2.5f);
            }

            if (Player_1_Manager.playerOneDead == true)
            {
                gameover1.SetActive(true);
                if (Score1.score > PlayerPrefs.GetInt("highestScore"))
                {
                    PlayerPrefs.SetInt("highestScore", Score1.score);
                }
                Invoke("Player1Die", 2f);
                Player_1_Manager.playerOneDead = false;
            }

        }

  


        if (PlayerProjectile.deadEnemyNumber1 == 55){
            PlayerProjectile.deadEnemyNumber1 = 0;
            mask.SetActive(true);
            player1ChangeText.SetActive(true);
            Invoke("LoadNextLevel1", 2f);
        }
        if (PlayerProjectile2.deadEnemyNumber2 == 55)
        {
            PlayerProjectile2.deadEnemyNumber2 = 0;
            mask.SetActive(true);
            player2ChangeText.SetActive(true);
            Invoke("LoadNextLevel2", 2f);
        }

    }

    void ActivatePlayerOne(){
        mask.SetActive(false);
        player1ChangeText.SetActive(false);
        GameObject.Find("LifeRemaining").GetComponent<Text>().enabled = true;
        player1.SetActive(true);
    }
    void ActivatePlayerTwo()
    {
        mask.SetActive(false);
        player2ChangeText.SetActive(false);
        GameObject.Find("LifeRemaining2").GetComponent<Text>().enabled = true;
        player2.SetActive(true);
    }


    void LoadNextLevel1(){
        mask.SetActive(false);
        player1ChangeText.SetActive(false);
        enemiesGO1.GetComponent<EnemyManager>().SpawnEnemies();
        player1.GetComponent<Player_1_Manager>().SpawnBunker();
    }
    void LoadNextLevel2()
    {
        mask.SetActive(false);
        player2ChangeText.SetActive(false);
        enemiesGO2.GetComponent<EnemyManager2>().SpawnEnemies();
        player2.GetComponent<Player_2_Manager>().SpawnBunker();
    }


    void Player1Die()
    {
        Score1.score = 0;
        gameover1.SetActive(false);
        SceneManager.LoadScene(0);

    }
    void Player1ToPlayer2(){
        gameover1.SetActive(false);
        player1.SetActive(false);
        GameObject.Find("LifeRemaining").GetComponent<Text>().enabled = false;
        mask.SetActive(true);
        player2ChangeText.SetActive(true);
    }
    void Player2Die(){
        Score2.score = 0;
        Score1.score = 0;
        gameover2.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
