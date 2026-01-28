using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] List<GameObject> winsprites;
    [SerializeField] GameObject livesCanvas;
    [SerializeField] GameObject life1;
    [SerializeField] GameObject life2;
    [SerializeField] GameObject life3;
    [SerializeField] GameObject camera;
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
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(camera);
        DontDestroyOnLoad(livesCanvas);
        DontDestroyOnLoad(life1);
        DontDestroyOnLoad(life2);
        DontDestroyOnLoad(life3);
        DontDestroyOnLoad(wintext.gameObject);
        DontDestroyOnLoad(losetext.gameObject);
        DontDestroyOnLoad(scoreText.gameObject);
        foreach (var sprite in winsprites)
        {
            sprite.SetActive(true);
        }

        wintext.enabled = false;
        losetext.enabled = false;

  
    }

    // Update is called once per frame
    void Update()
    {
        int totalLives = winsprites.Count;

        for (int i = 0; i < totalLives; i++)
        {
            if (i < totalLives - count)
                winsprites[i].SetActive(true);   
            else
                winsprites[i].SetActive(false);  
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
                moves = 0f;
                minutes = 0f;
                hours = 0f;
                
            }
        }
        if (count >= winsprites.Count && !losetext.enabled)
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
    public void next()
    {
        //winText.enabled = false;
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
        

    }
    public bool last()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            return true;
        }
        return false;
    }

}
