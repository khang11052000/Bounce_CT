using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public Text txtLive, txtTime, txtScore;
    public GameObject ballPlayer;
    public bool isLive;
    public GameObject gameOver;
    public GameObject startPoint;
    protected int intLive;
    public int IntLive => intLive;
    private float posY = -0.5f;
    private TimeSpan _timePlaying;
    private bool _timerGoing;
    private float elapsedTime;
    
    int a = -1;

    
    
    private void Awake()
    {
        //TODO Check don't destroy when load game
        _instance = this; //static gọi ở trong màn hình (từ tất cả các đối tượng khác)
    }

    private void Start()
    {
        isLive = true;
        txtTime.text = "Time: 00 : 00";
        BeginTimer();

        GetData();
        txtLive.text = "x " + intLive;

    }

    private void Update()
    {
        animationStartPoint();
        //  Debug.Log(startPoint.transform.position);
    }

    public void BeginTimer()
    {
        _timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        StopAllCoroutines();
        //Debug.Log(2);
        _timerGoing = false;
        
    }

    public IEnumerator UpdateTimer()
    {
        //Debug.Log(1);
        while (_timerGoing)
        {
            elapsedTime += Time.deltaTime;
            _timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timerPlayingStr = "Time: " + _timePlaying.ToString("mm' : 'ss");
            txtTime.text = timerPlayingStr;

            yield return null;
        }
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         Die();
    //         revival();
    //         
    //     }
    //     Debug.Log(collision);
    // }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("live", intLive);
        
    }

    public void GetData()
    {
        if (PlayerPrefs.HasKey("live") == true)
        {
            intLive = PlayerPrefs.GetInt("live");
        }
        else
        {
            intLive = 3;
        }
    }
    
    public void Die()
    {
        isLive = false;
        intLive--;
        SaveScore();

    }

    public void GameOver()
    {
        if (intLive == 0)
        {
            EndTimer();
            gameOver.SetActive(true);
            isLive = false;
        }
        
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void revival()
    {
        Invoke("TextLive", 0.1f);
        Invoke("RePos", 0.1f);

    }

    void TextLive()
    {
        isLive = true;
        //string liveStr = "x " + intLive;
        //txtLive.text = liveStr;
        txtLive.text = "x " + intLive;
    }

    void RePos()
    {
        ballPlayer.transform.position = new Vector2(-16, -2);
    }

    public void animationStartPoint()
    {
        if (startPoint.transform.position.y == posY)
        {
            a *= -1;
            posY -= 0.5f * a;
        }
        //Debug.Log(tra);
        startPoint.transform.position = Vector3.MoveTowards(startPoint.transform.position, new Vector2(-16, posY), 0.003f);
    }
    
    
}
