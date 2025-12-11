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
        //Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        pieces.Add(o);
        o.transform.position = new Vector2(0.51f, 0.51f);
        

        o = Instantiate(piece);
        //Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        pieces.Add(o);
        o.transform.position = new Vector2(-0.51f, 0.51f);
        o.GetComponent<Pieces>().flip();

        // o.GetComponent<Pieces>().flip();
         o = Instantiate(piece);
        //Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        pieces.Add(o);
        o.transform.position = new Vector2(0.51f, -0.51f);
        

        // o.GetComponent<Pieces>().flip();
        o = Instantiate(piece);
        //Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        pieces.Add(o);
        o.transform.position = new Vector2(-0.51f, -0.51f);
        o.GetComponent<Pieces>().flip();
        
        o = Instantiate(piece);
        //Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        pieces.Add(o);
        


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
