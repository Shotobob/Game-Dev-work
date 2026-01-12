using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject piece;
    private List<GameObject> pieces = new List<GameObject>();
    private bool placed = false;
    private int color = 0;
    private float[] xvalues = { -3.66f, -2.61f, -1.56f, -0.51f, 0.51f, 1.56f, 2.61f, 3.66f };
    private float[] yvalues = { -3.66f, -2.61f, -1.56f ,-0.51f, 0.51f, 1.56f, 2.61f, 3.66f };
    public GameObject current;
    private int[,] board = new int[8, 8];
    private bool legal = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        GameObject o = Instantiate(piece);
        pieces.Add(o);
        o.transform.position = new Vector2(0.51f, 0.51f);
        //o.GetComponent<Pieces>().flip();
        o.GetComponent<Pieces>().setblack();

        GameObject o2 = Instantiate(piece);
        pieces.Add(o2);
        o2.transform.position = new Vector2(-0.51f, 0.51f);
        o2.GetComponent<Pieces>().setwhite();

        GameObject o3 = Instantiate(piece);
        pieces.Add(o3);
        o3.transform.position = new Vector2(0.51f, -0.51f);
        o3.GetComponent<Pieces>().setwhite();

        GameObject o4 = Instantiate(piece);
        pieces.Add(o4);
        o4.transform.position = new Vector2(-0.51f, -0.51f);
        o4.GetComponent<Pieces>().setblack();
        
        current = Instantiate(piece);
        pieces.Add(current);
        current.GetComponent<Pieces>().setblack();



        makeboard();
        PrintBoard();

    }
    // Update is called once per frame
    void Update()
    {
        
        move();
        if (placed == false)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                correct();
                Vector2 position = current.transform.position;
                float closest = 1000000000000000000;
                int xind = 0;
                for (int x = 0; x < xvalues.Length; x++)
                {
                    float at = Mathf.Abs(position.x - xvalues[x]);
                    if (at < closest)
                    {
                        closest = at;
                        xind = x;
                    }
                }
                closest = 1000000000000000000;
                int yind = 0;
                for (int y = 0; y < yvalues.Length; y++)
                {
                    float at = Mathf.Abs(position.y - yvalues[y]);
                    if (at < closest)
                    {
                        closest = at;
                        yind = y;
                    }
                }
                
                if(board[xind, yind] != 1 && board[xind, yind] != 2)
                {
                    placed = true;
                    current = Instantiate(piece);
                    pieces.Add(current);
                    if (color % 2 == 0)
                    {
                        current.GetComponent<Pieces>().setwhite();
                    }
                    else
                    {
                        current.GetComponent<Pieces>().setblack();
                    }
                    color++;
                    makeboard();
                    PrintBoard();
                }
            }
        }
    }
    public void PrintBoard()
    {
        string s = "";
        for (int y = 7; y >= 0; y--) // top row first
        {
            for (int x = 0; x < 8; x++)
            {
                s += board[x, y] + " ";
            }
            s += "\n";
        }
        Debug.Log(s);
    }
    public void makeboard()
    {
        int place = 0;
        float closest = 1000000000000000000;
        int xind = 0;
        int yind = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board[i, j] = 0;
            }
        }
        for(int i = 0;i < pieces.Count; i++)
        {

            GameObject p = pieces[i];
            Vector2 position = p.transform.position;
            closest = 1000000000000000000;
            if(position.x < 4 &&  position.y < 4 && position.x > -4 && position.y > -4)
            {
                xind = 0;
                for (int x = 0; x < xvalues.Length; x++)
                {
                    float at = Mathf.Abs(position.x - xvalues[x]);
                    if (at < closest)
                    {
                        closest = at;
                        xind = x;
                    }
                }
                closest = 1000000000000000000;
                yind = 0;
                for (int y = 0; y < yvalues.Length; y++)
                {
                    float at = Mathf.Abs(position.y - yvalues[y]);
                    if (at < closest)
                    {
                        closest = at;
                        yind = y;
                    }
                }
                if (p.GetComponent<Pieces>().isBlack())
                {
                    board[xind, yind] = 1;
                }
                if (p.GetComponent<Pieces>().isWhite())
                {
                    board[xind, yind] = 2;
                }
            }
        }
        placed = false;
    }
    
    
    public void move()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        current.transform.position = new Vector2(mousePos.x, mousePos.y);

    }
    
    public void correct()
    {
       

        float closestX = xvalues[0];
        float closestY = yvalues[0];

        float minx = Mathf.Abs(pieces[pieces.Count - 1].transform.position.x - closestX);
        float miny = Mathf.Abs(pieces[pieces.Count - 1].transform.position.y - closestY);

        for (int i = 1; i < xvalues.Length; i++)
        {
            float xDiff = Mathf.Abs(pieces[pieces.Count - 1].transform.position.x - xvalues[i]);
            if (xDiff < minx)
            {
                minx = xDiff;
                closestX = xvalues[i];
            }

            float yDiff = Mathf.Abs(pieces[pieces.Count - 1].transform.position.y - yvalues[i]);
            if (yDiff < miny)
            {
                miny = yDiff;
                closestY = yvalues[i];
            }
        }

        pieces[pieces.Count - 1].transform.position = new Vector2(closestX, closestY);
    }
}
