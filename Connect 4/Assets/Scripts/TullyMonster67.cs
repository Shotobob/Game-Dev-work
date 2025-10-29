using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class TullyMonster67 : MonoBehaviour
{
    [SerializeField] GameObject coin;
    private List<GameObject> coins = new List<GameObject>();
    private bool placed = false;
    private bool black = true;
    private bool redwin = false;
    private bool blackwin = false;
    [SerializeField] Text redwintext;
    [SerializeField] Text blackwintext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redwintext.enabled = false;
        blackwintext.enabled = false;
        GameObject o = Instantiate(coin);
        Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        coins.Add(o);
        rb.gravityScale = 0f;
        SpriteRenderer rb2 = o.GetComponent<SpriteRenderer>();
        rb2.color = Color.black;


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            isWin(coins[i]);
        }
        if (redwin == true)
        {
            redwintext.enabled=true;
            return;
        }
        if (blackwin == true)
        {
            blackwintext.enabled = true;
            return;
        }

        Rigidbody2D rb = coins[coins.Count - 1].GetComponent<Rigidbody2D>();
        
        
        
        if (placed == false)
        {
            //coins[coins.Count - 1].GetComponent<Collider2D>().enabled = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            coins[coins.Count - 1].transform.position = new Vector2(mousePos.x, 4.26f);
            correct();
            if (Input.GetKeyDown(KeyCode.Mouse0) && placed == false)
            {
                RaycastHit2D[] rays = Physics2D.RaycastAll(coins[coins.Count - 1].transform.position, Vector2.down, 1.5f);
                {
                    if(rays.Length <= 1)
                    {
                        //coins[coins.Count - 1].GetComponent<Collider2D>().enabled = true;
                        rb.gravityScale = 3f;
                        placed = true;
                    }
                }

            }

        }
        
        if (rb.gravityScale == 3f && placed == true && coins[coins.Count - 1].transform.position.y != 4.26f)
        {
            if(rb.linearVelocityY == 0f)
            {
                

                GameObject o = Instantiate(coin);
                Rigidbody2D newrb = o.GetComponent<Rigidbody2D>();
                SpriteRenderer rb2 = o.GetComponent<SpriteRenderer>();
                if(black == true)
                {
                    rb2.color = Color.red;
                    black = false;
                }
                else
                {
                    rb2.color = Color.black;
                    black = true;
                } 
                newrb.gravityScale = 0f;
                coins.Add(o);

                placed = false;

                for (int i = 0; i < coins.Count; i++)
                {
                    isWin(coins[i]);
                }

            }
            
            

        }




    }
    public void isWin(GameObject c)
    {
        int count = 0;
        SpriteRenderer coinrenderer = c.GetComponent<SpriteRenderer>();
        RaycastHit2D[] leftrays = Physics2D.RaycastAll(c.transform.position, Vector2.left, 5f);
        {
            if (leftrays.Length > 0)
            {
                for (int i = 0; i < leftrays.Length; i++)
                {
                    SpriteRenderer coincheck = leftrays[i].collider.GetComponent<SpriteRenderer>();
                    if (coincheck.color == coinrenderer.color && coincheck != null)
                    {
                        count++;
                    }
                }
            }

        }
        if (count >= 4)
        {
            if(coinrenderer.color == Color.red) 
                redwin = true;
            if (coinrenderer.color == Color.black)
                blackwin = true;
        }
        else
        {
            count = 0;
        }
        RaycastHit2D[] rightrays = Physics2D.RaycastAll(c.transform.position, Vector2.right, 5f);
        {
            if (rightrays.Length > 0)
            {
                for (int i = 0; i < rightrays.Length; i++)
                {
                    SpriteRenderer coincheck = rightrays[i].collider.GetComponent<SpriteRenderer>();
                    if (coincheck.color == coinrenderer.color && coincheck != null)
                    {
                        count++;
                    }
                }
            }

        }
        if (count >= 4)
        {
            if (coinrenderer.color == Color.red)
                redwin = true;
            if (coinrenderer.color == Color.black)
                blackwin = true;
        }
        else
        {
            count = 0;
        }
        RaycastHit2D[] uprays = Physics2D.RaycastAll(c.transform.position, Vector2.up, 4f);
        {
            if (uprays.Length > 0 && c.transform.position.y <= -1)
            {
                for (int i = 0; i < uprays.Length; i++)
                {
                    SpriteRenderer coincheck = uprays[i].collider.GetComponent<SpriteRenderer>();
                    if (coincheck.color == coinrenderer.color && coincheck != null)
                    {
                        count++;
                    }
                }
            }

        }
        if (count >= 4)
        {
            if (coinrenderer.color == Color.red)
                redwin = true;
            if (coinrenderer.color == Color.black)
                blackwin = true;
        }
        else
        {
            count = 0;
        }
        RaycastHit2D[] downrays = Physics2D.RaycastAll(c.transform.position, Vector2.down, 4f);
        {
            if (downrays.Length > 0 && c.transform.position.y != 4.26f)
            {
                for (int i = 0; i < downrays.Length; i++)
                {
                    SpriteRenderer coincheck = downrays[i].collider.GetComponent<SpriteRenderer>();
                    if (coincheck.color == coinrenderer.color && coincheck != null)
                    {
                        count++;
                    }
                }
            }

        }
        if (count >= 4)
        {
            if (coinrenderer.color == Color.red)
                redwin = true;
            if (coinrenderer.color == Color.black)
                blackwin = true;
        }
        else
        {
            count = 0;
        }
    }
    private void correct()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x >= -7 && mousePos.x <= -4.8)
        {
            coins[coins.Count - 1].transform.position = new Vector2(-5.4f, 4.26f);
        }
        if (mousePos.x >= -4.8 && mousePos.x <= -3)
        {
            coins[coins.Count - 1].transform.position = new Vector2(-3.6f, 4.26f);
        }
        if (mousePos.x >= -3 && mousePos.x <= -1.2)
        {
            coins[coins.Count - 1].transform.position = new Vector2(-1.8f, 4.26f);
        }
        if (mousePos.x >= -1.2 && mousePos.x <= 0.6)
        {
            coins[coins.Count - 1].transform.position = new Vector2(0f, 4.26f);
        }
        if (mousePos.x >= 0.6 && mousePos.x <= 2.4)
        {
            coins[coins.Count - 1].transform.position = new Vector2(1.8f, 4.26f);
        }
        if (mousePos.x >= 2.4 && mousePos.x <= 4.2)
        {
            coins[coins.Count - 1].transform.position = new Vector2(3.6f, 4.26f);
        }
        if (mousePos.x >= 4.2 && mousePos.x <= 6.2)
        {
            coins[coins.Count - 1].transform.position = new Vector2(5.4f, 4.26f);
        }
    }
}
