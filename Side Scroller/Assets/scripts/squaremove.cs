using Unity.VisualScripting;
using UnityEngine;

public class squaremove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float speed;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject Bullet;
    bool up, down, left, right;
    Rigidbody2D rb;
    float ogx = 0;
    float ogy = 0;
    Animator Animator;
    [SerializeField] float jumpforce;
    SpriteRenderer spriteRenderer;
    bool grounded = false;
    bool win;
    bool lose;

    void Start()
    {
        lose = false;
        win = false;
        ogx = transform.position.x;
        ogy = transform.position.y;

        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = false;
        if(win == true || lose == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                lose = false;
                lose = false;
                win = false;
                transform.position = new Vector3(-41f, 18f, transform.position.z);
                ogx = transform.position.x;
                ogy = transform.position.y;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.freezeRotation = true;
                up = false;
                down = false;
                left = false;
                right = false;
            }
        }
        
        if (manager.GetComponent<TullyMonster67>().iswin() == true)
        {
            rb.linearVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            win = true;
            //rb.linearVelocity = Vector3.zero;
        }
        if (manager.GetComponent<TullyMonster67>().islose() == true)
        {
            rb.linearVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            lose = true;
            //rb.linearVelocity = Vector3.zero;
        }
        if (win == true || lose == true)
        {
            return;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.right * 1.5f, transform.rotation);
            b.GetComponent<Rigidbody2D>().linearVelocity = b.transform.right * 5f;
            GameObject c = Instantiate(Bullet, transform.position + transform.right * -1.5f, transform.rotation);
            c.GetComponent<Rigidbody2D>().linearVelocity = b.transform.right * -5f;


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
        RaycastHit2D hit = Physics2D.Raycast(castFrom, Vector2.down, 0.05f);
        //Debug.DrawRay(castFrom, (Vector2.down*.1f), )
        if(hit.transform != null && hit.transform.tag == "g")
            ig = true;
        return ig;
    }
    public void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Collide");
        if(collision.gameObject.tag.Equals("g"))
        {
            grounded = true;
            
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.tag.Equals("death"))
        {
            if((gameObject.tag.Equals("Player")))
            {
                transform.position = new Vector3(ogx, ogy, transform.position.z);
                manager.GetComponent<TullyMonster67>().endlife();
            }
            
        }
        if (collision.gameObject.tag.Equals("win"))
        {
            win = true;
            manager.GetComponent<TullyMonster67>().win();
        }
        if (collision.gameObject.tag.Equals("p"))
        {
            //win = true;
            manager.GetComponent<TullyMonster67>().addpoint();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag.Equals("check"))
        {
            ogx = transform.position.x;
            ogy = transform.position.y;
        }


    }
 

}
