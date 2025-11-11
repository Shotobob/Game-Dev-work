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
    public bool iswin()
    {
        return ifwin;
    }
    public bool islose()
    {
        return iflose;
    }

}
