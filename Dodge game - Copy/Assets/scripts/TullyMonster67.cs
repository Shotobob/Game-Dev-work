using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] List<GameObject> winsprites;
    [SerializeField] Text wintext;
    [SerializeField] Text losetext;
    [SerializeField] Text scoreText;
    private float moves = 0f;
    private float minutes = 0f;
    private float hours = 0f;
    int count = 0;
    bool ifwin = false;
    bool iflose = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wintext.enabled = false;
        losetext.enabled = false;

        foreach (var sprite in winsprites)
        {
            sprite.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ifwin == true || iflose == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                wintext.enabled = false;
                losetext.enabled = false;
                foreach (var sprite in winsprites)
                {
                    sprite.SetActive(true);
                }
                ifwin = false;
                iflose = false;
                count = 0;
                moves = 0f;
                minutes = 0f;
                hours = 0f;
                
            }
        }
        if (count >= 3 && !losetext.enabled)
        {
            losetext.enabled=true;
            iflose = true;
        }
        if (ifwin == false && iflose == false)
        {
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

        

    }
    public void endlife()
    {
        if(count < winsprites.Count) 
        {
            winsprites[count].SetActive(false);
            count++;
        }
        
    }
    public void win()
    {
        wintext.enabled = true;
        ifwin = true;
    }
    public bool iswin()
    {
        return ifwin;
    }
    public bool islose()
    {
        return iflose;
    }

}
