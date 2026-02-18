using UnityEngine;

public class TullyMonster67 : MonoBehaviour
{
    Rigidbody2D rb;
    bool left, right;
    [SerializeField] float jumpforce;
    [SerializeField] float speed;
    Animator Animator;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
            ig = true;
        return ig;
    }
   
}
