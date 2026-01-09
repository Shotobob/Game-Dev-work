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
    private int color = 0;
    private float[] xvalues = {-0.51f, 0.51f, 1.56f, -1.56f, 2.61f, -2.61f,3.66f, -3.66f}
    private float[] yvalues = {-0.51f, 0.51f, 1.56f, -1.56f, 2.61f, -2.61f,3.66f, -3.66f}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameObject o = Instantiate(piece);
        pieces.Add(o);
        o.transform.position = new Vector2(0.51f, 0.51f);
        o.GetComponent<Pieces>().flip();
        o.GetComponent<Pieces>().setblack();

        GameObject o2 = Instantiate(piece);
        pieces.Add(o2);
        o2.transform.position = new Vector2(-0.51f, 0.51f);
        //o2.GetComponent<Pieces>().flip();

        GameObject o3 = Instantiate(piece);
        pieces.Add(o3);
        o3.transform.position = new Vector2(0.51f, -0.51f);
        //o3.GetComponent<Pieces>().flip();
        
        GameObject o4 = Instantiate(piece);
        pieces.Add(o4);
        o4.transform.position = new Vector2(-0.51f, -0.51f);
        o4.GetComponent<Pieces>().flip();
        o4.GetComponent<Pieces>().setblack();
        
        GameObject o5 = Instantiate(piece);
        pieces.Add(o5);
        o5.GetComponent<Pieces>().flip();
        
        
       


    }
    // Update is called once per frame
    void Update()
    {
        
        

        if(placed == false)
        {
            move();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                placed = true;
                
                GameObject current = Instantiate(piece);
                pieces.Add(current);
               
                if(color%2 != 0)
                {
                    current.GetComponent<Pieces>().flip();
                }
                color++;
            }
        }
        placed = false;
       
    }
    public void move()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pieces[pieces.Count - 1].transform.position = new Vector2(mousePos.x, mousePos.y);

    }
    public void correct()
    {
        float current = 0f;
        float yat = 0;
        float xat = 0;
        for(int x = 0; x < xvalues.Length; x++)
        {
            float diff = Math.abs(xvalues[x]) - Math.abs(transform.position.x);
            if(diff<current)
            {
                current = diff;
                yat = xvalues[x];
            }
            diff = Math.abs(yvalues[x]) - Math.abs(transform.position.y);
            if(diff<current)
            {
                current = diff;
                xat = yvalues[x];
            }
             pieces[pieces.Count - 1].transform.position = new Vector2(xat, yat);
        }
    }
}
