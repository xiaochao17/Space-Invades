﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCreditScene : MonoBehaviour {

    public void LoadCredits(){
        SceneManager.LoadScene("Credits");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
