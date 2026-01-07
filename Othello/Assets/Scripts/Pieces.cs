using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class Pieces : MonoBehaviour
{

     [SerializeField] GameObject black;
     [SerializeField] GameObject white;

    private bool isblack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //black.GetComponent<SpriteRenderer>().sortingOrder= 3;
        //white.GetComponent<SpriteRenderer>().sortingOrder= 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setblack()
    {
        isblack = true;
    }
    public void setwhite()
    {
        isblack = false;
    }
    public void flip()
    {
        if(isblack == true)
        {
            black.GetComponent<SpriteRenderer>().sortingOrder= 0;
            white.GetComponent<SpriteRenderer>().sortingOrder= 3;

            
        }
        else{
            black.GetComponent<SpriteRenderer>().sortingOrder= 3;
            white.GetComponent<SpriteRenderer>().sortingOrder= 0;

        }
        
    }
}
