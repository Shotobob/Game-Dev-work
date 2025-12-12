using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject piece;
    private List<GameObject> pieces = new List<GameObject>();
    private bool placed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameObject o = Instantiate(piece);
        pieces.Add(o);
        o.transform.position = new Vector2(0.51f, 0.51f);
        o.GetComponent<Pieces>().flip();
        o.GetComponent<Pieces>().setwhite();

        GameObject o2 = Instantiate(piece);
        pieces.Add(o2);
        o2.transform.position = new Vector2(-0.51f, 0.51f);
        //o2.GetComponent<Pieces>().flip();

        GameObject o3 = Instantiate(piece);
        pieces.Add(o3);
        o3.transform.position = new Vector2(0.51f, -0.51f);
        //o.GetComponent<Pieces>().flip();
        
        GameObject o4 = Instantiate(piece);
        pieces.Add(o4);
        o4.transform.position = new Vector2(-0.51f, -0.51f);
        o4.GetComponent<Pieces>().flip();
        o4.GetComponent<Pieces>().setwhite();
        
        GameObject o5 = Instantiate(piece);
        pieces.Add(o5);
        //o.GetComponent<Pieces>().flip();
        


    }
    // Update is called once per frame
    void Update()
    {
        if(placed == false)
        {
            move();
        }
        
       
    }
    public void move()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pieces[pieces.Count - 1].transform.position = new Vector2(mousePos.x, mousePos.y);

    }
}
