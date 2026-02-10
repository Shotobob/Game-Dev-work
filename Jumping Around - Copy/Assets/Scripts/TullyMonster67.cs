using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TullyMonster67 : MonoBehaviour
{
    Rigidbody2D rb;
    bool left, right;
    [SerializeField] float jumpforce;
    [SerializeField] float speed;
    Animator Animator;
    private bool start = false;
     
    private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject buildings1;
    [SerializeField] GameObject buildings2;
    [SerializeField] GameObject buildings3;
    [SerializeField] GameObject buildings4;
    [SerializeField] GameObject buildings5;
    [SerializeField] GameObject buildings6;
    [SerializeField] Text Timetext;
    [SerializeField] Text losetext;
    [SerializeField] GameObject block1;
    [SerializeField] GameObject block2;
    [SerializeField] GameObject block3;
    [SerializeField] GameObject block4;
    [SerializeField] GameObject block5;
    [SerializeField] GameObject block6;
    [SerializeField] GameObject block7;
    [SerializeField] GameObject block8;
    [SerializeField] GameObject block9;
    [SerializeField] GameObject block10;
    [SerializeField] GameObject block11;
    [SerializeField] GameObject block12;
    private bool death = false;
    float seconds = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        losetext.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && death == true)
        {
            SceneManager.LoadScene(0);
        }
        if(death == false && start == true)
        {
            seconds += Time.deltaTime;
            Timetext.text =  "Time: " + (int) seconds;
        }
        
        if(transform.position.y < -6.8f)
        {
            losetext.text = "die, score wwas ts " + (int)seconds;
            death = true;
            losetext.enabled = true;
            start = false;
        }
        if(transform.position.x > 5.8f)
        {
            start = true;
            buildings1.GetComponent<buildings>().settrue();
            buildings2.GetComponent<buildings>().settrue();
            buildings3.GetComponent<buildings>().settrue();
            buildings4.GetComponent<buildings>().settrue();
            buildings5.GetComponent<buildings>().settrue();
            buildings6.GetComponent<buildings>().settrue();
           block1.GetComponent<player>().settrue();
           block2.GetComponent<player>().settrue();
           block3.GetComponent<player>().settrue();
           block4.GetComponent<player>().settrue();
           block5.GetComponent<player>().settrue();
           block6.GetComponent<player>().settrue();
           block7.GetComponent<player>().settrue();
           block8.GetComponent<player>().settrue();
           block9.GetComponent<player>().settrue();
           block10.GetComponent<player>().settrue();
           block11.GetComponent<player>().settrue();
           block12.GetComponent<player>().settrue();

        }

        float moving = 0;
        if (Input.GetKey(KeyCode.S) && isGrounded() == true)
        {
            Animator.SetInteger("State", 4);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && isGrounded() == true)
        {
            rb.linearVelocity = (new Vector2(rb.linearVelocity.x, jumpforce));
            Animator.SetInteger("State", 2);
            return;
        }
        if (rb.linearVelocityY > 0.1f && isGrounded() == false)
        {
            Animator.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            spriteRenderer.flipX = true;
            //Animator.SetInteger("State", 1);
            
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
            
        if(Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            spriteRenderer.flipX = false;
            //Animator.SetInteger("State", 1);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        

        float h = 0f;
        if (left)
        {
            h -= speed;
            moving = 1;
        }
        if (right)
        {
            h += speed;
            moving = 1;
        }
        rb.linearVelocity = new Vector2(h, rb.linearVelocity.y);
        
        
        if (rb.linearVelocityY < -0.1f && isGrounded() == false)
        {
            Animator.SetInteger("State", 3);
        }
        

        if (moving != 0 && isGrounded())
        {
            Animator.SetInteger("State", 1);
        }
        
        else if(isGrounded())
        {
            Animator.SetInteger("State", 0);
        }
        

    }
    public bool isGrounded()
    {
        bool ig = false;
        Vector2 castFrom = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.01f);
        RaycastHit2D hit = Physics2D.Raycast(castFrom, Vector2.down, .1f);
        //Debug.DrawRay(castFrom, (Vector2.down*.1f), )
        if(hit.transform != null && hit.transform.tag == "g")
        {
            
            ig = true;
        }
        
        return ig;
    }


    public void OnColliderEnter2D(Collision2D cd)
    {
        bool ig = false;
        Vector2 castFrom = new Vector2(transform.position.x, transform.position.y - GetComponent<SpriteRenderer>().bounds.size.y / 2 - 0.01f);
        RaycastHit2D hit = Physics2D.Raycast(castFrom, Vector2.down, .1f);
        //Debug.DrawRay(castFrom, (Vector2.down*.1f), )
        if(hit.transform != null && hit.transform.tag == "g")
        {
            if(left == false && right == false)
            {
                transform.parent = cd.transform; 
            }
            
        }
        
    }   

    public void OnColliderExit2D (Collision2D cd) {
        transform.parent = null; 
    }
}
