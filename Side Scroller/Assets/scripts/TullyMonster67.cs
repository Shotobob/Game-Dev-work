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
    [SerializeField] Text Timetext;
    [SerializeField] Text Pointstext;
    int count = 0;
    bool ifwin = false;
    bool iflose = false;
    float seconds = 0;
    float points = 0;
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
        if(ifwin == false && iflose == false)
        {
            seconds += Time.deltaTime;
            Timetext.text =  "Time: " + (int) seconds;
        }
        if(ifwin == false && iflose == false)
        {
            
            Pointstext.text =  "Points: " + (int) points;
        }
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
                
            }
        }
        if (count >= 3 && !losetext.enabled)
        {
            losetext.enabled=true;
            iflose = true;
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
    public void addpoint()
    {
        points++;
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
