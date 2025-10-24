using System;
using UnityEngine;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject coin;
    //private List<GameObject> coins = new List<GameObject>();
    private float waitTime = 200f;
    private float timeWaited = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject o = Instantiate(coin);
            o.transform.position = mousePos;

        }
    }
    private void OnMouseDown()
    {
        //timeWaited += Time.deltaTime*1000f;
        
        //timeWaited = 0f;
    
    }
}
