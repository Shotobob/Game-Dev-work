using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject coin;
    private List<GameObject> coins = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject o = Instantiate(coin);
        coins.Add(coin);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        coins[coins.Count-1].transform.position = new Vector2 (mousePos.x, 4.36f);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            GameObject o = Instantiate(coin);
            coins.Add(coin);
            o.transform.position = mousePos;

        }
    }
    private void correct()
    {

    }
}
