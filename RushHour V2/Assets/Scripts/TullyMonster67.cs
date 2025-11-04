using System;
using UnityEngine;
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
