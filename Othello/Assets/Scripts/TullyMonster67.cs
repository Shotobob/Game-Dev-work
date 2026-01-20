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
    [SerializeField] GameObject animatedpiece;
    private List<GameObject> pieces = new List<GameObject>();
    private bool placed = false;
    private int color = 0;
    private float[] xvalues = { -3.66f, -2.61f, -1.56f, -0.51f, 0.51f, 1.56f, 2.61f, 3.66f };
    private float[] yvalues = { -3.66f, -2.61f, -1.56f, -0.51f, 0.51f, 1.56f, 2.61f, 3.66f };
    public GameObject current;
    private int[,] board = new int[8, 8];
    private bool legal = false;
    private bool blackwin = false;
    private bool whitewin = false;
    private bool tie = false;
    [SerializeField] Text blackwintext;
    [SerializeField] Text whitewintext;
    [SerializeField] Text tietext;
    [SerializeField] AudioSource wood;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackwintext.enabled = false; whitewintext.enabled = false; tietext.enabled = false;
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
        if (blackwin == true || whitewin == true || tie == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    Destroy(pieces[i]);
                }
                pieces.Clear();


                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        board[i, j] = 0;
                    }
                }

                placed = false;
                color = 0;
                legal = false;
                blackwin = false;
                whitewin = false;
                tie = false;

                blackwintext.enabled = false;
                whitewintext.enabled = false;
                tietext.enabled = false;

               
                GameObject o = Instantiate(piece);
                pieces.Add(o);
                o.transform.position = new Vector2(0.51f, 0.51f);
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
        }
        
        if (blackwin == true)
        {
            blackwintext.enabled = true;
        }
        if (whitewin == true)
        {
            whitewintext.enabled = true;
        }
        if (tie == true)
        {
            tietext.enabled = true;
        }
        if(pieces.Count > 5)
        {
            int wincounter = 0;
            int blackwincounter = 0;
            int whitewincounter = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != 0)
                        wincounter++;
                    if (board[i, j] == 1)
                        blackwincounter++;
                    if (board[i, j] == 2)
                        whitewincounter++;
                }

            }

            int currentp = color % 2 == 0 ? 1 : 2;
            if (haslegal(currentp) == false)
            {
                color++;
                currentp = color % 2 == 0 ? 1 : 2;
                if (haslegal(currentp) == false)
                {

                    wincounter = blackwincounter = whitewincounter = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (board[i, j] != 0)
                                wincounter++;
                            if (board[i, j] == 1)
                                blackwincounter++;
                            if (board[i, j] == 2)
                                whitewincounter++;
                        }
                    }

                    if (blackwincounter > whitewincounter)
                        blackwin = true;
                    else if (whitewincounter > blackwincounter)
                        whitewin = true;
                    else
                        tie = true;
                }
            }
            if (wincounter == 64)
            {
                if (blackwincounter > whitewincounter)
                    blackwin = true;
                if (whitewincounter > blackwincounter)
                    whitewin = true;
                if (whitewincounter == blackwincounter)
                    tie = true;

            }
        }
        

        if (placed == false && tie == false && blackwin == false && whitewin == false)
        {
            move();
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

                if (board[xind, yind] != 1 && board[xind, yind] != 2)
                {
                    correct();
                    makeboard();
                    Check360(xind, yind, true);
                    if(legal == true)
                    {
                        wood.Play();
                        placed = true;
                        
                        current = Instantiate(piece);
                        pieces.Add(current);
                        placed = false;
                        if (color % 2 == 0)
                        {
                            current.GetComponent<Pieces>().setwhite();
                        }
                        else
                        {
                            current.GetComponent<Pieces>().setblack();
                        }
                        color++;
                        //makeboard();
                        PrintBoard();

                    }
                    
                }
            }
        }
        


    }
    public bool haslegal(int color)
    {
        for(int i = 0;i < 8;i++)
        {
            for(int  j = 0;j < 8;j++)
            {
                if(board[i,j] != 0)  
                    continue;
                board[i,j] = color;
                Check360(i,j, false);
                board[i,j] = 0;
                if (legal == true)
                    return true;
            }
        }
        return false;
    }
    public void Check360(int xind, int yind, bool real)
    {
        bool islegal = false;
        int counter = 0;
        bool cont = true;
        int place = 1;
        int color = board[xind, yind];
        int enemy = (color == 1) ? 2 : 1;
        counter = 0;
        place = 1;
        cont = true;

        if (xind + 1 <= 7 && board[xind + 1, yind] == enemy)
        {
            counter++;
            place++;
            while (cont && xind + place <= 7)
            {
                if (board[xind + place, yind] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind + place, yind] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if (real == true)
                        {
                            board[xind + i, yind] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind + i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }

        }
        counter = 0;
        place = 1;
        cont = true;
        if (xind + 1 <= 7 && yind + 1 <= 7 && board[xind + 1, yind + 1] == enemy)
        {
            counter++;
            place++;

            while (cont && xind + place <= 7 && yind + place <= 7)
            {
                if (board[xind + place, yind + place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind + place, yind + place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind + i, yind + i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind + i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind + i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (yind + 1 <= 7 && board[xind, yind + 1] == enemy)
        {
            counter++;
            place++;

            while (cont && yind + place <= 7)
            {
                if (board[xind, yind + place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind, yind + place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind, yind + i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind]) < 0.01f && Mathf.Abs(position.y - yvalues[yind + i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (xind - 1 >= 0 && yind + 1 <= 7 && board[xind - 1, yind + 1] == enemy)
        {
            counter++;
            place++;

            while (cont && xind - place >= 0 && yind + place <= 7)
            {
                if (board[xind - place, yind + place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind - place, yind + place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind - i, yind + i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind - i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind + i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (xind - 1 >= 0 && board[xind - 1, yind] == enemy)
        {
            counter++;
            place++;

            while (cont && xind - place >= 0)
            {
                if (board[xind - place, yind] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind - place, yind] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind - i, yind] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind - i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (xind - 1 >= 0 && yind - 1 >= 0 && board[xind - 1, yind - 1] == enemy)
        {
            counter++;
            place++;

            while (cont && xind - place >= 0 && yind - place >= 0)
            {
                if (board[xind - place, yind - place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind - place, yind - place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind - i, yind - i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind - i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind - i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (yind - 1 >= 0 && board[xind, yind - 1] == enemy)
        {
            counter++;
            place++;

            while (cont && yind - place >= 0)
            {
                if (board[xind, yind - place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind, yind - place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind, yind - i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind]) < 0.01f && Mathf.Abs(position.y - yvalues[yind - i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                       
                    }
                    cont = false;
                }
                else
                {
                    cont = false;
                }
            }
        }
        counter = 0;
        place = 1;
        cont = true;

        if (xind + 1 <= 7 && yind - 1 >= 0 && board[xind + 1, yind - 1] == enemy)
        {
            counter++;
            place++;

            while (cont && xind + place <= 7 && yind - place >= 0)
            {
                if (board[xind + place, yind - place] == enemy)
                {
                    counter++;
                    place++;
                }
                else if (board[xind + place, yind - place] == color)
                {
                    islegal = true;
                    for (int i = 1; i <= counter; i++)
                    {
                        if(real == true)
                        {
                            board[xind + i, yind - i] = color;
                            for (int j = 0; j < pieces.Count; j++)
                            {
                                GameObject p = pieces[j];
                                Vector2 position = p.transform.position;
                                if (Mathf.Abs(position.x - xvalues[xind + i]) < 0.01f && Mathf.Abs(position.y - yvalues[yind - i]) < 0.01f)
                                {
                                    if (color == 1)
                                    {
                                        p.GetComponent<Pieces>().setblack();
                                    }
                                    else
                                    {
                                        p.GetComponent<Pieces>().setwhite();
                                    }
                                    wood.PlayOneShot(wood.clip);
                                    GameObject anim = Instantiate(animatedpiece, p.transform.position, Quaternion.identity);
                                    Animator animator = anim.GetComponent<Animator>();
                                    float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
                                    Destroy(anim, animLength);
                                    break;
                                }
                            }
                        }
                        
                    }
                        
                    cont = false;
                }
                else
                {
                    cont = false;



                }
            }
        }
        legal = islegal;
    }
    public void PrintBoard()
    {
        string s = "";
        for (int y = 7; y >= 0; y--) 
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
