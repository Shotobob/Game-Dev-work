using System;
using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] Text winText;
    //[SerializeField] GameObject image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winText.enabled = false;
        //image.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void wintime()
    {
        winText.enabled = true;
        //image.GetComponent<SpriteRenderer>().enabled = true;
    }
}
