using System;
using UnityEngine;
using UnityEngine.UI;


public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] Text scoreText; 
    private int moves = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
