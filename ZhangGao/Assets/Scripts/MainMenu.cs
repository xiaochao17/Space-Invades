using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //private DataController dataController;
    private PlayerProgress playerProgress;

    private void Start()
    {
        Screen.SetResolution(1920,1080,true);
        playerProgress = new PlayerProgress();

    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //dataController.ConfirmPlayerMode(1);
            playerProgress.playerMode = 1;
            PlayerProjectile.deadEnemyNumber1 = 0;
            PlayerPrefs.SetInt("playerMode", playerProgress.playerMode);
            SceneManager.LoadScene(1);

        }
        if(Input.GetKeyDown(KeyCode.Return)){
            // dataController.ConfirmPlayerMode(2);
            PlayerProjectile2.deadEnemyNumber2 = 0;
            PlayerProjectile.deadEnemyNumber1 = 0;
            playerProgress.playerMode = 2;
            PlayerPrefs.SetInt("playerMode", playerProgress.playerMode);
            SceneManager.LoadScene(1);
        }
    }

}
