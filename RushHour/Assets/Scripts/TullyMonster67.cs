using System;
using UnityEngine;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int moves = 0;
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
        scoreText.text = "Move: " + moves;
        
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
