using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject coin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void add()
    {

    }
    /*private void OnMouseDown()
    {
        timeWaited += Time.deltaTime*1000f;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(timeWaited > waitTime)
        {
            //GameObject o = Instantiate(coin);
            o.transform.position = mousePos;
            timeWaited = 0f;
        }
    }*/
}
