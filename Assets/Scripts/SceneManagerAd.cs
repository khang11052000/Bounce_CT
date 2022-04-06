using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerAd : MonoBehaviour
{
    public static SceneManagerAd intance;
    
    private void Awake()
    {
        intance = this;

    }

    private void Start()
    {
    }

    private void Update()
    {
        
    }
    

    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
