using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private float moves = 0f;
    [SerializeField] Text winText;
    private bool win = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(scoreText);
        DontDestroyOnLoad(winText);
        winText.enabled = false;
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(win == false)
        {
            moves += Time.deltaTime;
            scoreText.text = "Time: " + (int)moves;
        }
        if (win == true)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(2);
            }
            win = false;
        }
        
        
    }
    public void addMove()
    {
        moves = moves + 1;
    }
    public void winningText(bool win)
    {
        winText.enabled = win;

    }
    public void setWin(bool win2)
    {
        win = win2;

    }
    public bool isWin()
    {
        
        return win;

    }
    public void setZero()
    {
        moves = 0;

    }
}
