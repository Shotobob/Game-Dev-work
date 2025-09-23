using System;
using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject skull1;
    [SerializeField] GameObject skull2;
    [SerializeField] GameObject skull3;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject manager;
    private int score = 0;
    private int count = 0;
    public bool end = false;
    public bool reset = false;
    void Start()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = false;
        skull2.GetComponent<SpriteRenderer>().enabled = false;
        skull3.GetComponent<SpriteRenderer>().enabled = false;
        count = 0;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            skull1.GetComponent<SpriteRenderer>().enabled = false;
            skull2.GetComponent<SpriteRenderer>().enabled = false;
            skull3.GetComponent<SpriteRenderer>().enabled = false;
            count = 0;
            score = 0;
            scoreText.text = "Score: " + score;
            end = false;
            //manager.GetComponent<Shape>().Move();
        }
        //reset = true;
    }
    public void visibleSkull()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = true;
        if(count == 1)
        {
            skull2.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(count == 2)
        {
            skull3.GetComponent<SpriteRenderer>().enabled = true;
            end = true;
        }
        count++;
        
    }

    public void AddPoints(int points)
    {
        score+=points;
        scoreText.text = "Score: " + score;
    }
}
