using System;
using UnityEngine;
using UnityEngine.UI;

public class Tullymonster67 : MonoBehaviour
{
    [SerializeField] GameObject skull1;
    [SerializeField] GameObject skull2;
    [SerializeField] GameObject skull3;
    private int count = 0;
    public bool end = false;
    private int score = 0;
    [SerializeField] Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void visibleSkull()
    {
        skull1.GetComponent<SpriteRenderer>().enabled = false;
        if (count == 1)
        {
            skull2.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (count == 2)
        {
            skull3.GetComponent<SpriteRenderer>().enabled = false;
            end = true;
        }
        count++;

    }
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
