using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private float moves = 0f;
    private float minutes = 0f;
    private float hours = 0f;
    [SerializeField] Text winText;
    private bool win = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        //DontDestroyOnLoad(scoreText);
        //DontDestroyOnLoad(winText);
        winText.enabled = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        //DontDestroyOnLoad(this);
        scoreText = GameObject.Find("tim").GetComponent<Text>();
        winText = GameObject.Find("win").GetComponent<Text>();
        if(win == false)
        {
            winText.enabled = false;

        }
        
        
            moves += Time.deltaTime;
            scoreText.text = "Time: " + (int)hours + ":" +(int)minutes + ":" + (int)moves;
        if(moves >60f)
        {
            minutes++;
            moves = 0f;
        }
        if (minutes > 60f)
        {
            hours++;
            minutes = 0f;
        }



    }
    public void addMove()
    {
        moves = moves + 1;
    }
    public void winningText(bool win)
    {
        winText.enabled = true;

    }
    public void setWin(bool win2)
    {
        win = win2;
         winText.enabled = true;

    }
    public bool isWin()
    {
        
        return win;

    }
    public void setZero()
    {
        moves = 0;

    }
    public void next()
    {
        winText.enabled = false;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
            //win = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
            //win = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3);
            //win = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);
            //win = false;
        }


    }
}
